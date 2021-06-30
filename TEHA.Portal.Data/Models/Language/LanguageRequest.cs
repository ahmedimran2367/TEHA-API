// <copyright file="LanguageRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Language
{
    using TEHA.Portal.Data.Models.Common;

    /// <summary>
    /// Contains admin language request params
    /// </summary>
    public class LanguageRequest
    {
        /// <summary>
        /// Gets or Sets Category
        /// </summary>
        public string Category { get; set; }

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
        /// Gets or Sets Sort
        /// </summary>
        public string FreeSearch { get; set; }
    }
}
