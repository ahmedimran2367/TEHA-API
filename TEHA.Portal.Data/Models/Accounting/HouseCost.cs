// <copyright file="HouseCost.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Accounting
{
    using System.Collections.Generic;

    /// <summary>
    /// Contains cost of Housing
    /// </summary>
    public class HouseCost
    {
        /// <summary>
        /// Gets or sets list of cost detail
        /// </summary>
        public List<CostDetail> Items { get; set; }

        /// <summary>
        /// Gets or sets general Electricity (Including Heating Current) - YES/NO
        /// </summary>
        public bool? GeneralElectricityInd { get; set; }

        /// <summary>
        /// Gets or sets water Consumption [m³]
        /// </summary>
        public decimal? WaterConsumption { get; set; }

        /// <summary>
        /// Gets or sets water/Waste Water [€ / m³]
        /// </summary>
        public decimal? WasteWater { get; set; }
    }
}
