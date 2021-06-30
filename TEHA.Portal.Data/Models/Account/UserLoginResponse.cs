// <copyright file="UserLoginResponse.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Account
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Contains login response
    /// </summary>
    public class UserLoginResponse
    {
        /// <summary>
        /// Gets or sets user ID
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets Master User ID
        /// </summary>
        public int? MasterUserId { get; set; }

        /// <summary>
        /// Gets or sets type of user e.g. House Manager User, House Manager Admin, TEHA Admin, TEHA User.
        /// </summary>
        [Required]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets name
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets email
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets JWT Token.(for internal use only)
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Gets or sets  Refresh JWT Token.(for internal use only)
        /// </summary>
        public string RefreshToken { get; set; }

        /// <summary>
        /// Gets or sets last login date.
        /// </summary>
        [Required]
        public DateTime LastLogin { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Password is expired or not. If true, user has to reset the password
        /// </summary>
        public bool PasswordExpiredInd { get; set; }
        /// <summary>
        /// Gets or sets external token.
        /// </summary>
        public string ExternalToken { get; set; }
    }
}
