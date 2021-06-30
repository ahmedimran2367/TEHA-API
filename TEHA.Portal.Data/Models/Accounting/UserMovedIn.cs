// <copyright file="UserMovedIn.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Accounting
{
    using System;

    /// <summary>
    /// User move in
    /// </summary>
    public class UserMovedIn
    {
        /// <summary>
        /// Gets or sets name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets date
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets number of users move in
        /// </summary>
        public int Count { get; set; }
    }
}
