// <copyright file="UserSettingController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.API.Controllers.Administration
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using TEHA.Portal.API.Helpers;
    using TEHA.Portal.Data.Models.Administration;
    using TEHA.Portal.Data.Services.Administration;

    /// <summary>
    /// Implements user settings
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserSettingController : ApiControllerBase
    {
        private readonly UserSettingService userSettingService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserSettingController"/> class.
        /// </summary>
        /// <param name="userSettingService">initialze</param>
        public UserSettingController(UserSettingService userSettingService)
        {
            this.userSettingService = userSettingService;
        }

        /// <summary>
        /// User Settings
        /// </summary>
        /// <remarks>Get user settings. Admin Module</remarks>
        /// <param name="id">id</param>
        /// <response code="200">OK</response>
        /// <returns>ok</returns>
        [HttpGet]
        [Route("Get")]
        [AllowAnonymous]
        public IActionResult Get(int id)
        {
           var setting = this.userSettingService.Get(id);
           return this.Result(ResponseStatus.OK, setting, null);
        }

        /// <summary>
        /// User Settings
        /// </summary>
        /// <remarks>Updates user settings. Admin Module</remarks>
        /// <param name="body">UserSetting</param>
        /// <response code="200">OK</response>
        /// <returns>ok</returns>
        [HttpPost]
        [Route("CreateOrUpdate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult CreateOrUpdate([FromBody] UserSetting body)
        {
            this.userSettingService.CreateOrUpdate(body);
            return this.Result(ResponseStatus.OK, null, null);
        }
    }
}
