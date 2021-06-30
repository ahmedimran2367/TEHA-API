// <copyright file="Profile.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Account
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Profile
    /// </summary>
    public class Profile
    {
        /// <summary>
        /// Gets or sets user ID
        /// </summary>
        [Required]
        public int UserId { get; set; }

        /// <summary>
        /// Gets or Sets GeneralSettings
        /// </summary>
        public GeneralSetting GeneralSettings { get; set; }

        /// <summary>
        /// Gets or Sets ContactInformation
        /// </summary>
        [Required]
        public ContactInformation ContactInformation { get; set; }

        /// <summary>
        /// Gets or sets list of Teams.
        /// </summary>
        public List<Member> Members { get; set; }
    }
}
