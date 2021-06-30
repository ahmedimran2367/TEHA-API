// <copyright file="PropertyRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Common
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// All possible parameters can we used to search across application.
    /// </summary>
    public class PropertyRequest
    {
        /// <summary>
        /// Gets or sets user ID
        /// </summary>
        [Required]
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets list of property IDs.
        /// </summary>
        public List<int> PropertyIds { get; set; }

        /// <summary>
        /// Gets or sets free text search
        /// </summary>
        public string FreeText { get; set; }

        /// <summary>
        /// Gets or sets RWM Status Filter
        /// </summary>
        public string RwmStatus { get; set; }

        /// <summary>
        /// Gets or sets Accounting Status Filter
        /// </summary>
        public string AccountingStatus { get; set; }

        /// <summary>
        /// Gets or sets Plumbing Status Filter
        /// </summary>
        public string PlumbingStatus { get; set; }

        /// <summary>
        /// Gets or sets Reading Status filter.
        /// </summary>
        public List<string> ReadingStatus { get; set; }

        /// <summary>
        /// Gets or sets Accounting Month.
        /// </summary>
        public int? AccountingMonth { get; set; }

        /// <summary>
        /// Gets or sets data Medium ExchangeS status for Accounting. A is for Activated and N is for NOT Activated
        /// </summary>
        public string Dta { get; set; }

        /// <summary>
        /// Gets or Sets PageNo
        /// </summary>
        public int PageNo { get; set; }

        /// <summary>
        /// Gets or sets page size for paging
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Gets or Sets Sort
        /// </summary>
        public Sort Sort { get; set; }

        /// <summary>
        /// Gets or sets if true, include all navigation properties and thier childs.
        /// </summary>
        public bool? IncludeChildren { get; set; }

        /// <summary>
        /// Gets or Sets payrollClosingYear
        /// </summary>
        public string PayrollClosingYear { get; set; }
    }
}
