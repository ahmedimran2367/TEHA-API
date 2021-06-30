// <copyright file="EnergyCostQuantity.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Accounting
{
    /// <summary>
    /// Contains Quantities of energy cost
    /// </summary>
    public class EnergyCostQuantity
    {
        /// <summary>
        /// Gets or Sets Opening Quantity
        /// </summary>
        public decimal? OpeningQuantity { get; set; }

        /// <summary>
        /// Gets or Sets Closing Quantity
        /// </summary>
        public decimal? ClosingQuantity { get; set; }

        /// <summary>
        /// Gets or Sets Opening Amount
        /// </summary>
        public decimal? OpeningAmount { get; set; }
    }
}
