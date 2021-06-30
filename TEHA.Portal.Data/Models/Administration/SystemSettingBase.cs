// <copyright file="SystemSettingBase.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Administration
{
    /// <summary>
    /// Contains app settings
    /// </summary>
    public class SystemSettingBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SystemSettingBase"/> class.
        /// </summary>
        public SystemSettingBase()
        {
            this.EmailSetting = new SystemSettingBaseEmailSetting();
            this.ExceptionSettings = new SystemSettingBaseExceptionSettings();
            this.Url = new SystemSettingBaseUrl();
        }

        /// <summary>
        /// Gets or sets grid Page Size
        /// </summary>
        /// <value>Grid Page Size  </value>
        public int? GridPageSize { get; set; }

        /// <summary>
        /// Gets or sets grid Max Record
        /// </summary>
        /// <value>Grid Max Record</value>
        public int? MaxRecord { get; set; }

        /// <summary>
        /// Gets or Sets ExceptionSettings
        /// </summary>
        public SystemSettingBaseExceptionSettings ExceptionSettings { get; set; }

        /// <summary>
        /// Gets or Sets EmailSetting
        /// </summary>
        public SystemSettingBaseEmailSetting EmailSetting { get; set; }

        /// <summary>
        /// Gets or Sets Url
        /// </summary>
        public SystemSettingBaseUrl Url { get; set; }

        /// <summary>
        /// Gets or Sets Data Exchange Url
        /// </summary>
        public string DataExchangeUrl { get; set; }
    }
}
