// <copyright file="IInfoClient.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.ProxyAPI.Clients.Info
{
    using System.Net.Http;
    using System.Threading.Tasks;

    /// <summary>
    /// Info endpoints methods
    /// </summary>
    public interface IInfoClient
    {
        /// <summary>
        /// Gets contact persons details
        /// </summary>
        /// <remarks>Gets contact details for specific persons for specific service types.</remarks>
        /// <param name="token">Token</param>
        /// <param name="userId">User ID</param>
        /// <returns>HttpResponseMessage</returns>
        public Task<HttpResponseMessage> GetContactPersons(string token, int userId);

        /// <summary>
        /// Get Pay Roll Year
        /// </summary>
        /// <remarks>Get list of payroll years</remarks>
        /// <param name="token">Token</param>
        /// <param name="userId">User ID</param>
        /// <param name="propertyId">Property ID</param>
        /// <returns>HttpResponseMessage</returns>
        public Task<HttpResponseMessage> GetPayrollYear(string token, int userId, int propertyId);
    }
}
