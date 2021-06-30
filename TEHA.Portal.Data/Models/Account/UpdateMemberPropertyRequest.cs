// <copyright file="UpdateMemberPropertyRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Account
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Member Property Change Request
    /// </summary>
    public class UpdateMemberPropertyRequest
    {
        /// <summary>
        /// Gets or sets user ID
        /// </summary>
        [Required]
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets Team Member user Id
        /// </summary>
        [Required]
        public int MemberUserId { get; set; }

        /// <summary>
        /// Gets or sets list of property IDs.
        /// </summary>
        [Required]
        public List<int> Properties { get; set; }
    }
}
