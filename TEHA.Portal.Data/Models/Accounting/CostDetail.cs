// <copyright file="CostDetail.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Accounting
{
    using System.Collections.Generic;
    using TEHA.Portal.Data.Models.Common;

    /// <summary>
    /// Contains costing details
    /// </summary>
    public class CostDetail
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CostDetail"/> class.
        /// contains InvoiceFileContents
        /// </summary>
        public CostDetail()
        {
            this.InvoiceFileContents = new List<FileContentResponse>();
        }

        /// <summary>
        /// Gets or sets cost Id
        /// </summary>
        public int CostId { get; set; }

        /// <summary>
        /// Gets or sets measurement Unit
        /// </summary>
        public string Units { get; set; }

        /// <summary>
        /// Gets or sets amount Netto
        /// </summary>
        public decimal? AmountNetto { get; set; }

        /// <summary>
        /// Gets or sets Vat Percentage
        /// </summary>
        public double? Vat { get; set; }

        /// <summary>
        /// Gets or sets current consumption
        /// </summary>
        public double? Consumption { get; set; }

        /// <summary>
        /// Gets or sets wage Share %
        /// </summary>
        public decimal? WageShare { get; set; }

        /// <summary>
        /// Gets or sets amount Brutto
        /// </summary>
        public decimal? AmountBrutto { get; set; }

        /// <summary>
        /// Gets or sets invoice Date
        /// </summary>
        public string InvoiceDate { get; set; }

        /// <summary>
        /// Gets or sets comments
        /// </summary>
        public string Comments { get; set; }

        /// <summary>
        /// Gets or sets invoice File Contents
        /// </summary>
        public List<FileContentResponse> InvoiceFileContents { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets Editable Indicator. If true, cost will be edit able.
        /// </summary>
        public bool EditableInd { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets Internal Indicator
        /// </summary>
        public bool InternalInd { get; set; }

        /// <summary>
        /// Gets or sets wageShareTypeId
        /// </summary>
        public string WageShareTypeId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets delete Indicator
        /// </summary>
        public bool DeleteInd { get; set; }
    }
}
