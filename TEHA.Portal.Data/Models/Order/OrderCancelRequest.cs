// <copyright file="OrderCancelRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Order
{
    /// <summary>
    /// Order Cancel Request Model
    /// </summary>
    public class OrderCancelRequest
    {
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        /// <value>OrderId</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets User Id
        /// </summary>
        public int UserId { get; set; }
    }
}
