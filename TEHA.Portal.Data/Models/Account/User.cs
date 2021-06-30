// <copyright file="User.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Account
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Implementing User
    /// Account (User) - Contains User or Account level detail
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or Sets PK User ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets Master User ID
        /// </summary>
        public int? MasterUserId { get; set; }

        /// <summary>
        /// Gets or Sets  Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets  User Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or Sets  Type of User
        /// </summary>
        [Column(TypeName = "char(2)")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or Sets  Teha API Token
        /// </summary>]
        public string ExternalToken { get; set; }

        /// <summary>
        /// Gets or Sets  Last Login
        /// </summary>
        public DateTime? LastLogin { get; set; }

        /// <summary>
        /// Gets or Sets  Token
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Gets or Sets  Refresh Token
        /// </summary>
        public string RefreshToken { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether password Expired Ind
        /// </summary>
        public bool PasswordExpiredInd { get; set; }
    }
}
