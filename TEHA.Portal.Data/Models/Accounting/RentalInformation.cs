// <copyright file="RentalInformation.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Accounting
{
    using System.ComponentModel.DataAnnotations;
    using TEHA.Portal.Data.Models.Account;

    /// <summary>
    /// Rental Information
    /// </summary>
    public class RentalInformation
    {
        /// <summary>
        /// Gets or sets rent ID
        /// </summary>
        [Required]
        public int? RentId { get; set; }

        /// <summary>
        /// Gets or sets Flat ID
        /// </summary>
        public int? FlatId { get; set; }

        /// <summary>
        /// Gets or sets Move In Date
        /// </summary>
        public string MoveInDate { get; set; }

        /// <summary>
        /// Gets or sets Move Out Date
        /// </summary>
        public string MoveOutDate { get; set; }

        /// <summary>
        /// Gets or Sets Contact
        /// </summary>
        public ContactInformation Contact { get; set; }

        /// <summary>
        /// Gets or sets rent Number
        /// </summary>
        public string RentNumber { get; set; }

        /// <summary>
        /// Gets or sets admin Description
        /// </summary>
        public string AdminDesc { get; set; }

        /// <summary>
        /// Gets or sets Teha user Number
        /// </summary>
        public string TehaUserNo { get; set; }

        /// <summary>
        /// Gets or sets admin user Number
        /// </summary>
        public string AdminUserNo { get; set; }

        /// <summary>
        /// Gets or sets Number Of People
        /// </summary>
        public int? NumberOfpeople { get; set; }

        /// <summary>
        /// Gets or sets calculation Key Heating
        /// </summary>
        public decimal? HeatingArea { get; set; }

        /// <summary>
        /// Gets or sets calculation Key Hot Water
        /// </summary>
        public decimal? HotWaterArea { get; set; }

        /// <summary>
        /// Gets or sets advance Payment
        /// </summary>
        public decimal? AdvancePayment { get; set; }

        /// <summary>
        /// Gets or Sets NameChange
        /// </summary>
        public NameChange NameChange { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether all Move Out Readings Indicator
        /// </summary>
        public bool? AllMoveOutReadingsInd { get; set; }

        /// <summary>
        /// Gets or sets FlatEmptyInd if true, flat is empty.
        /// </summary>
        public bool? FlatEmptyInd { get; set; }

        /// <summary>
        /// Gets or sets Additional Area
        /// </summary>
        public decimal? AdditionalArea { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets delete Indicator
        /// </summary>
        public bool DeleteInd { get; set; }
    }
}