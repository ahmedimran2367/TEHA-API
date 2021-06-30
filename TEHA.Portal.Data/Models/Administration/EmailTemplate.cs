// <copyright file="EmailTemplate.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Administration
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using BITLogix.Core.Couchbase;

    /// <summary>
    /// Contains Email template details
    /// </summary>
    [DocumentType(nameof(EmailTemplate))]
    [ElementId("Id")]
    public class EmailTemplate : IEntityBase
    {
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets Id Code, which is used for easy access
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets name of template
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets type of document
        /// </summary>
        [Required]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets subject
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Gets or sets body html
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Gets or Sets Fields
        /// </summary>
        public List<EmailField> Fields { get; set; }

        /// <summary>
        /// Gets or sets Active indicator
        /// </summary>
        public bool? ActiveInd { get; set; }
    }
}
