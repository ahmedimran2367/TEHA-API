// <copyright file="GetDocumentsResponse.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Document
{
    using System.Collections.Generic;

    /// <summary>
    /// GetDocumentsResponse model
    /// </summary>
    public class GetDocumentsResponse
    {
        /// <summary>
        /// Gets or Sets PropertyDocuments
        /// </summary>
        public List<PropertyDocumentInfo> PropertyDocuments { get; set; }

        /// <summary>
        /// Gets or Sets FlatDocuments
        /// </summary>
        public List<FlatDocumentInfo> FlatsDocuments { get; set; }

        /// <summary>
        /// Gets or Sets MeterDocuments
        /// </summary>
        public List<MeterDocumentInfo> MeterDocuments { get; set; }
    }
}
