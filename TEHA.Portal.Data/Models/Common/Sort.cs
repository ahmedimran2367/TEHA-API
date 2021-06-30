// <copyright file="Sort.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Common
{
    /// <summary>
    /// Contains sorting
    /// </summary>
    public class Sort
    {
        /// <summary>
        /// Gets or sets attribute or field name.
        /// </summary>
        public string By { get; set; }

        /// <summary>
        /// Gets or sets ascending or Descending sort
        /// </summary>
        public string Direction { get; set; }
    }
}
