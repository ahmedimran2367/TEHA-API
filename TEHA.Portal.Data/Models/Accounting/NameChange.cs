// <copyright file="NameChange.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Accounting
{
    /// <summary>
    /// Name Change
    /// </summary>
    public class NameChange
    {
        /// <summary>
        /// Gets or sets current Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets new Name
        /// </summary>
        public string NewName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether true, If name is changed
        /// </summary>
        public bool UserChangedInd { get; set; }
    }
}
