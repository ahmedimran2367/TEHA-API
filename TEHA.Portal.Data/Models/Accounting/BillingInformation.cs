// <copyright file="BillingInformation.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Accounting
{
    /// <summary>
    /// Billing Related Informations.
    /// </summary>
    public class BillingInformation
    {
        /// <summary>
        /// Gets or sets average Boiler Temperature (*C)
        /// </summary>
        public decimal? AverageBoilerTemprature { get; set; }

        /// <summary>
        /// Gets or Sets Heater
        /// </summary>
        public BillingCostConsumption Heater { get; set; }

        /// <summary>
        /// Gets or Sets HotWater
        /// </summary>
        public BillingCostConsumption HotWater { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether general electricity is true or false.
        /// </summary>
        public bool? GeneralElectricity { get; set; }

        /// <summary>
        /// Gets or sets Water Consumption
        /// </summary>
        public double? WaterConsumption { get; set; }

        /// <summary>
        /// Gets or sets Water Waste
        /// </summary>
        public double? WaterWaste { get; set; }
    }
}
