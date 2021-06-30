// <copyright file="Member.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Account
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using TEHA.Portal.Data.Models.Common;

    /// <summary>
    /// Contains Sub Profile data.
    /// </summary>
    public class Member
    {
        /// <summary>
        /// Gets or Sets Building manager user
        /// </summary>
        [Required]
        public int UserId { get; set; }

        /// <summary>
        /// Gets or Sets Email
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Phone
        /// </summary>
        [Required]
        public string Phone { get; set; }

        /// <summary>
        /// Gets or Sets SalutationCode
        /// </summary>
        [Required]
        public string SalutationCode { get; set; }

        /// <summary>
        /// Gets or Sets Fax
        /// </summary>
        public string Fax { get; set; }

        /// <summary>
        /// Gets or Sets list of properties user have access to.
        /// </summary>
        public List<Property> Properties { get; set; }

        /// <summary>
        /// Gets or sets contract Start Date
        /// </summary>
        public string StartDateContracts { get; set; }

        /// <summary>
        /// Gets or sets contract End Date
        /// </summary>
        public string EndDateContracts { get; set; }
    }
}
