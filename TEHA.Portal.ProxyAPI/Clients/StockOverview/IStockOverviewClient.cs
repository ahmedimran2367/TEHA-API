// <copyright file="IStockOverviewClient.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.ProxyAPI.Clients.StockOverview
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using TEHA.Portal.Data.Models.Common;
    using TEHA.Portal.Data.Models.StockOverview;

    /// <summary>
    /// StockOverview endpoint methods
    /// </summary>
    public interface IStockOverviewClient
    {
        /// <summary>
        /// It provides the following information based on user properties user have access to.
        /// No.of Buildings
        /// No.of Flats
        /// No.of Meters
        /// Meter by type/status
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="userId">userId</param>
        /// <returns>HttpResponseMethod</returns>
        public Task<HttpResponseMessage> GetSummary(string token, int userId);

        /// <summary>
        /// Gets Properties
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="propertyRequest">PropertyRequest Object</param>
        /// <returns>HttpResponseMethod</returns>
        public Task<HttpResponseMessage> GetProperties(string token, PropertyRequest propertyRequest);

        /// <summary>
        /// Gets Flats
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="flatrequest">FlatRequest object</param>
        /// <returns>HttpResponseMethod</returns>
        public Task<HttpResponseMessage> GetFlats(string token, FlatRequest flatrequest);

        /// <summary>
        /// Gets Open Letter
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="userId">User Id</param>
        /// <param name="propertyId">Property Id</param>
        /// <param name="flatId">Flat Id</param>
        /// <returns>HttpResponseMethod</returns>
        public Task<HttpResponseMessage> GetOpenLetter(string token, int userId, int propertyId, int? flatId);

        /// <summary>
        /// Gets All Meters of a Building
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="userId">User Id</param>
        /// <param name="propertyId">Property Id</param>
        /// <returns>HttpResponseMethod</returns>
        public Task<HttpResponseMessage> GetAllMeters(string token, int userId, int propertyId);
    }
}
