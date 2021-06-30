// <copyright file="SettingsResult.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Administration
{
    using System.Collections.Generic;

    /// <summary>
    /// Settings result
    /// </summary>
    public class SettingsResult
    {
        /// <summary>
        /// Gets or sets list of properties.
        /// </summary>
        public List<TEHA.Portal.Data.Models.Administration.SystemSetting> Items { get; set; }

        /// <summary>
        /// Gets or sets total records
        /// </summary>
        public int? TotalRecords { get; set; }
    }
}
