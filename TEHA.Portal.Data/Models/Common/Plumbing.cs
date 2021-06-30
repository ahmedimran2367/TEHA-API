// <copyright file="Plumbing.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Common
{
    using System;

    /// <summary>
    /// Flat group Plumbing
    /// </summary>
    public class Plumbing
    {
        /// <summary>
        /// Gets or Sets Plumbing Id
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Gets or Sets PropertyId
        /// </summary>
        public int? PropertyId { get; set; }

        /// <summary>
        /// Gets or Sets FlatGroupId
        /// </summary>
        public int? FlatgroupId { get; set; }

        /// <summary>
        /// Gets or Sets FlatGroupDesc
        /// </summary>
        public string FlatgroupDesc { get; set; }

        /// <summary>
        /// Gets or Sets TaskId
        /// </summary>
        public int? TaskId { get; set; }

        /// <summary>
        /// Gets or Sets NumAt
        /// </summary>
        public int? NumAt { get; set; }

        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        public string Type { get; set; }

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
        /// Gets or Sets LockedDate
        /// </summary>
        public DateTime? LockedDate { get; set; }

        /// <summary>
        /// Gets or Sets DocumStatus
        /// </summary>
        public string DocumStatus { get; set; }

        /// <summary>
        /// Gets or Sets Status
        /// </summary>
        public string Status { get; set; }
    }
}
