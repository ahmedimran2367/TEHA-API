// <copyright file="IEntityBase.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BITLogix.Core.Couchbase
{
    /// <summary>
    /// IEntityBase Interface
    /// </summary>
    public interface IEntityBase
    {
        /// <summary>
        /// Gets or Sets document Type
        /// </summary>
        string Type { get; set; }

        /// <summary>
        /// Gets or sets Element Id
        /// </summary>
        int Id { get; set; }
    }
}
