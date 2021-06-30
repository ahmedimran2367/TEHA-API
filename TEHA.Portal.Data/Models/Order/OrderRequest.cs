// <copyright file="OrderRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Order
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using TEHA.Portal.Data.Models.Common;

    /// <summary>
    /// Contains order request details
    /// </summary>
    public class OrderRequest
    {
        /// <summary>
        /// Gets or Sets UserId
        /// </summary>
        [Required]
        public int? UserId { get; set; }

        /// <summary>
        /// Gets or Sets PropertyId
        /// </summary>
        public int? PropertyId { get; set; }

        /// <summary>
        /// Gets or Sets FlatId
        /// </summary>
        public int? FlatId { get; set; }

        /// <summary>
        /// Gets or Sets Status
        /// </summary>
        public List<string> Status { get; set; }

        /// <summary>
        /// Gets or Sets Status
        /// </summary>
        public List<string> Type { get; set; }

        /// <summary>
        /// Gets or sets free Text
        /// </summary>
        public string FreeText { get; set; }

        /// <summary>
        /// Gets or sets teha LG Number
        /// </summary>
        /// <value>Teha LG Number</value>
        public string TehaLgNo { get; set; }

        /// <summary>
        /// Gets or sets admin LG Number
        /// </summary>
        /// <value>Admin LG Number</value>
        public string AdminLgNo { get; set; }

        /// <summary>
        /// Gets or sets teha User Number
        /// </summary>
        /// <value>Teha User Number</value>
        public string TehaUserNo { get; set; }

        /// <summary>
        /// Gets or sets admin User Number
        /// </summary>
        /// <value>Admin User Number</value>
        public string AdminUserNo { get; set; }

        /// <summary>
        /// Gets or Sets PageNo
        /// </summary>
        public decimal? PageNo { get; set; }

        /// <summary>
        /// Gets or sets page size for paging
        /// </summary>
        /// <value>Page size for paging</value>
        public decimal? PageSize { get; set; }

        /// <summary>
        /// Gets or Sets Sort
        /// </summary>
        public Sort Sort { get; set; }
    }
}
