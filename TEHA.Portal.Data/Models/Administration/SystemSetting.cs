// <copyright file="SystemSetting.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Administration
{
    using System.ComponentModel.DataAnnotations;
    using BITLogix.Core.Couchbase;

    /// <summary>
    /// Contains app settings
    /// </summary>
    [DocumentType(nameof(SystemSetting))]
    [ElementId("Id")]
    public class SystemSetting : IEntityBase
    {
        /// <summary>
        /// Gets or sets system setting ID
        /// </summary>
        /// <value>System setting ID</value>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets code, Used for easy access
        /// </summary>
        /// <value>Code, Used for easy access</value>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets setting Category
        /// </summary>
        /// <value>Setting Category</value>
        public string SettingCategory { get; set; }

        /// <summary>
        /// Gets or sets diaplay Name
        /// </summary>
        /// <value>Diaplay Name</value>
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets data or value
        /// </summary>
        /// <value>data or value</value>
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets description
        /// </summary>
        /// <value>Description</value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets regular Expression
        /// </summary>
        /// <value>Regular Expression</value>
        public string RegExp { get; set; }

        /// <summary>
        /// Gets or sets type of document
        /// </summary>
        [Required]
        public string Type { get; set; }
    }
}
