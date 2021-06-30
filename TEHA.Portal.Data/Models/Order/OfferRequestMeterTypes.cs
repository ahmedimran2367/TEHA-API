// <copyright file="OfferRequestMeterTypes.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Order
{
    /// <summary>
    /// Meter count with type
    /// </summary>
    public class OfferRequestMeterTypes
    {
        /// <summary>
        /// Gets or sets type of meter
        /// </summary>
        /// <value>Type of meter</value>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets count of meter
        /// </summary>
        /// <value>Count of meter</value>
        public int? Count { get; set; }
    }
}
