// <copyright file="PropertyInfo.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Contract
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Details of property for displaying and searching
    /// </summary>
    public class PropertyInfo
    {
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a unique admin number assigned to a building by TEHA
        /// </summary>
        public string TehaLgNo { get; set; }

        /// <summary>
        /// Gets or sets a unique building &amp; flat number assigned by the building management
        /// </summary>
        public string AdminLgNo { get; set; }

        /// <summary>
        /// Gets or sets street in which building exists
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// Gets or sets postcode
        /// </summary>
        public string Postcode { get; set; }

        /// <summary>
        /// Gets or sets city of the building
        /// </summary>
        public string Place { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether if true, means SEPA document is exists (Used is case of SEPA document request only)
        /// </summary>
        public bool? SepaDocumentInd { get; set; }

        /// <summary>
        /// Gets or Sets Count of open orders for this specific property (Used in case of GetOpenOrderCount endpoint only)
        /// </summary>
        public int? OpenOrdersCount { get; set; }
    }
}
