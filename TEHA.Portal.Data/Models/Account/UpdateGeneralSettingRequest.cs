// <copyright file="UpdateGeneralSettingRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Account
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Update General Settings Request model
    /// </summary>
    public class UpdateGeneralSettingRequest
    {
        /// <summary>
        /// Gets or sets user ID
        /// </summary>
        [Required]
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets Property ID
        /// </summary>
        public int? PropertyId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whehther OverwriteInd is true or false
        /// </summary>
        public bool? OverwriteInd { get; set; }

        /// <summary>
        /// Gets or Sets GeneralSettings
        /// </summary>
        [Required]
        public GeneralSetting GeneralSetting { get; set; }
    }
}
