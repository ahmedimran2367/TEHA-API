// <copyright file="EmailTemplateService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Services.Administration
{
    using System.Collections.Generic;
    using System.Linq;
    using BITLogix.Core.Couchbase;
    using TEHA.Portal.Data.Models.Administration;

    /// <summary>
    /// Email Templates Data store
    /// </summary>
    public class EmailTemplateService
    {
        private readonly IDbClient<EmailTemplate> dbClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailTemplateService"/> class.
        /// </summary>
        /// <param name="configuration">IConfiguration</param>
        public EmailTemplateService(IConfiguration configuration)
        {
            this.dbClient = DbClientFactory.Default.Create<EmailTemplate>(configuration);
        }

        /// <summary>
        /// Gets list of all email templates
        /// </summary>
        /// <returns>List<TEHA.Portal.Data.Models.Admin.EmailTemplate></returns>
        public List<EmailTemplate> GetAll()
        {
            return this.dbClient.GetAll().ToList();
        }

        /// <summary>
        /// Updates a specific email template
        /// </summary>
        /// <param name="emailTemplate">EmailTemplate to update</param>
        public void Update(EmailTemplate emailTemplate)
        {
            this.dbClient.Update(emailTemplate);
        }
    }
}
