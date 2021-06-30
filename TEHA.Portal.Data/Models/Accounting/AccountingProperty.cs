// <copyright file="Property.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Common
{
    using Newtonsoft.Json;

    /// <summary>
    /// Details of Accounting Property for displaying and searching
    /// </summary>
    public class AccountingProperty
    {
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [JsonProperty(PropertyName = "propertyId")]
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
        /// Gets or sets billing Status
        /// </summary>
        public string BillingStatus { get; set; }

        /// <summary>
        /// Gets or sets city of the building
        /// </summary>
        public string Place { get; set; }

        /// <summary>
        /// Gets or sets billing Period
        /// </summary>
        [JsonProperty(PropertyName = "period")]
        public string BillingPeriod { get; set; }

        /// <summary>
        /// Gets or sets dTA, Data Medium Exchange
        /// </summary>
        public string Dta { get; set; }

        /// <summary>
        /// Gets or sets payroll Year Id
        /// </summary>
        public int PayrollYearId { get; set; }
    }
}
