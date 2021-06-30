// <copyright file="IDashboardClient.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.ProxyAPI.Clients.Dashboard
{
    using System.Net.Http;
    using System.Threading.Tasks;

    /// <summary>
    /// Dashboard endpoints methods
    /// </summary>
    public interface IDashboardClient
    {
        /// <summary>
        /// Get dashboard information.
        /// </summary>
        /// <remarks>Get dashboard informations</remarks>
        /// <param name="token">JWT Token</param>
        /// <param name="userId">User ID</param>
        /// <returns>HttpResponseMessage</returns>
        public Task<HttpResponseMessage> Get(string token, int userId);
    }
}
