// <copyright file="PropertyResult.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Accounting
{
    using System.Collections.Generic;
    using TEHA.Portal.Data.Models.Common;

    /// <summary>
    /// Property Result
    /// </summary>
    public class AccountingResult
    {
        /// <summary>
        /// Gets or sets list of properties.
        /// </summary>
        public List<AccountingProperty> Items { get; set; }

        /// <summary>
        /// Gets or sets current pages
        /// </summary>
        public int? CurrentPage { get; set; }

        /// <summary>
        /// Gets or sets total records
        /// </summary>
        public int? TotalRecords { get; set; }
    }
}
