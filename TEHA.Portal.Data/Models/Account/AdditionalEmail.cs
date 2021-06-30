// <copyright file="AdditionalEmail.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Account
{
    /// <summary>
    /// Addtional Email Model
    /// </summary>
    public class AdditionalEmail
    {
        /// <summary>
        /// Gets or Sets Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or Sets a Value indicating whether EnableNotificationInd is true or false
        /// </summary>
        public bool EnableNotificationInd { get; set; }
    }
}
