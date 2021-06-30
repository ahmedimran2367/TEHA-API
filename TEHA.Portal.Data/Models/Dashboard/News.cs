// <copyright file="News.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Dashboard
{
    /// <summary>
    /// Contains Upcoming Change in Laws, Important Company Information & Change in any company policy
    /// </summary>
    public class News
    {
        /// <summary>
        /// Gets or sets date
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// Gets or sets Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets ReferenceLink
        /// </summary>
        public string ReferenceLink { get; set; }
    }
}
