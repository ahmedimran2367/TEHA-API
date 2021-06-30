// <copyright file="CostData.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Accounting
{
    /// <summary>
    /// Contains Accouting informations.
    /// </summary>
    public class CostData
    {
        /// <summary>
        /// Gets or sets user ID
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets property ID
        /// </summary>
        public int PropertyId { get; set; }

        /// <summary>
        /// Gets or sets payroll Year
        /// </summary>
        public int PayrollYear { get; set; }

        /// <summary>
        /// Gets or Sets Cost
        /// </summary>
        public Cost Cost { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets i have read and understood the terms and conditions and the cancellation policy.
        /// </summary>
        public bool CancellationPolicyInd { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets i hereby confirm the completeness of the data.
        /// </summary>
        public bool ConfirmTheCompletenessInd { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets the order of the individual cost categories is subject to a fee. The prices can be taken from the price list.
        /// </summary>
        public bool SubjectToFeeInd { get; set; }

        /// <summary>
        /// Gets or sets Updated Date
        /// </summary>
        public string UpdatedDate { get; set; }
    }
}
