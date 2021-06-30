// <copyright file="ReadingCount.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Dashboard
{
    /// <summary>
    /// Status of Readings
    /// </summary>
    public class ReadingCount
    {
        /// <summary>
        /// Gets or sets finalized Reading
        /// </summary>
        public int? Finalized { get; set; }

        /// <summary>
        /// Gets or sets preparation Reading
        /// </summary>
        public int? Preparation { get; set; }
    }
}
