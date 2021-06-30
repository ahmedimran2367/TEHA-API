// <copyright file="DefaultData.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Administration
{
    /// <summary>
    /// Contains app default data
    /// </summary>
    public class DefaultData
    {
        /// <summary>
        /// Gets or Sets SystemSettings
        /// </summary>
        public SystemSettingBase SystemSettings { get; set; }

        /// <summary>
        /// Gets or Sets LookUps
        /// </summary>
        public LookupBase LookUps { get; set; }
    }
}
