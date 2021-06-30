// <copyright file="SettingController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.API.Controllers.Administration
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using TEHA.Portal.API.Helpers;
    using TEHA.Portal.Data.Models.Administration;
    using TEHA.Portal.Data.Models.Common;
    using TEHA.Portal.Data.Services.Administration;

    /// <summary>
    /// Implements system settings
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SettingController : ApiControllerBase
    {
        private readonly SystemSettingService systemSettingService;

        /// <summary>
        /// Initializes a new instance of the <see cref="SettingController"/> class.
        /// </summary>
        /// <param name="systemSettingService">initialze</param>
        public SettingController(SystemSettingService systemSettingService)
        {
            this.systemSettingService = systemSettingService;
        }

        /// <summary>
        /// SystemSetting
        /// </summary>
        /// <remarks>Returns all system settings. Admin Module</remarks>
        /// <param name="request">request</param>
        /// <response code="200">OK</response>
        /// <returns>system settings</returns>
        [HttpPost]
        [AllowAnonymous]
        [Route("Get")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<SystemSetting>))]
        public IActionResult Get(SettingsRequest request)
        {
            SettingsResult result = this.systemSettingService.GetAllSettings(request);
            return new OkObjectResult(this.Result(ResponseStatus.OK, result, null));
        }

        /// <summary>
        /// Download latest document.json
        /// </summary>
        /// <response code="200">OK</response>
        /// <returns>system settings</returns>
        [HttpGet]
        [Route("GetDocumentJson")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FileContentResponse))]
        public async Task<IActionResult> GetDocumentJson()
        {
            FileContentResponse result = await this.systemSettingService.GetDocumentJsonContent();
            return new OkObjectResult(this.Result(ResponseStatus.OK, result, null));
        }

        /// <summary>
        /// System Settings
        /// </summary>
        /// <remarks>Updates system settings. Admin Module</remarks>
        /// <param name="body">SystemSettings</param>
        /// <response code="200">OK</response>
        /// <returns>ok</returns>
        [HttpPut]
        [Route("Update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Update([FromBody] SystemSetting body)
        {
            this.systemSettingService.Update(body);
            return this.Result(ResponseStatus.OK, null, null);
        }
    }
}
