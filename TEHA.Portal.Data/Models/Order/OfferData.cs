// <copyright file="OfferData.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Order
{
    /// <summary>
    /// Contains Offers details
    /// </summary>
    public class OfferData
    {
        /// <summary>
        /// Gets or sets id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets UserId
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets tehaLgNo
        /// </summary>
        public string TehaLgNo { get; set; }

        /// <summary>
        /// Gets or sets AdminLgNo
        /// </summary>
        public string AdminLgNo { get; set; }

        /// <summary>
        /// Gets or sets Street
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// Gets or sets Postcode
        /// </summary>
        public string Postcode { get; set; }

        /// <summary>
        /// Gets or sets City
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets Type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets CreationDate
        /// </summary>
        public string CreationDate { get; set; }
    }
}
