// <copyright file="MeterDocumentInfo.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Document
{
    /// <summary>
    /// Meter Document Info Model
    /// </summary>
    public class MeterDocumentInfo
    {
        /// <summary>
        /// Gets or Sets Document Id
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Gets or Sets Flat Id
        /// </summary>
        public int? FlatId { get; set; }

        /// <summary>
        /// Gets or Sets Teha unique number assigned to user.
        /// </summary>
        public string TehaUserNo { get; set; }

        /// <summary>
        /// Gets or Sets Admin User No
        /// </summary>
        public string AdminUserNo { get; set; }

        /// <summary>
        /// Gets or Sets Tenant/User name of the flat
        /// </summary>
        public string TenantName { get; set; }

        /// <summary>
        /// Gets or Sets Document Description (Document Title)
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or Sets Category/Type of the document. accounting, plumbing etc
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or Sets meter Id
        /// </summary>
        public int? MeterId { get; set; }

        /// <summary>
        /// Gets or Sets Serial Number of meter
        /// </summary>
        public string MeterSerialNumber { get; set; }

        /// <summary>
        /// Gets or Sets Type Of Meter
        /// </summary>
        public string MeterType { get; set; }

        /// <summary>
        /// Gets or Sets location where meter is installed
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or Sets Creation Date of document
        /// </summary>
        public string CreationDate { get; set; }

        /// <summary>
        /// Gets or Sets PayrollYear Id of document
        /// </summary>
        public int? PayRollYearId { get; set; }
    }
}
