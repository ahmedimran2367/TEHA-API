// <copyright file="GeneralSettingDetail.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Account
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// General Setting Detail
    /// </summary>
    public class GeneralSettingDetail
    {
        /// <summary>
        /// Gets or sets a value indicating whether notification indicator is true or false.
        /// </summary>
        [Required]
        public bool NotificationInd { get; set; }

        /// <summary>
        /// Gets or sets multiple communication channels
        /// </summary>
        public List<string> CommunicationMedium { get; set; }

        /// <summary>
        /// Gets or sets emailPreference. Only used in case of invoices. Enum are OneAAP, OneAEP, OnePI
        /// </summary>
        public string EmailPreference { get; set; }
    }
}
