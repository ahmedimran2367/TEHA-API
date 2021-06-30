// <copyright file="CostLookUp.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Administration
{
    /// <summary>
    /// Cost LookUp Detail
    /// </summary>
    public class CostLookUp
    {
        /// <summary>
        /// Gets or sets value or code
        /// </summary>
        /// <value>value or code</value>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets display content
        /// </summary>
        /// <value>Display content</value>
        public string Value { get; set; }

        /// <summary>
        /// Gets or Sets Status
        /// </summary>
        public bool? Status { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether status
        /// </summary>
        public bool InternalInd { get; set; }

        /// <summary>
        /// Gets or Sets SortOrder
        /// </summary>
        public int? SortOrder { get; set; }
    }
}
