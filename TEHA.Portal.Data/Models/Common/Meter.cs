// <copyright file="Meter.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Common
{
    /// <summary>
    /// Details of meters for displaying and searching
    /// </summary>
    public class Meter
    {
        /// <summary>
        /// Gets or sets Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets TehaLgNo
        /// </summary>
        public string TehaLgNo { get; set; }

        /// <summary>
        /// Gets or sets AdminLgNo
        /// </summary>
        public string AdminLgNo { get; set; }

        /// <summary>
        /// Gets or sets TehaUserNo
        /// </summary>
        public string TehaUserNo { get; set; }

        /// <summary>
        /// Gets or sets AdminUserNo
        /// </summary>
        public string AdminUserNo { get; set; }

        /// <summary>
        /// Gets or sets flat id
        /// </summary>
        public int? FlatId { get; set; }

        /// <summary>
        /// Gets or Sets TenantName
        /// </summary>
        public string TenantName { get; set; }

        /// <summary>
        /// Gets or sets type of meter
        /// </summary>
        public string MeterType { get; set; }

        /// <summary>
        /// Gets or sets Desc of meter type
        /// </summary>
        public string MeterTypeDesc { get; set; }

        /// <summary>
        /// Gets or sets serial number of meter
        /// </summary>
        public string SerialNumber { get; set; }

        /// <summary>
        /// Gets or sets room in which the meter is placed
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets RWM status code.
        /// </summary>
        public string RwmStatus { get; set; }

        /// <summary>
        /// Gets or sets Meter status code.
        /// </summary>
        public string MeterStatus { get; set; }

        /// <summary>
        /// Gets or sets plumbing Status
        /// </summary>
        public string PlumbingStatus { get; set; }

        /// <summary>
        /// Gets or sets Test Type. Applies to smoke detector only.
        /// </summary>
        public string TestType { get; set; }

        /// <summary>
        /// Gets or sets Test Date. Applies to smoke detector only.
        /// </summary>
        public string TestDate { get; set; }

        /// <summary>
        /// Gets or sets comments or notes if any
        /// </summary>
        public string Comments { get; set; }
    }
}
