// <copyright file="DateRange.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Common
{
    /// <summary>
    /// Contains date or time range
    /// </summary>
    public class DateRange
    {
        /// <summary>
        /// Gets or sets start Date/Time
        /// </summary>
        /// <value>Start Date/Time</value>
        public string From { get; set; }

        /// <summary>
        /// Gets or sets end Date/Time
        /// </summary>
        /// <value>End Date/Time</value>
        public string To { get; set; }
    }
}
