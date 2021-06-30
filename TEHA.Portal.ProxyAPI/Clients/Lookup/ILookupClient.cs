// <copyright file="ILookupClient.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.ProxyAPI.Clients.Lookup
{
    using System.Net.Http;
    using System.Threading.Tasks;

    /// <summary>
    /// Lookup endpoints methods
    /// </summary>
    public interface ILookupClient
    {
        /// <summary>
        /// Returns All lookups
        /// </summary>
        /// <param name="token">External token</param>
        /// <returns>Data.Models.Administration.LookupBase</returns>
        public Task<HttpResponseMessage> Get();
    }
}
