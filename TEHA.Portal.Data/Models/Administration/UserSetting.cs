// <copyright file="UserSetting.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Administration
{
    using BITLogix.Core.Couchbase;

    /// <summary>
    /// contains user specific settings
    /// </summary>
    [DocumentType(nameof(UserSetting))]
    [ElementId("Id")]
    public class UserSetting : IEntityBase
    {
        /// <summary>
        /// Gets or sets Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets language
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// Gets or sets gridSize
        /// </summary>
        public int? GridSize { get; set; }

        /// <summary>
        /// Gets or sets Type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets UserId
        /// </summary>
        public int UserId { get; set; }
    }
}
