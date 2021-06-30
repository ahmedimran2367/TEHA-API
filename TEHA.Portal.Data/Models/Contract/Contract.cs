// <copyright file="Contract.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Contract
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Contains contract detail.
    /// </summary>
    public class Contract
    {
        /// <summary>
        /// Gets or sets pK &amp; FK
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Gets or sets contract type
        /// </summary>
        [Required]
        public string ContractType { get; set; }

        /// <summary>
        /// Gets or sets start Time
        /// </summary>
        public string StartTime { get; set; }

        /// <summary>
        /// Gets or sets end Time
        /// </summary>
        public string EndTime { get; set; }

        /// <summary>
        /// Gets or sets type of service in contract
        /// </summary>
        [Required]
        public string ServiceType { get; set; }

        /// <summary>
        /// Gets or Sets Property
        /// </summary>
        [Required]
        public PropertyInfo Property { get; set; }
    }
}
