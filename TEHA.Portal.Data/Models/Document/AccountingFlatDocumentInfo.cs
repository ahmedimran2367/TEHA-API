// <copyright file="AccountingFlatDocumentInfo.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Document
{
    using System;

    /// <summary>
    /// Contains info about accounting flat document
    /// </summary>
    public class AccountingFlatDocumentInfo
    {
        /// <summary>
        /// Gets or Sets FlatId
        /// </summary>
        public int? FlatId { get; set; }

        /// <summary>
        /// Gets or sets teha unique number assigned to user.
        /// </summary>
        /// <value>Teha unique number assigned to user.</value>
        public string TehaUserNo { get; set; }

        /// <summary>
        /// Gets or sets admin User No
        /// </summary>
        /// <value>Admin User No</value>
        public string AdminUserNo { get; set; }

        /// <summary>
        /// Gets or sets rent ID
        /// </summary>
        /// <value>Rent ID</value>
        public int? RentId { get; set; }

        /// <summary>
        /// Gets or sets document Description (Document Title)
        /// </summary>
        /// <value>Document Description (Document Title)</value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets category/Type of the document
        /// </summary>
        /// <value>Category/Type of the document</value>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets CreationDate
        /// </summary>
        /// <value>Document Id</value>
        public DateTime CreationDate { get; set; }
    }
}
