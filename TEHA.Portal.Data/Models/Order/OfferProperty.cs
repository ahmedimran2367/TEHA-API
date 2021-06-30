// <copyright file="OfferProperty.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Order
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Contains offer property details
    /// </summary>
    public class OfferProperty
    {
        /// <summary>
        /// Gets or Sets HouseNumber
        /// </summary>
        public string HouseNumber { get; set; }

        /// <summary>
        /// Gets or sets street of the building
        /// </summary>
        /// <value>Street of the building</value>
        public string Street { get; set; }

        /// <summary>
        /// Gets or sets postal Code of the area in which the building is.
        /// </summary>
        /// <value>Postal Code of the area in which the building is.</value>
        [Required]
        public string Postcode { get; set; }

        /// <summary>
        /// Gets or sets city of the building
        /// </summary>
        /// <value>City of the building</value>
        public string Place { get; set; }

        /// <summary>
        /// Gets or sets type of the property, i.e., Resedential, Commercial or Resedential and Commercial
        /// </summary>
        /// <value>Type of the property, i.e., Resedential, Commercial or Resedential and Commercial</value>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets apparment count
        /// </summary>
        /// <value>Apparment count </value>
        public int? AppartmentCount { get; set; }

        /// <summary>
        /// Gets or sets commercial Units count in case of commercial property
        /// </summary>
        /// <value>Commercial Units count in case of commercial property</value>
        public int? CommercialUnitCount { get; set; }
    }
}
