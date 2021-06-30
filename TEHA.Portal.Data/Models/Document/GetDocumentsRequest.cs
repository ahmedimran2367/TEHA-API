// <copyright file="GetDocumentsRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Document
{
    /// <summary>
    /// Get Documents Request Model
    /// </summary>
    public class GetDocumentsRequest
    {
        /// <summary>
        /// Gets or Sets UserId
        /// </summary>
        public int? UserId { get; set; }

        /// <summary>
        /// Gets or Sets Property Id
        /// </summary>
        public int? PropertyId { get; set; }

        /// <summary>
        /// Gets or Sets Payroll year for which the document(s) is/are requested
        /// </summary>
        public int? PayrollYear { get; set; }

        /// <summary>
        /// Gets or Sets Type of the document required. Accounting - A Reading - R Plumbing - P Energy Certificates - E Drinking Water Samples - D All Documents - ALL
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or Sets a value indicating whether PropertyLevelInd is true or false
        /// </summary>
        /// <value>True if property level documents are requested</value>
        public bool? PropertyLevelInd { get; set; }

        /// <summary>
        /// Gets or Sets a value indicating whether Flat level ind is true or false
        /// </summary>
        /// <value>true if Flat level documents are requested</value>
        public bool? FlatLevelInd { get; set; }

        /// <summary>
        /// Gets or Sets a value indicating whether MeterLevelInd is true or false
        /// </summary>
        /// <value>True if meter level documents are requested</value>
        public bool? MeterLevelInd { get; set; }
    }
}
