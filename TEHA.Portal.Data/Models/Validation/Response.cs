// <copyright file="Response.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Validation
{
    using System.Collections.Generic;

    /// <summary>
    /// Contains Validation Errors
    /// </summary>
    public class Response
    {
        /// <summary>
        /// Gets or Sets Status
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or Sets Message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or Sets Errors
        /// </summary>
        public List<Error> Errors { get; set; }
    }
}
