// <copyright file="MeterStatus.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.StockOverview
{
    /// <summary>
    /// Contains Meter Status
    /// </summary>
    public class MeterStatus
    {
        /// <summary>
        /// Gets or sets meter Type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets count.
        /// </summary>
        public decimal? Count { get; set; }

        /// <summary>
        /// Gets or sets status of meter
        /// </summary>
        public string Status { get; set; }
    }
}
