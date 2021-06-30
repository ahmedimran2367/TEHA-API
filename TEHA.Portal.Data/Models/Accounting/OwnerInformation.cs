// <copyright file="OwnerInformation.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Accounting
{
    using System.ComponentModel.DataAnnotations;
    using TEHA.Portal.Data.Models.Account;

    /// <summary>
    /// Owner Information
    /// </summary>
    public class OwnerInformation
    {
        /// <summary>
        /// Gets or sets owner ID
        /// </summary>
        [Required]
        public int? OwnerId { get; set; }

        /// <summary>
        /// Gets or sets Property ID
        /// </summary>
        public int? PropertyId { get; set; }

        /// <summary>
        /// Gets or sets Flat ID
        /// </summary>
        public int? FlatId { get; set; }

        /// <summary>
        /// Gets or sets Payroll Year ID
        /// </summary>
        public int? PayrollYearId { get; set; }

        /// <summary>
        /// Gets or sets start Date/ Move in Date
        /// </summary>
        public string StartDate { get; set; }

        /// <summary>
        /// Gets or sets end Date/ Move Out Date
        /// </summary>
        public string EndDate { get; set; }

        /// <summary>
        /// Gets or sets admin Number
        /// </summary>
        public string AdminNumber { get; set; }

        /// <summary>
        /// Gets or Sets Contact
        /// </summary>
        public ContactInformation Contact { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets delete Indicator
        /// </summary>
        public bool DeleteInd { get; set; }
    }
}