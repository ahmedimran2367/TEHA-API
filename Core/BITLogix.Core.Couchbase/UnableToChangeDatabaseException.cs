// <copyright file="UnableToChangeDatabaseException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BITLogix.Core.Couchbase
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Exception raised when Database changed event throws exception
    /// </summary>
    [System.Serializable]
    public class UnableToChangeDatabaseException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnableToChangeDatabaseException"/> class
        /// </summary>
        public UnableToChangeDatabaseException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnableToChangeDatabaseException"/> class
        /// </summary>
        /// <param name="message">A <see cref="T:System.String"/> that describes the exception. </param>
        public UnableToChangeDatabaseException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnableToChangeDatabaseException"/> class
        /// </summary>
        /// <param name="message">A <see cref="T:System.String"/> that describes the exception. </param>
        /// <param name="inner">The exception that is the cause of the current exception. </param>
        public UnableToChangeDatabaseException(string message, System.Exception inner)
            : base(message, inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnableToChangeDatabaseException"/> class
        /// </summary>
        /// <param name="context">The contextual information about the source or destination.</param>
        /// <param name="info">The object that holds the serialized object data.</param>
        protected UnableToChangeDatabaseException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// Gets Database Name
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// Gets DocumentIDs
        /// </summary>
        public IReadOnlyList<string> DocumentIDs { get; internal set; }
    }
}
