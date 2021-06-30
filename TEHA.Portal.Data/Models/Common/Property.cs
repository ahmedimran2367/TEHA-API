// <copyright file="Property.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Common
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Details of property for displaying and searching
    /// </summary>
    public class Property
    {
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets TEHA LG No, a unique admin number assigned to a building by TEHA
        /// </summary>
        public string TehaLgNo { get; set; }

        /// <summary>
        /// Gets or sets Admin LG No, a unique number assigned by the building management
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
        /// Gets or sets Latitude
        /// </summary>
        public decimal? Latitude { get; set; }

        /// <summary>
        /// Gets or sets Longitude
        /// </summary>
        public decimal? Longitude { get; set; }

        /// <summary>
        /// Gets or sets RWMStatus code
        /// </summary>
        public string RwmStatus { get; set; }

        /// <summary>
        /// Gets or sets billing Status
        /// </summary>
        public string BillingStatus { get; set; }

        /// <summary>
        /// Gets or sets reading Status
        /// </summary>
        public string ReadingStatus { get; set; }

        /// <summary>
        /// Gets or sets reading Flat Groups
        /// </summary>
        public string ReadingFlatGroups { get; set; }

        /// <summary>
        /// Gets or sets assembly status
        /// </summary>
        public string AssemblyStatus { get; set; }

        /// <summary>
        /// Gets or sets city of the building
        /// </summary>
        public string Place { get; set; }

        /// <summary>
        /// Gets or sets billing Period
        /// </summary>
        public string BillingPeriod { get; set; }

        /// <summary>
        /// Gets or sets dTA, Data Medium Exchange
        /// </summary>
        public string Dta { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Open letter indicator is true or false
        /// </summary>
        public bool OpenLetterInd { get; set; }

        /// <summary>
        /// Gets or Sets Flats
        /// </summary>
        public List<Flat> Flats { get; set; }

        /// <summary>
        /// Gets or Sets General Meters
        /// </summary>
        public List<Meter> GeneralMeters { get; set; }

        /// <summary>
        /// Gets or Sets Readings
        /// </summary>
        public List<Reading> Readings { get; set; }

        /// <summary>
        /// Gets or Sets Plumbings
        /// </summary>
        public List<Plumbing> Plumbings { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether DrinkingWater Indicator is true or false
        /// </summary>
        public bool DrinkingWaterInd { get; set; }
    }
}
