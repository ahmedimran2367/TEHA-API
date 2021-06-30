// <copyright file="Questions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Order
{
    using System.Collections.Generic;

    /// <summary>
    /// Contains questions answers
    /// </summary>
    public class Questions
    {
        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets StorageVolume400
        /// </summary>
        public bool StorageVolume400 { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets LineContent3L
        /// </summary>
        public bool LineContent3L { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets InspectionInAdvance
        /// </summary>
        public bool InspectionInAdvance { get; set; }

        /// <summary>
        /// Gets or Sets Tap
        /// </summary>
        public string Tap { get; set; }

        /// <summary>
        /// Gets or Sets DrinkingWaterExtractionPoint
        /// </summary>
        public List<DrinkingWaterExtractionPoint> DrinkingWaterExtractionPoint { get; set; }
    }
}
