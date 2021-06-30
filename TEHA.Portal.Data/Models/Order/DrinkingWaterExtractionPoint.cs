// <copyright file="DrinkingWaterExtractionPoint.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Order
{
    /// <summary>
    /// Contains flat wise location of Drinking Water Extraction Points
    /// </summary>
    public class DrinkingWaterExtractionPoint
    {
        /// <summary>
        /// Gets or Sets Flat ID
        /// </summary>
        public int FlatId { get; set; }

        /// <summary>
        /// Gets or Sets locations
        /// </summary>
        public string[] Location { get; set; }
    }
}
