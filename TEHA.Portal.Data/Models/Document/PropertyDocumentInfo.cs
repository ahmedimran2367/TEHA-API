// <copyright file="PropertyDocumentInfo.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Document
{
    /// <summary>
    /// PropertyDocumentInfo model class
    /// </summary>
    public class PropertyDocumentInfo
    {
        /// <summary>
        /// Gets or sets property for which the document is assoiated to
        /// </summary>
        /// <value>Property for which the document is assoiated to</value>
        public int? PropertyId { get; set; }

        /// <summary>
        /// Gets or sets document Id
        /// </summary>
        /// <value>Document Id</value>
        public int Id { get; set; }

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
        /// Gets or sets accounting Period. In case of accounting documents only
        /// </summary>
        /// <value>Accounting Period. In case of accounting documents only</value>
        public string AccountingPeriod { get; set; }

        /// <summary>
        /// Gets or sets creation Date of document
        /// </summary>
        /// <value>Creation Date of document</value>
        public string CreationDate { get; set; }

        /// <summary>
        /// Gets or sets payroll year id of document
        /// </summary>
        /// <value>Payroll Year id</value>
        public int? PayRollYearId { get; set; }
    }
}
