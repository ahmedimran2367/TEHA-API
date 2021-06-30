// <copyright file="OrdersCount.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Dashboard
{
    /// <summary>
    /// Contain Order count by category
    /// </summary>
    public class OrdersCount
    {
        /// <summary>
        /// Gets or sets order Plumbing
        /// </summary>
        public int? Plumbing { get; set; }

        /// <summary>
        /// Gets or sets order Reading
        /// </summary>
        public int? Reading { get; set; }

        /// <summary>
        /// Gets or sets order Interim Reading
        /// </summary>
        public int? InterimReading { get; set; }

        /// <summary>
        /// Gets or sets order Energy Certificate
        /// </summary>
        public int? EnergyCertificate { get; set; }

        /// <summary>
        /// Gets or sets order Drinking Water Sampling
        /// </summary>
        public int? DrinkingWaterSampling { get; set; }

        /// <summary>
        /// Gets or sets order Smoke Detector Test
        /// </summary>
        public int? SmokeDetectorTest { get; set; }
    }
}
