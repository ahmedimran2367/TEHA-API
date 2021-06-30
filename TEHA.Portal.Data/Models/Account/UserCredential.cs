// <copyright file="UserCredential.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Account
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// User Credentials
    /// </summary>
    public class UserCredential
    {
        /// <summary>
        /// Gets or sets Username
        /// </summary>
        /// <value>Email</value>
        [Required]
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets password
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}
