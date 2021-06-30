// <copyright file="Order.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Order
{
    /// <summary>
    /// Contains order overview
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Gets or sets order ID
        /// </summary>
        /// <value>Order ID</value>
        public int? Id { get; set; }

        /// <summary>
        /// Gets or sets user Id
        /// </summary>
        public int? UserId { get; set; }

        /// <summary>
        /// Gets or sets property Id
        /// </summary>
        public int? PropertyId { get; set; }

        /// <summary>
        /// Gets or sets flat Id
        /// </summary>
        public int? FlatId { get; set; }

        /// <summary>
        /// Gets or sets teha Lg No
        /// </summary>
        /// <value>Teha Lg No</value>
        public string TehaLgNo { get; set; }

        /// <summary>
        /// Gets or sets admin Lg No
        /// </summary>
        /// <value>Admin Lg No</value>
        public string AdminLgNo { get; set; }

        /// <summary>
        /// Gets or sets teha User No
        /// </summary>
        /// <value>Teha User No</value>
        public string TehaUserNo { get; set; }

        /// <summary>
        /// Gets or sets admin User No
        /// </summary>
        /// <value>Admin User No</value>
        public string AdminUserNo { get; set; }

        /// <summary>
        /// Gets or sets contains order type
        /// </summary>
        /// <value>Contains order type</value>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets status
        /// </summary>
        /// <value>status </value>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets order Description
        /// </summary>
        /// <value>Description</value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets Creation Date
        /// </summary>
        /// <value>Creation Date</value>
        public string CreationDate { get; set; }
    }
}
