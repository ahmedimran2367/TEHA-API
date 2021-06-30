// <copyright file="IConfiguration.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BITLogix.Core.Couchbase
{
    /// <summary>
    /// Configuration.
    /// </summary>
    public interface IConfiguration
    {
        /// <summary>
        /// Gets DatabaseName
        /// </summary>
        public string DatabaseName { get; }

        /// <summary>
        /// Gets DocumentsFile
        /// </summary>
        public string DocumentsFilename { get; }

        /// <summary>
        /// Gets a value indicating whether UpdateDocumentsInd is true or false
        /// </summary>
        public bool UpdateDocumentsInd { get; }

        /// <summary>
        /// Gets Items array field name
        /// </summary>
        public string ItemsArrayFieldName => "items";

        /// <summary>
        /// Get the specified name.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="name">Name.</param>
        string Get(string name);
    }
}
