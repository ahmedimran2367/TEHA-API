// <copyright file="CertificateThermalEnergy.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Order
{
    /// <summary>
    /// Contains thermal energy details
    /// </summary>
    public class CertificateThermalEnergy
    {
        /// <summary>
        /// Gets or sets period during which the data is being added. For more than 1 year period, a new row will be added.
        /// </summary>
        /// <value>Period during which the data is being added. For more than 1 year period, a new row will be added.</value>
        public string Period { get; set; }

        /// <summary>
        /// Gets or sets amount in liters which is consumed
        /// </summary>
        /// <value>Amount in liters which is consumed</value>
        public decimal? Amount { get; set; }

        /// <summary>
        /// Gets or sets unit of thermal energy consumption
        /// </summary>
        /// <value>Unit of thermal energy consumption </value>
        public string Unit { get; set; }

        /// <summary>
        /// Gets or sets vacancy In percentage
        /// </summary>
        /// <value>Vacancy In percentage</value>
        public decimal? VacancyPercentage { get; set; }
    }
}
