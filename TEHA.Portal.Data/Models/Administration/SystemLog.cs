// <copyright file="SystemLog.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Administration
{
    using BITLogix.Core.Couchbase;

    /// <summary>
    /// Implementing System Log
    /// </summary>
    [DocumentType(nameof(SystemLog))]
    [ElementId("Id")]
    public class SystemLog : BITLogix.Core.Couchbase.IEntityBase
    {
        /// <summary>
        /// Gets or sets iD  (PK)
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets log Date
        /// </summary>
        public string LogDate { get; set; }

        /// <summary>
        /// Gets or sets process Name
        /// </summary>
        public string ProcessName { get; set; }

        /// <summary>
        /// Gets or sets stack Trace
        /// </summary>
        public string StackTrace { get; set; }

        /// <summary>
        /// Gets or sets error Data
        /// </summary>
        public string ErrorData { get; set; }
    }
}