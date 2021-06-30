// <copyright file="AccountingInterimReadingSelf.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Order
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Contains accounting interim request details
    /// </summary>
    public class AccountingInterimReadingSelf
    {
        /// <summary>
        /// Gets or sets user ID
        /// </summary>
        /// <value>User ID</value>
        [Required]
        public int? UserId { get; set; }

        /// <summary>
        /// Gets or sets property ID to locate Property.
        /// </summary>
        /// <value>Property ID to locate Property.</value>
        [Required]
        public int? PropertyId { get; set; }

        /// <summary>
        /// Gets or sets flat ID to locate Flat.
        /// </summary>
        /// <value>Flat ID to locate Flat.</value>
        [Required]
        public int? FlatId { get; set; }

        /// <summary>
        /// Gets or sets reading List
        /// </summary>
        /// <value>Reading List</value>
        public List<AccountingMeterReading> MeterReadings { get; set; }

        /// <summary>
        /// Gets or sets Date.
        /// </summary>
        /// <value>Date.</value>
        public string Date { get; set; }
    }
}
