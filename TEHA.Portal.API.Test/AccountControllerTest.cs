// <copyright file="AccountControllerTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.API.Test
{
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using AutoMapper;
    using FluentAssertions;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Newtonsoft.Json;
    using TEHA.Portal.API.Controllers;
    using TEHA.Portal.API.Helpers;
    using TEHA.Portal.API.Test.Helper;
    using TEHA.Portal.Data.Models.Account;
    using TEHA.Portal.Data.Models.Validation;
    using TEHA.Portal.ProxyAPI.Clients.Account;
    using Xunit;

    /// <summary>
    /// Contains account test cases.
    /// </summary>
    [Trait("Category", "Account")]
    public class AccountControllerTest : TestBase
    {
        private readonly string path = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName}/Json/Account";

        private readonly AccountClient accountClient = new AccountClient();

        private readonly IMapper mapper;

        private readonly Configuration configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountControllerTest"/> class.
        /// </summary>
        public AccountControllerTest()
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapping());
            });
            ConfigurationBuilder builder = new Microsoft.Extensions.Configuration.ConfigurationBuilder();
            IConfigurationRoot config = builder.AddJsonFile("appsettings.json").Build();
            this.configuration = new Configuration(config.GetSection("AppSettings"));
            this.mapper = mapperConfig.CreateMapper();
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>Task</returns>
        [Theory]
        [InlineData("2")]
        [InlineData("3168")]
        [InlineData("2234")]
        [InlineData("134")]
        [InlineData("2817")]
        [InlineData("2270")]
        [InlineData("2318")]
        [InlineData("5451")]
        [InlineData("4606")]
        [InlineData("3804")]
        public async Task Login_Should_Return_OK(string username)
        {
            AccountController sut = new AccountController(this.accountClient, this.mapper, this.configuration);
            var okResult = await sut.Authenticate(new UserCredential() { Username = username, Password = "33DCMnPg7XHGcCrD" }) as ObjectResult;
            Assert.Equal(okResult.StatusCode, StatusCodes.Status200OK);
            Assert.IsType<UserLoginResponse>((okResult.Value as Response<UserLoginResponse>).Data);
        }

        /// <summary>
        /// Login Bad Request
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>task</returns>
        [Theory]
        [InlineData("1")]
        public async Task Login_Should_Return_Bad_Request(string username)
        {
            AccountController sut = new AccountController(this.accountClient, this.mapper, this.configuration);
            var okResult = await sut.Authenticate(new UserCredential() { Username = username, Password = "33DCMnPg7XHGcCrD" }) as ObjectResult;
            Assert.Equal(okResult.StatusCode, StatusCodes.Status400BadRequest);
        }

        /// <summary>
        /// Forgot Password Ok
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>task</returns>
        [Theory]
        [InlineData("2")]
        public async Task ForgotPassword_Should_Return_OK(string username)
        {
            AccountController sut = new AccountController(this.accountClient, this.mapper, this.configuration);
            sut.CurrentUser = await this.GetUser(username);
            //var okResult = await sut.ForgotPassword(new ForgotPasswordRequest() { Username = sut.CurrentUser.Id.ToString() }) as ObjectResult;
            //Assert.Equal(okResult.StatusCode, StatusCodes.Status200OK);
        }

        /// <summary>
        /// Change Password ok
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>Task</returns>
        [Theory]
        [InlineData("2")]
        public async Task ChangePassword_Should_Return_OK(string username)
        {
            AccountController sut = new AccountController(this.accountClient, this.mapper, this.configuration);
            sut.CurrentUser = await this.GetUser(username);
            var okResult = await sut.ChangePassword(new ChangePasswordRequest() { UserId = sut.CurrentUser.Id, OldPassword = "33DCMnPg7XHGcCrD", NewPassword = "33DCMnPg7XHGcCrD" }) as ObjectResult;
            Assert.Equal(okResult.StatusCode, StatusCodes.Status200OK);
        }

        /// <summary>
        /// Change Password not found
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>Task</returns>
        [Theory]
        [InlineData("2")]
        public async Task ChangePassword_Should_Return_Not_Found(string username)
        {
            AccountController sut = new AccountController(this.accountClient, this.mapper, this.configuration);
            sut.CurrentUser = await this.GetUser(username);
            var okResult = await sut.ChangePassword(new ChangePasswordRequest() { UserId = 1, OldPassword = "33DCMnPg7XHGcCrD", NewPassword = "33DCMnPg7XHGcCrD" }) as ObjectResult;
            Assert.Equal(okResult.StatusCode, StatusCodes.Status404NotFound);
        }

        /// <summary>
        /// Change Password validation erros
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>Task</returns>
        [Theory]
        [InlineData("2")]
        public async Task ChangePassword_Should_Return_Validation_Error(string username)
        {
            AccountController sut = new AccountController(this.accountClient, this.mapper, this.configuration);
            sut.CurrentUser = await this.GetUser(username);
            var okResult = await sut.ChangePassword(new ChangePasswordRequest() { UserId = sut.CurrentUser.Id, OldPassword = "33DCMnPg7XHGcCrD!@", NewPassword = "33DCMnPg7XHGcCrD" }) as ObjectResult;
            Assert.Equal(okResult.StatusCode, StatusCodes.Status409Conflict);
            Assert.IsType<List<Error>>((okResult.Value as Response<List<Error>>).Data);
            (okResult.Value as Response<List<Error>>).Data.Count.Should().BeGreaterThan(0);
        }

        /// <summary>
        /// User Detail ok
        /// </summary>
        /// <param name="username">username</param>
        /// <returns>Task</returns>
        [Theory]
        [InlineData("2")]
        public async Task Detail_Should_Return_OK(string username)
        {
            AccountController sut = new AccountController(this.accountClient, this.mapper, this.configuration);
            sut.CurrentUser = await this.GetUser(username);
            var okResult = await sut.GetProfileDetail(sut.CurrentUser.Id) as ObjectResult;
            Assert.Equal(okResult.StatusCode, StatusCodes.Status200OK);
            Assert.IsType<Data.Models.Account.Profile>((okResult.Value as Response<Data.Models.Account.Profile>).Data);
        }

        /// <summary>
        /// User Detail Bad Request
        /// </summary>
        /// <param name="username">username</param>
        /// <returns>Task</returns>
        [Theory]
        [InlineData("2")]
        public async Task Detail_Should_Return_Not_Found(string username)
        {
            AccountController sut = new AccountController(this.accountClient, this.mapper, this.configuration);
            sut.CurrentUser = await this.GetUser(username);
            var okResult = await sut.GetProfileDetail(1) as ObjectResult;
            Assert.Equal(okResult.StatusCode, StatusCodes.Status404NotFound);
        }

        /// <summary>
        /// User contact information ok
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>Task</returns>
        [Theory]
        [InlineData("2")]
        public async Task User_Contact_Information_Should_Return_OK(string username)
        {
            AccountController sut = new AccountController(this.accountClient, this.mapper, this.configuration);
            sut.CurrentUser = await this.GetUser(username);
            var okResult = await sut.GetUserContactInformation(sut.CurrentUser.Id) as ObjectResult;
            Assert.Equal(okResult.StatusCode, StatusCodes.Status200OK);
            Assert.IsType<ContactInformation>((okResult.Value as Response<ContactInformation>).Data);
        }

        /// <summary>
        /// User contact information not found
        /// </summary>
        /// <param name="username">username</param>
        /// <returns>Task</returns>
        [Theory]
        [InlineData("2")]
        public async Task User_Contact_Information_Return_Not_Found(string username)
        {
            AccountController sut = new AccountController(this.accountClient, this.mapper, this.configuration);
            sut.CurrentUser = await this.GetUser(username);
            var okResult = await sut.GetUserContactInformation(1) as ObjectResult;
            Assert.Equal(okResult.StatusCode, StatusCodes.Status404NotFound);
        }

        /// <summary>
        /// Update General Setting ok
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>Task</returns>
        [Theory]
        [InlineData("2")]
        public async Task Update_General_Setting_Return_OK(string username)
        {
            UpdateGeneralSettingRequest updateGeneralSettingRequest = JsonConvert.DeserializeObject<UpdateGeneralSettingRequest>(File.ReadAllText($"{this.path}/DefaultUpdateGeneralSettingRequest.json"));

            AccountController sut = new AccountController(this.accountClient, this.mapper, this.configuration);
            sut.CurrentUser = await this.GetUser(username);
            updateGeneralSettingRequest.UserId = sut.CurrentUser.Id;
            var okResult = await sut.UpdateGeneralSetting(updateGeneralSettingRequest) as ObjectResult;
            Assert.Equal(okResult.StatusCode, StatusCodes.Status200OK);
        }

        /// <summary>
        /// Update General Setting Bad Request
        /// </summary>
        /// <param name="username">username</param>
        /// <returns>Task</returns>
        [Theory]
        [InlineData("2")]
        public async Task Update_General_Setting_Return_Bad_Request(string username)
        {
            UpdateGeneralSettingRequest updateGeneralSettingRequest = JsonConvert.DeserializeObject<UpdateGeneralSettingRequest>(File.ReadAllText($"{this.path}/DefaultUpdateGeneralSettingRequest.json"));
            AccountController sut = new AccountController(this.accountClient, this.mapper, this.configuration);
            sut.CurrentUser = await this.GetUser(username);
            updateGeneralSettingRequest.Id = 1;
            var okResult = await sut.UpdateGeneralSetting(updateGeneralSettingRequest) as ObjectResult;
            Assert.Equal(okResult.StatusCode, StatusCodes.Status400BadRequest);
        }

        /// <summary>
        /// Update contact information ok
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>Task</returns>
        [Theory]
        [InlineData("2")]
        public async Task Update_Contact_Information_Return_OK(string username)
        {
            UpdateContactInfoRequest updateContactInfoRequest = JsonConvert.DeserializeObject<UpdateContactInfoRequest>(File.ReadAllText($"{this.path}/DefaultUpdateContactInfoRequest.json"));

            AccountController sut = new AccountController(this.accountClient, this.mapper, this.configuration);
            sut.CurrentUser = await this.GetUser(username);
            updateContactInfoRequest.Id = sut.CurrentUser.Id;
            var okResult = await sut.UpdateContactInformation(updateContactInfoRequest) as ObjectResult;
            Assert.Equal(okResult.StatusCode, StatusCodes.Status200OK);
        }

        /// <summary>
        /// Update contact information Bad Request
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>Task</returns>
        [Theory]
        [InlineData("2")]
        public async Task Update_Contact_Information_Return_Bad_Request(string username)
        {
            UpdateContactInfoRequest updateContactInfoRequest = JsonConvert.DeserializeObject<UpdateContactInfoRequest>(File.ReadAllText($"{this.path}/DefaultUpdateContactInfoRequest.json"));
            AccountController sut = new AccountController(this.accountClient, this.mapper, this.configuration);
            sut.CurrentUser = await this.GetUser(username);
            updateContactInfoRequest.Id = 1;
            var okResult = await sut.UpdateContactInformation(updateContactInfoRequest) as ObjectResult;
            Assert.Equal(okResult.StatusCode, StatusCodes.Status400BadRequest);
        }

        /// <summary>
        /// Update member properties ok
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>Task</returns>
        [Theory]
        [InlineData("2")]
        public async Task Update_Member_Properties_Return_OK(string username)
        {
            UpdateMemberPropertyRequest updateMemberPropertyRequest = JsonConvert.DeserializeObject<UpdateMemberPropertyRequest>(File.ReadAllText($"{this.path}/DefaultUpdateMemberPropertiesRequest.json"));

            AccountController sut = new AccountController(this.accountClient, this.mapper, this.configuration);
            sut.CurrentUser = await this.GetUser(username);
            updateMemberPropertyRequest.UserId = sut.CurrentUser.Id;
            var okResult = await sut.UpdateMemberProperties(updateMemberPropertyRequest) as ObjectResult;
            Assert.Equal(okResult.StatusCode, StatusCodes.Status200OK);
        }

        /// <summary>
        /// Update member properties Bad Request
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>Task</returns>
        [Theory]
        [InlineData("2")]
        public async Task Update_Member_Properties_Return_Bad_Request(string username)
        {
            UpdateMemberPropertyRequest updateMemberPropertyRequest = JsonConvert.DeserializeObject<UpdateMemberPropertyRequest>(File.ReadAllText($"{this.path}/DefaultUpdateMemberPropertiesRequest.json"));
            AccountController sut = new AccountController(this.accountClient, this.mapper, this.configuration);
            sut.CurrentUser = await this.GetUser(username);
            updateMemberPropertyRequest.UserId = 1;
            var okResult = await sut.UpdateMemberProperties(updateMemberPropertyRequest) as ObjectResult;
            Assert.Equal(okResult.StatusCode, StatusCodes.Status400BadRequest);
        }

        /// <summary>
        /// Update member properties Bad Request
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>Task</returns>
        [Theory]
        [InlineData("2")]
        public async Task AddTeamMember_Should_Return_NotFound(string username)
        {
            TeamMemberDetail teamMemberDetail = JsonConvert.DeserializeObject<TeamMemberDetail>(File.ReadAllText($"{this.path}/DefaultTeamMemberDetail.json"));
            AccountController sut = new AccountController(this.accountClient, this.mapper, this.configuration);
            sut.CurrentUser = await this.GetUser(username);
            teamMemberDetail.UserId = sut.CurrentUser.Id;
            var okResult = await sut.AddTeamMember(teamMemberDetail) as ObjectResult;
            Assert.Equal(okResult.StatusCode, StatusCodes.Status404NotFound);
        }
    }
}
