// <copyright file="ProxyResponse.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data
{
    using System.Collections.Generic;
    using TEHA.Portal.Data.Models.Validation;

    /// <summary>
    /// Contains Proxy Response
    /// </summary>
    /// <typeparam name="T">Any Type of object</typeparam>
    public class ProxyResponse<T>
    {
        /// <summary>
        /// Gets or sets status
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets data
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Gets or sets error
        /// </summary>
        public string Error { get; set; }

        /// <summary>
        /// Gets or sets list of errors
        /// </summary>
        public List<Error> Errors { get; set; }
    }
}
