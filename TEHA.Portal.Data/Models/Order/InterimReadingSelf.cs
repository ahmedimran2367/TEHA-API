// <copyright file="InterimReadingSelf.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Order
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Contains interim request details
    /// </summary>
    public class InterimReadingSelf
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
        /// Gets or sets Order Id.
        /// </summary>
        /// <value>Order id. Only in case to edit Order data. otherwise null</value>
        public int? OrderId { get; set; }

        /// <summary>
        /// Gets or Sets UserMovingOut
        /// </summary>
        public UserMovingDetail UserMovingOut { get; set; }

        /// <summary>
        /// Gets or Sets UserMovingIn
        /// </summary>
        public UserMovingDetail UserMovingIn { get; set; }

        /// <summary>
        /// Gets or sets reading List
        /// </summary>
        /// <value>Reading List</value>
        public List<MeterReading> MeterReadings { get; set; }

        /// <summary>
        /// Gets or sets always be true. Terms &amp; conditions and cancellation policy
        /// </summary>
        /// <value>Always be true. Terms &amp; conditions and cancellation policy</value>
        public bool? TermsInd { get; set; }

        /// <summary>
        /// Gets or sets always be true. Bear the costs, provided that the measuring device is not defective or there is no warranty claim
        /// </summary>
        /// <value>Always be true. Bear the costs, provided that the measuring device is not defective or there is no warranty claim</value>
        public bool? CostsInd { get; set; }

        /// <summary>
        /// Gets or sets always be true. Declaration on data protection and agree to the storage of data for the period until the purpose is fulfilled
        /// </summary>
        /// <value>Always be true. Declaration on data protection and agree to the storage of data for the period until the purpose is fulfilled</value>
        public bool? DataProtectionInd { get; set; }
    }
}
