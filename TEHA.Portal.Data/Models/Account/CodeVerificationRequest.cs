// <copyright file="CodeVerificationRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Account
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Code Verification Request model
    /// </summary>
    public class CodeVerificationRequest
    {
        /// <summary>
        /// Gets or Sets Username.
        /// </summary>
        [Required]
        public string Username { get; set; }

        /// <summary>
        /// Gets or Sets Verification Code.
        /// </summary>
        [Required]
        public string Code { get; set; }
    }
}
