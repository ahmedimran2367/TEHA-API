// <copyright file="FlatUser.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Accounting
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Contains Flat User data
    /// </summary>
    public class FlatUser
    {
        /// <summary>
        /// Gets or Sets Flat ID
        /// </summary>
        [Required]
        public int? FlatId { get; set; }

        /// <summary>
        /// Gets or sets tEHA User Numnber
        /// </summary>
        public string TehaUserNo { get; set; }

        /// <summary>
        /// Gets or sets admin User Number
        /// </summary>
        public string AdminUserNo { get; set; }

        /// <summary>
        /// Gets or Sets Rentals
        /// </summary>
        public List<RentalInformation> Rentals { get; set; }

        /// <summary>
        /// Gets or Sets Owners
        /// </summary>
        public List<OwnerInformation> Owners { get; set; }
    }
}