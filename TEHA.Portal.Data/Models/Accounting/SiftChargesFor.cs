// <copyright file="SiftChargesFor.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Accounting
{
    /// <summary>
    /// Contains Sift Charges For
    /// </summary>
    public class SiftChargesFor
    {
        /// <summary>
        /// Gets or sets a value indicating whether smoke Detector indicator
        /// </summary>
        public bool? SmokeDetector { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether user Change indicator
        /// </summary>
        public bool? UserChange { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether repair indicator
        /// </summary>
        public bool? Repair { get; set; }
    }
}
