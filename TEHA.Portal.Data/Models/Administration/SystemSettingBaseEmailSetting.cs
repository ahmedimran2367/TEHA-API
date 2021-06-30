// <copyright file="SystemSettingBaseEmailSetting.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Administration
{
    /// <summary>
    /// Contains app email settings
    /// </summary>
    public class SystemSettingBaseEmailSetting
    {
        /// <summary>
        /// Gets or sets from
        /// </summary>
        /// <value>From</value>
        public string From { get; set; }

        /// <summary>
        /// Gets or sets username of SMTP server
        /// </summary>
        /// <value>Username of SMTP server</value>
        public string SmtpUsername { get; set; }

        /// <summary>
        /// Gets or sets password of SMTP server
        /// </summary>
        /// <value>Password of SMTP server</value>
        public string SmtpPassword { get; set; }

        /// <summary>
        /// Gets or sets port of SMTP server
        /// </summary>
        /// <value>Port of SMTP server </value>
        public int? SmtpPort { get; set; }

        /// <summary>
        /// Gets or sets host anme of SMTP server
        /// </summary>
        /// <value>Host anme of SMTP server</value>
        public string SmtpServer { get; set; }
    }
}
