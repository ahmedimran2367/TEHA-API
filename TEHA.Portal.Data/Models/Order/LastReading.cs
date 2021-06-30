// <copyright file="LastReading.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Order
{
    using TEHA.Portal.Data.Models.Common;

    /// <summary>
    /// Contains Last Reading of Meter
    /// </summary>
    public class LastReading
    {
        /// <summary>
        /// Gets or sets meter ID
        /// </summary>
        public int MeterId { get; set; }

        /// <summary>
        /// Gets or sets last Reading Value
        /// </summary>
        public decimal Value { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether meter With ResetInd
        /// </summary>
        public bool MeterWithResetInd { get; set; }

        /// <summary>
        /// Gets or sets move Out Reading Value
        /// </summary>
        public decimal? MoveOutReadingValue { get; set; }

        /// <summary>
        /// Gets or sets image of the meter (base64)
        /// </summary>
        /// <value>Image of the meter (base64)</value>
        public FileContentResponse[] Image { get; set; }
    }
}
