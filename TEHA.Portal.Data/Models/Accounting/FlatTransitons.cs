// <copyright file="FlatTransitons.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Accounting
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Contains Flat User History
    /// </summary>
    public class FlatTransitons
    {
        /// <summary>
        /// Gets or sets flat ID
        /// </summary>
        [Required]
        public int? FlatId { get; set; }

        /// <summary>
        /// Gets or Sets UserMoveOut
        /// </summary>
        [Required]
        public UserMovedOut UserMovedOut { get; set; }

        /// <summary>
        /// Gets or Sets UserMoveIn
        /// </summary>
        [Required]
        public UserMovedIn UserMovedIn { get; set; }

        /// <summary>
        /// Gets or sets advance Payment
        /// </summary>
        public decimal? AdvancePayment { get; set; }

        /// <summary>
        /// Gets or sets user Moving-in / User Moving-out
        /// </summary>
        [Required]
        public string SwitchingFeePayee { get; set; }

        /// <summary>
        /// Gets or sets calculation Key Hot Water
        /// </summary>
        [Required]
        public decimal HotWaterArea { get; set; }

        /// <summary>
        /// Gets or sets calculation Key Heating
        /// </summary>
        [Required]
        public decimal HeatingArea { get; set; }
    }
}
