// <copyright file="OrderResponse.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Order
{
    using System.Collections.Generic;

    /// <summary>
    /// Contains order response
    /// </summary>
    public class OrderResponse
    {
        /// <summary>
        /// Gets or Sets Items
        /// </summary>
        public List<Order> Items { get; set; }

        /// <summary>
        /// Gets or sets current pages
        /// </summary>
        /// <value>Current pages</value>
        public int? CurrentPage { get; set; }

        /// <summary>
        /// Gets or sets total records
        /// </summary>
        /// <value>Total records</value>
        public int? TotalRecords { get; set; }
    }
}
