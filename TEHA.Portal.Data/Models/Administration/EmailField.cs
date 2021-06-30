// <copyright file="EmailField.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Administration
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Contains Email field details
    /// </summary>
    public class EmailField
    {
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [Required]
        public int? Id { get; set; }

        /// <summary>
        /// Gets or sets email template name
        /// </summary>
        [Required]
        public string Name { get; set; }
    }
}
