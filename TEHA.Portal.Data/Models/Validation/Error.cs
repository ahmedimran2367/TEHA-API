// <copyright file="Error.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Validation
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Contains Error
    /// </summary>
    public class Error
    {
        /// <summary>
        /// Gets or sets error Code
        /// </summary>
        [Required]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets description of Error
        /// </summary>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets severity of Error
        /// </summary>
        [Required]
        public string Severity { get; set; }
    }
}
