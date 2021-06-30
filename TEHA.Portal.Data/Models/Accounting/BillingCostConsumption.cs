// <copyright file="BillingCostConsumption.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Accounting
{
    /// <summary>
    /// Contains cost and consuptions of energy.
    /// </summary>
    public class BillingCostConsumption
    {
        /// <summary>
        /// Gets or sets basic Cost percentage
        /// </summary>
        public decimal BasicCost { get; set; }

        /// <summary>
        /// Gets or sets consumption Cost percentage
        /// </summary>
        public decimal Consumption { get; set; }
    }
}
