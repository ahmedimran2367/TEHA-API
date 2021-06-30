// <copyright file="FlatData.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Accounting
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Contains Flat Data
    /// </summary>
    public class FlatData
    {
        /// <summary>
        /// Gets or Sets User ID
        /// </summary>
        /// <value>User ID</value>
        [Required]
        public int UserId { get; set; }

        /// <summary>
        /// Gets or Sets Property ID
        /// </summary>
        /// <value>Property ID</value>
        [Required]
        public int PropertyId { get; set; }

        /// <summary>
        /// Gets or Sets Payroll Year
        /// </summary>
        [Required]
        public int PayrollYearId { get; set; }

        /// <summary>
        /// Gets or Sets FlatUser
        /// </summary>
        public List<FlatUser> FlatUser { get; set; }

        /// <summary>
        /// Gets or sets a value Updated Date
        /// </summary>
        public string UpdatedDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Completeness Indicator is true or false.
        /// </summary>
        [Required]
        public bool? ConfirmTheCompletenessInd { get; set; }
    }
}
