// <copyright file="SystemLogController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.API.Controllers.Administration
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using TEHA.Portal.API.Helpers;
    using TEHA.Portal.Data.Models.Administration;
    using TEHA.Portal.Data.Services.Administration;

    /// <summary>
    /// Implements system Log
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SystemLogController : ControllerBase
    {
        private readonly SystemLogService systemLogService;

        /// <summary>
        /// Initializes a new instance of the <see cref="SystemLogController"/> class.
        /// </summary>
        /// <param name="systemLogService">initialze</param>
        public SystemLogController(SystemLogService systemLogService)
        {
            this.systemLogService = systemLogService;
        }

        /// <summary>
        /// System Logs
        /// </summary>
        /// <remarks>Returns all system Logs. Admin Module</remarks>
        /// <response code="200">OK</response>
        /// <returns>system Log</returns>
        [HttpGet]
        [Route("Get")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<SystemLog>))]
        public IActionResult Get()
        {
            List<SystemLog> list = this.systemLogService.GetAll();

            return this.Result(ResponseStatus.OK, list, null);
        }
    }
}
