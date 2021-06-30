// <copyright file="IContractClient.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.ProxyAPI.Clients.Contract
{
    using System.Net.Http;
    using System.Threading.Tasks;

    /// <summary>
    /// Contract Client Interface
    /// </summary>
    public interface IContractClient
    {
        /// <summary>
        /// Get contract document
        /// </summary>
        /// <param name="token">Token</param>
        /// <param name="userId">User Id</param>
        /// <returns>Task</returns>
        public Task<HttpResponseMessage> Get(string token, int userId);

        /// <summary>
        /// Get contract document
        /// </summary>
        /// <param name="token">Token</param>
        /// <param name="userId">User Id</param>
        /// <param name="propertyId">Property Id</param>
        /// <param name="id">Contract Id</param>
        /// <returns>Task</returns>
        public Task<HttpResponseMessage> GetContractDocument(string token, int userId, int propertyId, int id);
    }
}
