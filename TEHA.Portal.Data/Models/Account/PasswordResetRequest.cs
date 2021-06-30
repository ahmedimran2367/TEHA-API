// <copyright file="PasswordResetRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Account
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Password Reset Request model
    /// </summary>
    public class PasswordResetRequest
    {
        /// <summary>
        /// Gets or sets email
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets password
        /// </summary>
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets internal Use Only.
        /// </summary>
        public string VerificationcCode { get; set; }
    }
}
