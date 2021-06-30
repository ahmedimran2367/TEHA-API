// <copyright file="PerformanceCertificate.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Order
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using TEHA.Portal.Data.Models.Common;

    /// <summary>
    /// Contains energy performance details.
    /// </summary>
    public class PerformanceCertificate
    {
        /// <summary>
        /// Gets or sets user Id to enforce authorization
        /// </summary>
        /// <value>User Id to enforce authorization</value>
        [Required]
        public int? UserId { get; set; }

        /// <summary>
        /// Gets or sets property ID
        /// </summary>
        /// <value>Property ID</value>
        [Required]
        public int? PropertyId { get; set; }

        /// <summary>
        /// Gets or sets Order Id.
        /// </summary>
        /// <value>Order id. Only in case to edit Order data. otherwise null</value>
        public int? OrderId { get; set; }

        /// <summary>
        /// Gets or sets building Type
        /// </summary>
        /// <value>Building Type</value>
        [Required]
        public string BuildingType { get; set; }

        /// <summary>
        /// Gets or sets year of construction of the building
        /// </summary>
        /// <value>Year of construction of the building</value>
        public string YearOfConstruction { get; set; }

        /// <summary>
        /// Gets or sets monument Protection?  Yes/No
        /// </summary>
        /// <value>Monument Protection?  Yes/No</value>
        public bool? MonumentProtectionInd { get; set; }

        /// <summary>
        /// Gets or sets amount of Hot Water used.
        /// </summary>
        /// <value>Amount of Hot Water used.</value>
        public decimal? AmountOfHotWaterUsed { get; set; }

        /// <summary>
        /// Gets or sets measurement takes place via WWZ? Yes/No
        /// </summary>
        /// <value>Measurement takes place via WWZ? Yes/No</value>
        public bool? MeasurmentWithWWZInd { get; set; }

        /// <summary>
        /// Gets or sets year of Renewal of Heating
        /// </summary>
        /// <value>Year of Renewal of Heating</value>
        public string RenewalOfHeating { get; set; }

        /// <summary>
        /// Gets or Sets year of heating
        /// </summary>
        /// <value>Year of heating of the building</value>
        public string YearOfHeating { get; set; }

        /// <summary>
        /// Gets or sets is building cooled? Yes/No
        /// </summary>
        /// <value>Is building cooled? Yes/No</value>
        public bool? BuildingCooledInd { get; set; }

        /// <summary>
        /// Gets or sets heatable usable area in sq meter.
        /// </summary>
        /// <value>Heatable usable area in sq meter.</value>
        public float? HeatableUsableArea { get; set; }

        /// <summary>
        /// Gets or sets number of residential units
        /// </summary>
        /// <value>Number of residential units</value>
        public int? NoOfResidentialUnits { get; set; }

        /// <summary>
        /// Gets or sets does building have a basement? Yes/No/Partial
        /// </summary>
        /// <value>Does building have a basement? Yes/No/Partial</value>
        public string BuildingWithBasement { get; set; }

        /// <summary>
        /// Gets or sets is the basement heated? Yes/No
        /// </summary>
        /// <value>Is the basement heated? Yes/No</value>
        public bool? BasementHeatedInd { get; set; }

        /// <summary>
        /// Gets or sets type of heaing system
        /// </summary>
        /// <value>Type of heaing system</value>
        public string HeatingSystem { get; set; }

        /// <summary>
        /// Gets or sets energy Source
        /// </summary>
        /// <value>Energy Source</value>
        public string EnergySource { get; set; }

        /// <summary>
        /// Gets or sets facade Insulation Year
        /// </summary>
        /// <value>Facade Insulation Year</value>
        public string FacadeInsulationYear { get; set; }

        /// <summary>
        /// Gets or sets roof Insulation Year
        /// </summary>
        /// <value>Roof Insulation Year</value>
        public string RoofInsulationYear { get; set; }

        /// <summary>
        /// Gets or sets solar system installation year
        /// </summary>
        /// <value>Solar system installation year</value>
        public string SolarSystemYear { get; set; }

        /// <summary>
        /// Gets or sets last 3 consecutive years record for Thermal Energy Usage
        /// </summary>
        /// <value>Last 3 consecutive years record for Thermal Energy Usage</value>
        public List<CertificateThermalEnergy> ThermalEnergy { get; set; }

        /// <summary>
        /// Gets or sets last 3 consecutive years record for Hot Water Usage
        /// </summary>
        /// <value>Last 3 consecutive years record for Hot Water Usage</value>
        public List<CertificateHotWaterDetail> HotWater { get; set; }

        /// <summary>
        /// Gets or sets hot water generation included? Yes/No
        /// </summary>
        /// <value>Hot water generation included? Yes/No</value>
        public bool? HotWaterIncludedInd { get; set; }

        /// <summary>
        /// Gets or sets Renovation Windows Year
        /// </summary>
        /// <value>Renovation Windows Year</value>
        public string RenovationWindowsYear { get; set; }

        /// <summary>
        /// Gets or sets Insulation Ceiling Year
        /// </summary>
        /// <value>Insulation Ceiling Year</value>
        public string InsulationCeilingYear { get; set; }

        /// <summary>
        /// Gets or sets Hot Water Temperature
        /// </summary>
        /// <value>Hot Water Temperature</value>
        public string HotWaterTemperature { get; set; }

        /// <summary>
        /// Gets or sets Images File Contents
        /// </summary>
        public List<FileContentResponse> ImagesContents { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets Air Conditioner Ind
        /// </summary>
        /// <value>Air Conditioner Ind</value>
        public bool AirConditionerInd { get; set; }

        /// <summary>
        /// Gets or sets Next Service Date
        /// </summary>
        /// <value>Next Service Date</value>
        public string NextServiceDate { get; set; }

        /// <summary>
        /// Gets or Sets a value indicating whether Terms indicator is true or false
        /// </summary>
        public bool TermsInd { get; set; }

        /// <summary>
        /// Gets or Sets a value indicating whether Costs Indicator is true or false
        /// </summary>
        public bool CostsInd { get; set; }

        /// <summary>
        /// Gets or Sets a value indicating whether Data Protection Indicator is true or false
        /// </summary>
        public bool DataProtectionInd { get; set; }
    }
}
