// <copyright file="BlockPeriodRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Accounting
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Block Period Request
    /// </summary>
    public class BlockPeriodRequest
    {
        /// <summary>
        /// Gets or sets user ID
        /// </summary>
        [Required]
        public int? UserId { get; set; }

        /// <summary>
        /// Gets or sets property ID
        /// </summary>
        [Required]
        public int? PropertyId { get; set; }

        /// <summary>
        /// Gets or sets payroll Year
        /// </summary>
        [Required]
        public int? PayrollYearId { get; set; }

        /// <summary>
        /// Gets or sets Cancellation Policy indicator
        /// </summary>
        [Required]
        public bool? CancellationPolicyInd { get; set; }

        /// <summary>
        /// Gets or sets Confirm the Completeness Indicator
        /// </summary>
        [Required]
        public bool? ConfirmTheCompletenessInd { get; set; }

        /// <summary>
        /// Gets or Sets Subject to Fee Indicator
        /// </summary>
        [Required]
        public bool? SubjectToFeeInd { get; set; }

        /// <summary>
        /// Gets or sets comments
        /// </summary>
        public string Comments { get; set; }
    }
}
