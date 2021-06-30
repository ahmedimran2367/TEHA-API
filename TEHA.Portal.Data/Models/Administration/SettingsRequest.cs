// <copyright file="SettingsRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Administration
{
    using TEHA.Portal.Data.Models.Common;

    /// <summary>
    /// System settings request
    /// </summary>
    public class SettingsRequest
    {
        /// <summary>
        /// Gets or Sets PageNo
        /// </summary>
        public int PageNo { get; set; }

        /// <summary>
        /// Gets or sets page size for paging
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Gets or Sets Sort
        /// </summary>
        public Sort Sort { get; set; }
    }
}
