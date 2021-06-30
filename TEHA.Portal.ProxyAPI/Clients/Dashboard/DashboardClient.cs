// <copyright file="DashboardClient.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.ProxyAPI.Clients.Dashboard
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using TEHA.Portal.ProxyAPI.Constant;

    /// <summary>
    /// Dashboard Client which implements Dashboard endpoints
    /// </summary>
    public class DashboardClient : IDashboardClient
    {
        private readonly RestClient restClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="DashboardClient"/> class.
        /// </summary>
        public DashboardClient()
        {
            this.restClient = new RestClient();
        }

        /// <summary>
        /// Get dashboard information.
        /// </summary>
        /// <remarks>Get dashboard informations</remarks>
        /// <param name="token">JWT Token</param>
        /// <param name="userId">User ID</param>
        /// <returns>HttpResponseMessage</returns>
        public async Task<HttpResponseMessage> Get(string token, int userId)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("userId", userId.ToString());

            return await this.restClient.Get(Url.DashboardGet, parameters, token);
        }
    }
}
