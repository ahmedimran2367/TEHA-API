// <copyright file="UpdateMemberDetailsRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Account
{
    /// <summary>
    /// UpdateMemberDetailsRequest Model
    /// </summary>
    public class UpdateMemberDetailsRequest
    {
        /// <summary>
        /// Gets or Sets User ID
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or Sets MemberUserId
        /// </summary>
        public int MemberUserId { get; set; }

        /// <summary>
        /// Gets or Sets Salutation Code
        /// </summary>
        public string SalutationCode { get; set; }

        /// <summary>
        /// Gets or sets or set firstname
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets or set lastname
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets kk
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets ll
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets l
        /// </summary>
        public string Fax { get; set; }
    }
}
