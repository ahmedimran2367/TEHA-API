// <copyright file="Info.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Dashboard
{
    using System.Collections.Generic;

    /// <summary>
    /// Contains Dashboard Info
    /// </summary>
    public class Info
    {
        /// <summary>
        /// Gets or sets this widget will display the updates about the following;  Upcoming Change in Laws  Important Company Information  Change in any company policy
        /// </summary>
        public List<News> News { get; set; }

        /// <summary>
        /// Gets or Sets SmokeDetectorCount
        /// </summary>
        public SmokeDetectorCount SmokeDetectorCount { get; set; }

        /// <summary>
        /// Gets or Sets OrdersCount
        /// </summary>
        public OrdersCount OrdersCount { get; set; }

        /// <summary>
        /// Gets or Sets ReadingCount
        /// </summary>
        public ReadingCount ReadingCount { get; set; }

        /// <summary>
        /// Gets or sets count of offers with pending feedback
        /// </summary>
        public int? OfferRequestCount { get; set; }

        /// <summary>
        /// Gets or sets PendingInvoiceCount
        /// </summary>
        public int? PendingInvoiceCount { get; set; }

        /// <summary>
        /// Gets or sets FinalizedAccountingCount
        /// </summary>
        public int? FinalizedAccountingCount { get; set; }

        /// <summary>
        /// Gets or sets inProgressAccountingCount
        /// </summary>
        public int? InProgressAccountingCount { get; set; }

        /// <summary>
        /// Gets or sets DataMissingAccountingCount
        /// </summary>
        public int? DataMissingAccountingCount { get; set; }
    }
}