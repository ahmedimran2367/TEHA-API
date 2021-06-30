// <copyright file="TeamMemberDetail.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Account
{
    /// <summary>
    /// Contains team member details
    /// </summary>
   public class TeamMemberDetail
    {
        /// <summary>
        /// Gets or sets RequestFor
        /// </summary>
        public RequestFor RequestFor { get; set; }

        /// <summary>
        /// Gets or sets userId
        /// </summary>
        public int UserId { get; set; }
    }
}
