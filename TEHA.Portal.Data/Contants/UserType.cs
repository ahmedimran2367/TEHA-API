// <copyright file="UserType.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Contants
{
    using Newtonsoft.Json;

    /// <summary>
    /// Defines User Types
    /// </summary>
    public static class UserType
    {
        /// <summary>
        /// Teha Admin
        /// </summary>
        [JsonProperty]
        public const string TEHAADMIN = "TA";

        /// <summary>
        /// Teha User
        /// </summary>
        [JsonProperty]
        public const string TEHAUSER = "TU";

        /// <summary>
        /// Building Manager Admin
        /// </summary>
        [JsonProperty]
        public const string BUILDINGMANAGERADMIN = "HA";

        /// <summary>
        /// Building Manager User
        /// </summary>
        [JsonProperty]
        public const string BUILDINGMANAGERUSER = "HU";
    }
}
