// <copyright file="InfoClient.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.ProxyAPI.Clients.Info
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using TEHA.Portal.ProxyAPI.Constant;

    /// <summary>
    /// Info Client which implements Info endpoints
    /// </summary>
    public class InfoClient : IInfoClient
    {
        private readonly RestClient restClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="InfoClient"/> class.
        /// </summary>
        public InfoClient()
        {
            this.restClient = new RestClient();
        }

        /// <summary>
        /// Gets contact persons details
        /// </summary>
        /// <remarks>Gets contact details for specific persons for specific service types.</remarks>
        /// <param name="token">Token</param>
        /// <param name="userId">User ID</param>
        /// <returns>HttpResponseMessage</returns>
        public async Task<HttpResponseMessage> GetContactPersons(string token, int userId)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("userId", userId.ToString());

            return await this.restClient.Get(Url.InfoGetContactPersons, parameters, token);
        }

        /// <summary>
        /// Get Pay Roll Year
        /// </summary>
        /// <remarks>Get list of payroll years</remarks>
        /// <param name="token">Token</param>
        /// <param name="userId">User ID</param>
        /// <param name="propertyId">Property ID</param>
        /// <returns>HttpResponseMessage</returns>
        public async Task<HttpResponseMessage> GetPayrollYear(string token, int userId, int propertyId)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("userId", userId.ToString());
            parameters.Add("propertyId", propertyId.ToString());

            return await this.restClient.Get(Url.InfoGetPayrollYear, parameters, token);
        }
    }
}
