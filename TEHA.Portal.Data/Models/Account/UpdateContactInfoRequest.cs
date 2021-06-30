// <copyright file="UpdateContactInfoRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Account
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Update Contact Information request model
    /// </summary>
    public class UpdateContactInfoRequest
    {
        /// <summary>
        /// Gets or sets user ID
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets ContactInfo
        /// </summary>
        [Required]
        public ContactInformation ContactInfo { get; set; }
    }
}
