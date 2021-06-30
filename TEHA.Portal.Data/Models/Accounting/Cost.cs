// <copyright file="Cost.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Accounting
{
    using System.Collections.Generic;

    /// <summary>
    /// Contains Costing Detail by types
    /// </summary>
    public class Cost
    {
        /// <summary>
        /// Gets or Sets Energy
        /// </summary>
        public List<CostConcept> Energy { get; set; }

        /// <summary>
        /// Gets or sets list of heating cost.
        /// </summary>
        public List<CostConcept> Heating { get; set; }

        /// <summary>
        /// Gets or Sets Heating Additional cost list
        /// </summary>
        public List<CostConcept> HeatingAdditional { get; set; }

        /// <summary>
        /// Gets or sets list of Hot Water additional cost.
        /// </summary>
        public List<CostConcept> HotWaterAdditional { get; set; }

        /// <summary>
        /// Gets or sets list of Additional costs.
        /// </summary>
        public List<AdditionalCost> AdditionalCosts { get; set; }
    }
}
