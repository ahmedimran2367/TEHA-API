// <copyright file="SummaryAndRelease.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Accounting
{
    /// <summary>
    /// Contains Summary And Release Info
    /// </summary>
    public class SummaryAndRelease
    {
        /// <summary>
        /// Gets or sets user Id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets property Id
        /// </summary>
        public int PropertyId { get; set; }

        /// <summary>
        /// Gets or sets payroll Year
        /// </summary>
        public int PayrollYear { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether consumption Analysis
        /// </summary>
        public bool ConsumptionAnalysis { get; set; }

        /// <summary>
        /// Gets or sets sift Charges For
        /// </summary>
        public SiftChargesFor SiftChargesFor { get; set; }

        /// <summary>
        /// Gets or sets billing Information
        /// </summary>
        public BillingInformation BillingInformation { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether use in case of GetSummaryAndReleaseInfo request.
        /// If false, mean Summary & Release of this accounting period and property has never been saved before.
        /// </summary>
        public bool AlreadySavedInd { get; set; }
    }
}