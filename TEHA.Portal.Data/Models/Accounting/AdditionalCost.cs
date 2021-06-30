// <copyright file="AdditionalCost.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Accounting
{
    using System.Collections.Generic;

    /// <summary>
    /// Contains Energy Cost
    /// </summary>
    public class AdditionalCost
    {
        /// <summary>
        /// Gets or sets contains list of energy cost
        /// </summary>
        public List<CostConcept> Items { get; set; }

        /// <summary>
        /// Gets or sets opening Balance (Quantity)
        /// </summary>
        public decimal? WaterConsumption { get; set; }

        /// <summary>
        /// Gets or sets closing Stock (Quantity)
        /// </summary>
        public decimal? Wastewater { get; set; }

        /// <summary>
        /// Gets or sets opening Balance (Gross Amount)
        /// </summary>
        public bool? GeneralElectricityInd { get; set; }
    }
}
