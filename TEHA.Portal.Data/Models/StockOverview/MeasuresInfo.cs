// <copyright file="MeasuresInfo.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.StockOverview
{
    /// <summary>
    /// Contains measures info
    /// </summary>
  public class MeasuresInfo
    {
        /// <summary>
        /// Gets or sets smokeDetectorCount
        /// </summary>
        public SmokeDetectorCount SmokeDetectorCount { get; set; }

        /// <summary>
        /// Gets or sets accounting pending count
        /// </summary>
        public int AccountingPendiingBuildingCount { get; set; }

        /// <summary>
        /// Gets or sets pending letters
        /// </summary>
        public int PendingFeedbackOpenLettersCount { get; set; }

        /// <summary>
        /// Gets or sets pending offer letters count
        /// </summary>
        public int PendingFeedbackOfferLettersCount { get; set; }
    }
}
