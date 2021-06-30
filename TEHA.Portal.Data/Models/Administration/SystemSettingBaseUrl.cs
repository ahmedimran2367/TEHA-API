// <copyright file="SystemSettingBaseUrl.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Administration
{
    /// <summary>
    /// Contains system url settings
    /// </summary>
    public class SystemSettingBaseUrl
    {
        /// <summary>
        /// Gets or sets api base url
        /// </summary>
        /// <value>Api base url</value>
        public string Api { get; set; }

        /// <summary>
        /// Gets or sets web Base URL
        /// </summary>
        /// <value>Web Base URL</value>
        public string Web { get; set; }

        /// <summary>
        /// Gets or sets tEHA API base url
        /// </summary>
        /// <value>TEHA API base url</value>
        public string TehaApi { get; set; }
    }
}
