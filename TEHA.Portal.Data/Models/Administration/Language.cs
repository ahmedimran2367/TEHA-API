// <copyright file="Language.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Administration
{
    using System.ComponentModel.DataAnnotations;
    using BITLogix.Core.Couchbase;

    /// <summary>
    /// Contains language translation
    /// </summary>
    [DocumentType(nameof(Language))]
    [ElementId("Id")]
    public class Language : IEntityBase
    {
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets code or label
        /// </summary>
        /// <value>Code or label</value>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets english description
        /// </summary>
        /// <value>English description</value>
        public string English { get; set; }

        /// <summary>
        /// Gets or sets german description
        /// </summary>
        /// <value>German description</value>
        public string German { get; set; }

        /// <summary>
        /// Gets or sets Type description
        /// </summary>
        /// <value>Type description</value>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets Type description
        /// </summary>
        /// <value>Type description</value>
        public string Category { get; set; }
    }
}
