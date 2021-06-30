// <copyright file="SystemSettingBaseExceptionSettings.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Administration
{
    /// <summary>
    /// Contains app exceptions settings
    /// </summary>
    public class SystemSettingBaseExceptionSettings
    {
        /// <summary>
        /// Gets or sets enable Javascript Error Logging.
        /// </summary>
        /// <value>Enable Javascript Error Logging.</value>
        public bool? JavascriptErrors { get; set; }

        /// <summary>
        /// Gets or sets emails that will recieve email notification On Exception
        /// </summary>
        /// <value>Emails that will recieve email notification On Exception</value>
        public bool? ExceptionEmails { get; set; }
    }
}
