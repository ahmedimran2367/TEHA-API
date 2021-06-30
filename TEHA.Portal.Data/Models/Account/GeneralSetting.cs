// <copyright file="GeneralSetting.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Account
{
    /// <summary>
    /// Contains all properties for general settings data collection and data display
    /// </summary>
    public class GeneralSetting
    {
        /// <summary>
        /// Gets or Sets NewInvoice object
        /// </summary>
        public GeneralSettingDetail Invoice { get; set; }

        /// <summary>
        /// Gets or Sets AccountingDocument object
        /// </summary>
        public GeneralSettingDetail AccountingDocument { get; set; }

        /// <summary>
        /// Gets or Sets Readingdates object
        /// </summary>
        public GeneralSettingDetail Readingdates { get; set; }

        /// <summary>
        /// Gets or Sets ReadingAttempt object
        /// </summary>
        public GeneralSettingDetail ReadingAttempt { get; set; }

        /// <summary>
        /// Gets or Sets PlumbingDates object
        /// </summary>
        public GeneralSettingDetail PlumbingDates { get; set; }

        /// <summary>
        /// Gets or Sets PlumbingReports object
        /// </summary>
        public GeneralSettingDetail PlumbingReports { get; set; }

        /// <summary>
        /// Gets or Sets RemainingLetters object
        /// </summary>
        public GeneralSettingDetail RemainingLetters { get; set; }

        /// <summary>
        /// Gets or sets DefectSmokeDetectors
        /// </summary>
        public string DefectSmokeDetectors { get; set; }

        /// <summary>
        /// Gets or sets userNotAvailable
        /// </summary>
        public string UserNotAvailable { get; set; }

        /// <summary>
        /// Gets or Sets NewInvoice
        /// </summary>
        public GeneralSettingDetail NewInvoice { get; set; }
    }
}
