// <copyright file="ServiceContacts.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Info
{
    /// <summary>
    /// Service Contacts
    /// </summary>
    public class ServiceContacts
    {
        /// <summary>
        /// Gets or Sets General Contact Persons
        /// </summary>
        public ServiceContactInfo General { get; set; }

        /// <summary>
        /// Gets or Sets PlumbingAndMeasuringEquipment Contact Persons
        /// </summary>
        public ServiceContactInfo PlumbingAndMeasuringEquipment { get; set; }

        /// <summary>
        /// Gets or Sets Accounting Contact Persons
        /// </summary>
        public ServiceContactInfo Accounting { get; set; }

        /// <summary>
        /// Gets or Sets Readings Contact Persons
        /// </summary>
        public ServiceContactInfo Readings { get; set; }

        /// <summary>
        /// Gets or Sets OffersAndContracts Contact Persons
        /// </summary>
        public ServiceContactInfo OffersAndContracts { get; set; }

        /// <summary>
        /// Gets or Sets DrinkingWater Contact Persons
        /// </summary>
        public ServiceContactInfo DrinkingWater { get; set; }

        /// <summary>
        /// Gets or Sets EnergyPerformanceCertificate Contact Persons
        /// </summary>
        public ServiceContactInfo EnergyPerformanceCertificate { get; set; }
    }
}
