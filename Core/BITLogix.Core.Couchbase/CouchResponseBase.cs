// <copyright file="CouchResponseBase.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models
{
    using System.Collections.Generic;
    using BITLogix.Core.Couchbase;

    /// <summary>
    /// Base response model from Couchbase
    /// </summary>
    /// <typeparam name="TEntity">Generic Type</typeparam>
    public class CouchResponseBase<TEntity>
        where TEntity : IEntityBase
    {
        /// <summary>
        /// Gets or sets type of the document
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets list of items of T type
        /// </summary>
        public List<TEntity> Items { get; set; }
    }
}
