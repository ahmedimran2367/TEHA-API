// <copyright file="SmokeDetectorCount.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Dashboard
{
    /// <summary>
    /// Green: OK (If all meters are OK)  Red: Out of Order/Warning (If at least one meter from all the buildings has any warning or out of order)
    /// </summary>
    public class SmokeDetectorCount
    {
        /// <summary>
        /// Gets or sets error
        /// </summary>
        public int? Error { get; set; }

        /// <summary>
        /// Gets or sets ok
        /// </summary>
        public int? Ok { get; set; }
    }
}
