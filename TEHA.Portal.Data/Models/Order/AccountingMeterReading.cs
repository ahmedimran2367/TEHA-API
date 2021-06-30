// <copyright file="MeterReading.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Order
{
    using TEHA.Portal.Data.Models.Common;

    /// <summary>
    /// Contains accounting meter reading
    /// </summary>
    public class AccountingMeterReading
    {
        /// <summary>
        /// Gets or sets meter Id
        /// </summary>
        /// <value>Meter Id</value>
        public int? MeterId { get; set; }

        /// <summary>
        /// Gets or sets value of reading
        /// </summary>
        /// <value>Value of reading </value>
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets image of the meter (base64)
        /// </summary>
        /// <value>Image of the meter (base64)</value>
        public FileContentResponse[] Image { get; set; }
    }
}
