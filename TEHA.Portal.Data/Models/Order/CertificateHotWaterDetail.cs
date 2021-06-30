// <copyright file="CertificateHotWaterDetail.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Order
{
    /// <summary>
    /// Contains hot water details
    /// </summary>
    public class CertificateHotWaterDetail
    {
        /// <summary>
        /// Gets or sets period during which the data is being added. For more than 1 year period, a new row will be added.
        /// </summary>
        /// <value>Period during which the data is being added. For more than 1 year period, a new row will be added.</value>
        public string Period { get; set; }

        /// <summary>
        /// Gets or sets amount which is consumed
        /// </summary>
        /// <value>Amount which is consumed</value>
        public decimal? Amount { get; set; }

        /// <summary>
        /// Gets or sets unit of hot water consumption
        /// </summary>
        /// <value>Unit of hot water consumption </value>
        public string Unit { get; set; }
    }
}
