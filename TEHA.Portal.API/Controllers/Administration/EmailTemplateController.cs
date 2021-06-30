// <copyright file="EmailTemplateController.cs" company="PlaceholderCompany">
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
    /// Implements Email Template endpoints
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class EmailTemplateController : ApiControllerBase
    {
        private readonly EmailTemplateService emailTemplateService;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailTemplateController"/> class.
        /// Controller
        /// </summary>
        /// <param name="emailTemplateService">EmailTemplateService</param>
        public EmailTemplateController(EmailTemplateService emailTemplateService)
        {
            this.emailTemplateService = emailTemplateService;
        }

        /// <summary>
        /// Gets List of Email templates
        /// </summary>
        /// <remarks>Returns list of email templates</remarks>
        /// <response code="200">OK</response>
        /// <returns>List<TEHA.Portal.Data.Models.Admin.EmailTemplate></returns>
        [HttpGet]
        [Route("Get")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<EmailTemplate>))]
        public IActionResult Get()
        {
            List<EmailTemplate> emailTemplates = this.emailTemplateService.GetAll();
            if (emailTemplates == null)
            {
                return this.Result(ResponseStatus.OK, null, null);
            }

            return this.Result(ResponseStatus.OK, emailTemplates, null);
        }

        /// <summary>
        /// Edits/Updates an Email template
        /// </summary>
        /// <remarks>Updates an email template</remarks>
        /// <param name="emailTemplate">EmailTemplate</param>
        /// <response code="200">OK</response>
        /// <returns>Simple OK response</returns>
        [HttpPut]
        [Route("Update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Update([FromBody] EmailTemplate emailTemplate)
        {
            if (emailTemplate == null)
            {
                return this.Result(ResponseStatus.Error, null, null);
            }

            this.emailTemplateService.Update(emailTemplate);
            return this.Result(ResponseStatus.OK, null, null);
        }
    }
}
