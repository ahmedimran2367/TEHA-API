// <copyright file="ChangePasswordRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Account
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Change Password Request model
    /// </summary>
    public class ChangePasswordRequest
    {
        /// <summary>
        /// Gets or sets User Id.
        /// </summary>
        [Required]
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets old password
        /// </summary>
        [Required]
        public string OldPassword { get; set; }

        /// <summary>
        /// Gets or Sets new password
        /// </summary>
        [Required]
        public string NewPassword { get; set; }
    }
}
