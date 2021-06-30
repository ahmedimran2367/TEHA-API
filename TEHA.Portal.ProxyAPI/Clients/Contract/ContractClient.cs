// <copyright file="ContractClient.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.ProxyAPI.Clients.Contract
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using TEHA.Portal.ProxyAPI.Constant;

    /// <summary>
    /// Contract Client
    /// </summary>
    public class ContractClient : IContractClient
    {
        private readonly RestClient restClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContractClient"/> class.
        /// </summary>
        public ContractClient()
        {
            this.restClient = new RestClient();
        }

        /// <summary>
        /// Get contract document
        /// </summary>
        /// <param name="token">Token</param>
        /// <param name="userId">User Id</param>
        /// <returns>Task</returns>
        public async Task<HttpResponseMessage> Get(string token, int userId)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("userId", userId.ToString());
            return await this.restClient.Get(Url.ContractGet, parameters, token);
        }

        /// <summary>
        /// Get contract document
        /// </summary>
        /// <param name="token">Token</param>
        /// <param name="userId">User Id</param>
        /// <param name="propertyId">Property Id</param>
        /// <param name="id">Contract Id</param>
        /// <returns>Task</returns>
        public async Task<HttpResponseMessage> GetContractDocument(string token, int userId, int propertyId, int id)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("userId", userId.ToString());
            parameters.Add("propertyId", propertyId.ToString());
            parameters.Add("id", id.ToString());
            return await this.restClient.Get(Url.ContractGetDocument, parameters, token);
        }
    }
}
