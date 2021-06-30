// <copyright file="LookupClient.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.ProxyAPI.Clients.Lookup
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using TEHA.Portal.ProxyAPI.Constant;

    /// <summary>
    /// Implements Lookup Endpoints
    /// </summary>
    public class LookupClient : ILookupClient
    {
        private readonly RestClient restClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="LookupClient"/> class.
        /// </summary>
        public LookupClient()
        {
            this.restClient = new RestClient();
        }

        /// <summary>
        /// Returns All lookups
        /// </summary>
        /// <param name="token">External token</param>
        /// <returns>Data.Models.Administration.LookupBase</returns>
        public async Task<HttpResponseMessage> Get()
        {
            return await this.restClient.Get(Url.LookupGet, null);
        }
    }
}
