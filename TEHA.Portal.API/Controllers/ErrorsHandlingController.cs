// <copyright file="ErrorsHandlingController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.API.Controllers
{
    using System;
    using Microsoft.AspNetCore.Diagnostics;
    using Microsoft.AspNetCore.Mvc;
    using TEHA.Portal.Common;
    using TEHA.Portal.Data.Services.Administration;

    /// <summary>
    /// Implements Error Handling Middleware
    /// </summary>
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorsHandlingController : ControllerBase
    {
        private readonly SystemLogService systemLogService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorsHandlingController"/> class.
        /// Controller
        /// </summary>
        /// <param name="systemLogService">SystemLogService</param>
        public ErrorsHandlingController(SystemLogService systemLogService)
        {
            this.systemLogService = systemLogService;
        }

        /// <summary>
        /// Catch Error
        /// </summary>
        [Route("error")]
        public void Error()
        {
            var exception = this.HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error; // Your exception

            var errorData = new
            {
                Url = this.HttpContext.Features.Get<IExceptionHandlerPathFeature>()?.Path,
                Referral = string.Empty,
                ActionParameters = this.HttpContext.Request.QueryString.ToString(),
                M = this.HttpContext.Request.Method.ToString(),
            };

            Utility.LogExeption(exception?.GetType().Name, exception?.Message, DateTime.Now.ToString(), "API", exception?.ToString(), errorData.ToString(), this.systemLogService);
        }
    }
}
