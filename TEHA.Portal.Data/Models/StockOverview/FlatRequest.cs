// <copyright file="FlatRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.StockOverview
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Contains Flat request body
    /// </summary>
    public class FlatRequest
    {
        /// <summary>
        /// Gets or sets user ID
        /// </summary>
        [Required]
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets property IDs
        /// </summary>
        [Required]
        public List<int> PropertyIds { get; set; }

        /// <summary>
        /// Gets or sets flat IDs
        /// </summary>
        public List<int?> FlatIds { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether if true, include all navigation properties.
        /// </summary>
        [Required]
        public bool IncludeChildren { get; set; }
    }
}
