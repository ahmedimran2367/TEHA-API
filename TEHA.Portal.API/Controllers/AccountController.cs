// <copyright file="AccountController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.API.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using MWCIA.OAR.API;
    using Newtonsoft.Json;
    using TEHA.Portal.API.Helpers;
    using TEHA.Portal.Data;
    using TEHA.Portal.Data.Models.Account;
    using TEHA.Portal.Data.Models.Validation;
    using TEHA.Portal.ProxyAPI.Clients.Account;

    /// <summary>
    /// Implements Accounts/My Profile endpoints
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ApiControllerBase
    {
        private readonly IAccountClient accountClient;
        private readonly IMapper mapper;
        private readonly Configuration configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController"/> class.
        /// </summary>
        /// <param name="accountClient">Account Client</param>
        /// <param name="mapper">Params</param>
        /// <param name="configuration">Configuration</param>
        public AccountController(IAccountClient accountClient, IMapper mapper, Configuration configuration)
        {
            this.accountClient = accountClient;
            this.mapper = mapper;
            this.configuration = configuration;
        }

        /// <summary>
        /// Get User Contact Information
        /// </summary>
        /// <remarks>Returns basic user informations </remarks>
        /// <param name="userId">User ID</param>
        /// <response code="200">OK</response>
        /// <response code="400">Invalid User Id.</response>
        /// <returns>TEHA.Portal.Data.Models.Account.ContactInformation</returns>
        [HttpGet]
        [Route("GetUserContactInformation")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ContactInformation))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetUserContactInformation([FromQuery][Required] int userId)
        {
            return await this.Result<ContactInformation>(await this.accountClient.GetUserContactInformation(this.CurrentUser.ExternalToken, userId));
        }

        /// <summary>
        /// Get User Detail
        /// </summary>
        /// <remarks>Gets My Profile complete data</remarks>
        /// <param name="id">User ID</param>
        /// <response code="200">OK</response>
        /// <response code="400">User id not found.</response>
        /// <returns>TEHA.Portal.Data.Models.Account.Profile</returns>
        [HttpGet]
        [Route("Detail")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Data.Models.Account.Profile))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetProfileDetail([FromQuery] int id)
        {
            return await this.Result<Data.Models.Account.Profile>(await this.accountClient.Detail(this.CurrentUser.ExternalToken, id));
        }

        /// <summary>
        /// Sends email to user to reset password.
        /// </summary>
        /// <remarks>Sends an email to user to reset password. (Internal use only) </remarks>
        /// <param name="username">Username</param>
        /// <response code="200">OK</response>
        /// <returns>Returns boolean value</returns>
        [AllowAnonymous]
        [HttpPost]
        [Route("ForgotPassword")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ForgotPassword(string username)
        {
            return await this.Result<bool>(await this.accountClient.ForgotPassword(username));
        }

        /// <summary>
        /// Verifies user credentials.
        /// </summary>
        /// <remarks>Verifies user credentials</remarks>
        /// <param name="userCredential">UserCredential</param>
        /// <response code="200">OK</response>
        /// <response code="400">Invalid username or password. </response>
        /// <returns>TEHA.Portal.Data.Models.Account.UserCredential</returns>
        [AllowAnonymous]
        [HttpPost]
        [Route("Authenticate")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserCredential))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Authenticate([FromBody] UserCredential userCredential)
        {
            if (!this.ModelState.IsValid)
            {
                return new BadRequestObjectResult(this.Result(ResponseStatus.BadRequest, null, "Missing Parameters"));
            }

            HttpResponseMessage response = await this.accountClient.Login(userCredential);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var obj = JsonConvert.DeserializeObject<ProxyResponse<UserLoginResponse>>(await response.Content.ReadAsStringAsync());
                User user = this.mapper.Map<User>(obj.Data);
                user.ExternalToken = obj.Data.Token;
                obj.Data.ExternalToken = obj.Data.Token;
                obj.Data.Token = JwtTokenGenerator.GenerateToken(System.Text.Json.JsonSerializer.Serialize(user), this.configuration.Secret);
                obj.Data.RefreshToken = JwtTokenGenerator.GenerateRefreshToken(System.Text.Json.JsonSerializer.Serialize(user), this.configuration.Secret);
                return new OkObjectResult(this.Result(ResponseStatus.OK, obj.Data, null));
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                // this is extra line remove when dynamic message
                var obj = JsonConvert.DeserializeObject<ProxyResponse<List<Error>>>(await response.Content.ReadAsStringAsync());
                return new BadRequestObjectResult(this.Result(ResponseStatus.BadRequest, null, obj.Errors[0].Description));
            }
            else
            {
                return await this.ErrorResult(response);
            }
        }

        /// <summary>
        /// Returns New Refresh Token
        /// </summary>
        /// <param name="currentUser">Current User</param>
        /// <returns>User</returns>
        [AllowAnonymous]
        [HttpPost("GetNewRefreshToken")]
        public IActionResult GetNewRefreshToken([FromBody] User currentUser)
        {
            if (JwtTokenGenerator.IsValidRefreshToken(this.configuration.Secret, currentUser))
            {
                currentUser.Token = string.Empty;
                currentUser.RefreshToken = string.Empty;
                currentUser.Token = JwtTokenGenerator.GenerateToken(System.Text.Json.JsonSerializer.Serialize(currentUser), this.configuration.Secret);
                currentUser.RefreshToken = JwtTokenGenerator.GenerateRefreshToken(System.Text.Json.JsonSerializer.Serialize(currentUser), this.configuration.Secret);
                return new OkObjectResult(this.Result(ResponseStatus.OK, currentUser));
            }
            else
            {
                return new UnauthorizedObjectResult(this.Result(ResponseStatus.OK, null, "Refresh Token Expired."));
            }
        }

        /// <summary>
        /// Update user contact information
        /// </summary>
        /// <remarks>Update user contact information.</remarks>
        /// <param name="updateContactInfoRequest">UpdateContactInfoRequest</param>
        /// <response code="200">OK</response>
        /// <response code="400">Invalid user ID.</response>
        /// <response code="409">Validation Errors.</response>
        /// <returns>Error Response in case of 409</returns>
        [HttpPut]
        [Route("UpdateContactInformation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Data.Models.Validation.Response))]
        public async Task<IActionResult> UpdateContactInformation([FromBody] UpdateContactInfoRequest updateContactInfoRequest)
        {
            return await this.Result<bool>(await this.accountClient.UpdateContactInformation(this.CurrentUser.ExternalToken, updateContactInfoRequest));
        }

        /// <summary>
        /// Update Team Member Detail
        /// </summary>
        /// <remarks>Edits or update Team Member details</remarks>
        /// <param name="updateMemberDetailsRequest">UpdateMemberDetailsRequest</param>
        /// <response code="200">OK</response>
        /// <response code="404">Not Found</response>
        /// <response code="409">Validation Errors.</response>
        /// <returns>Error Response in case of 409</returns>
        [HttpPut]
        [Route("EditTeamMember")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Data.Models.Validation.Response))]
        public async Task<IActionResult> EditTeamMember([FromBody] UpdateMemberDetailsRequest updateMemberDetailsRequest)
        {
            return await this.Result<bool>(await this.accountClient.EditTeamMember(this.CurrentUser.ExternalToken, updateMemberDetailsRequest));
        }

        /// <summary>
        /// change user password
        /// </summary>
        /// <remarks>upadte user password</remarks>
        /// <param name="changePasswordRequest">ChangePasswordRequest</param>
        /// <response code="200">OK</response>
        /// <response code="400">Invalid email.</response>
        /// <response code="409">Validation errors.</response>
        /// <returns>Error Response in case of 409</returns>
        [HttpPut]
        [Route("ChangePassword")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Data.Models.Validation.Response))]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest changePasswordRequest)
        {
            return await this.Result<bool>(await this.accountClient.ChangePassword(this.CurrentUser.ExternalToken, changePasswordRequest));
        }

        /// <summary>
        /// Updates member properties
        /// </summary>
        /// <remarks>Updates member properties. </remarks>
        /// <param name="updateMemberPropertyRequest">UpdateMemberPropertyRequest</param>
        /// <response code="200">OK</response>
        /// <response code="400">Invalid User Id.</response>
        /// <response code="409">Validation errors.</response>
        /// <returns>Error Response in case of 409</returns>
        [HttpPut]
        [Route("UpdateMemberProperties")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Data.Models.Validation.Response))]
        public async Task<IActionResult> UpdateMemberProperties([FromBody] UpdateMemberPropertyRequest updateMemberPropertyRequest)
        {
            return await this.Result<bool>(await this.accountClient.UpdateMemberProperties(this.CurrentUser.ExternalToken, updateMemberPropertyRequest));
        }

        /// <summary>
        /// Update user general settings
        /// </summary>
        /// <remarks>Update user general settings.</remarks>
        /// <param name="updateGeneralSettingRequest">UpdateGeneralSettingsRequest</param>
        /// <response code="200">OK</response>
        /// <response code="400">Invalid User Id.</response>
        /// <response code="409">Validation errors.</response>
        /// <returns>Error Response in case of 409</returns>
        [HttpPut]
        [Route("UpdateGeneralSetting")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Data.Models.Validation.Response))]
        public async Task<IActionResult> UpdateGeneralSetting([FromBody] UpdateGeneralSettingRequest updateGeneralSettingRequest)
        {
            return await this.Result<bool>(await this.accountClient.UpdateGeneralSetting(this.CurrentUser.ExternalToken, updateGeneralSettingRequest));
        }

        /// <summary>
        /// Get user general settings
        /// </summary>
        /// <remarks>Get General settings for a user or for a specific property</remarks>
        /// <param name="id">User Id to enforce authorization</param>
        /// <param name="propertyId">Property Id to get General Settings for specific property</param>
        /// <response code="200">OK</response>
        /// <response code="404">Not Found</response>
        /// <returns>200 OK response</returns>
        [HttpGet]
        [Route("GetGeneralSetting")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GeneralSetting))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetGeneralSetting([FromQuery] int id, [FromQuery] int? propertyId)
        {
            return await this.Result<GeneralSetting>(await this.accountClient.GetGeneralSetting(this.CurrentUser.ExternalToken, id, propertyId));
        }

        /// <summary>
        /// Add new team member
        /// </summary>
        /// <param name="teamMemberDetail">teamMemberDetail</param>
        /// <response code="200">OK</response>
        /// <response code="409">Conflict</response>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [HttpPost]
        [Route("AddTeamMember")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Member))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Data.Models.Validation.Response))]
        public async Task<IActionResult> AddTeamMember([FromBody] TeamMemberDetail teamMemberDetail)
        {
            return await this.Result<Member>(await this.accountClient.AddTeamMember(this.CurrentUser.ExternalToken, teamMemberDetail));
        }
    }
}
