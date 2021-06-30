// <copyright file="FlatResult.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Common
{
    using System.Collections.Generic;

    /// <summary>
    /// Property Result
    /// </summary>
    public class FlatResult
    {
        /// <summary>
        /// Gets or sets list of properties.
        /// </summary>
        public List<Flat> Items { get; set; }

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
