// <copyright file="Summary.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.StockOverview
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Dashboard data for displaying on landing page of stock overview
    /// </summary>
    public class Summary
    {
        /// <summary>
        /// Gets or sets buildings Count
        /// </summary>
        [Required]
        public decimal BuildingsCount { get; set; }

        /// <summary>
        /// Gets or sets flats Count
        /// </summary>
        [Required]
        public decimal FlatsCount { get; set; }

        /// <summary>
        /// Gets or sets meters Count
        /// </summary>
        [Required]
        public decimal MetersCount { get; set; }

        /// <summary>
        /// Gets or sets Pending Accounting Buildings Count
        /// </summary>
        public decimal PendingAccountingBuildingsCount { get; set; }

        /// <summary>
        /// Gets or sets Pending Feedback Open Letters Count
        /// </summary>
        public decimal PendingFeedbackOpenLettersCount { get; set; }

        /// <summary>
        /// Gets or sets Pending Feedback Open Offers Count
        /// </summary>
        public decimal PendingFeedbackOpenOffersCount { get; set; }

        /// <summary>
        /// Gets or sets Defected Smoke Detectors Buildings Count
        /// </summary>
        public decimal DefectedSmokeDetectorsBuildingsCount { get; set; }
    }
}
