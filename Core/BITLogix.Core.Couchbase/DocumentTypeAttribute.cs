// <copyright file="DocumentTypeAttribute.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BITLogix.Core.Couchbase
{
    using System;

    /// <summary>
    /// DocumentType attribute
    /// </summary>
    [System.AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class DocumentTypeAttribute : Attribute
    {
        private readonly string documentType;

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentTypeAttribute"/> class.
        /// </summary>
        /// <param name="documentType">Document Type string</param>
        public DocumentTypeAttribute(string documentType)
        {
            this.documentType = documentType;
        }

        /// <summary>
        /// Gets documentType
        /// </summary>
        public string DocumentType
        {
            get { return this.documentType; }
        }
    }
}
