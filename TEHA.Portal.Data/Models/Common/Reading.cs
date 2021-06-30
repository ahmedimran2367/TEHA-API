// <copyright file="Reading.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Common
{
    using System;

    /// <summary>
    /// Flat Group Reading
    /// </summary>
    public class Reading
    {
        /// <summary>
        /// Gets or Sets reading Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets PropertyId
        /// </summary>
        public int PropertyId { get; set; }

        /// <summary>
        /// Gets or Sets Flat Group Id
        /// </summary>
        public int? FlatgroupId { get; set; }

        /// <summary>
        /// Gets or Sets Flat Group Desc
        /// </summary>
        public string FlatgroupDesc { get; set; }

        /// <summary>
        /// Gets or Sets Billing Period Oid
        /// </summary>
        public int? BillingPeriodOid { get; set; }

        /// <summary>
        /// Gets or Sets Effective Date
        /// </summary>
        public DateTime? EffectiveDate { get; set; }

        /// <summary>
        /// Gets or Sets TaskDate
        /// </summary>
        public DateTime? TaskDate { get; set; }

        /// <summary>
        /// Gets or Sets InitHour
        /// </summary>
        public string InitHour { get; set; }

        /// <summary>
        /// Gets or Sets EndHour
        /// </summary>
        public string EndHour { get; set; }

        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or Sets FinishDate
        /// </summary>
        public DateTime? FinishDate { get; set; }

        /// <summary>
        /// Gets or Sets ImportDate
        /// </summary>
        public DateTime? ImportDate { get; set; }

        /// <summary>
        /// Gets or Sets Status
        /// </summary>
        public string Status { get; set; }
    }
}
