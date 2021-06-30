// <copyright file="PayRollYear.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Info
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// PayRoll Year
    /// </summary>
    public class PayrollYear
    {
        /// <summary>
        /// Gets or sets PK
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets from date
        /// </summary>
        [Required]
        public string From { get; set; }

        /// <summary>
        /// Gets or sets to Date
        /// </summary>
        [Required]
        public string To { get; set; }
    }
}
