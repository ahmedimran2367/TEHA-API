// <copyright file="LanguageResult.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Language
{
    using System.Collections.Generic;

    /// <summary>
    /// Contains Language result info
    /// </summary>
    public class LanguageResult
    {
        /// <summary>
        /// Gets or sets list of properties.
        /// </summary>
        public List<TEHA.Portal.Data.Models.Administration.Language> Items { get; set; }

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
