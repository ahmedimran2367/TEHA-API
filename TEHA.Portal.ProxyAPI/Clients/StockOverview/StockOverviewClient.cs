// <copyright file="StockOverviewClient.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace TEHA.Portal.ProxyAPI.Clients.StockOverview
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using TEHA.Portal.Data.Models.Common;
    using TEHA.Portal.Data.Models.StockOverview;
    using TEHA.Portal.ProxyAPI.Constant;

    /// <summary>
    /// Contains Stock Overview Endpoints
    /// </summary>
    public class StockOverviewClient : IStockOverviewClient
    {
        private readonly RestClient restClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="StockOverviewClient"/> class.
        /// </summary>
        public StockOverviewClient()
        {
            this.restClient = new RestClient();
        }

        /// <summary>
        /// It provides the following information based on user properties user have access to.
        /// No.of Buildings
        /// No.of Flats
        /// No.of Meters
        /// Meter by type/status
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="userId">userId</param>
        /// <returns>TEHA.Portal.Data.Models.StockOverview.Summary</returns>
        public async Task<HttpResponseMessage> GetSummary(string token, int userId)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("userId", userId.ToString());
            return await this.restClient.Get(Url.StockOverviewSummary, parameters, token);
        }

        /// <summary>
        /// Gets All Meters of a Building
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="userId">User Id</param>
        /// <param name="propertyId">Property Id</param>
        /// <returns>HttpResponseMethod</returns>
        public async Task<HttpResponseMessage> GetAllMeters(string token, int userId, int propertyId)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("userId", userId.ToString());
            parameters.Add("propertyId", propertyId.ToString());
            return await this.restClient.Get(Url.StockOverviewGetAllMeters, parameters, token);
        }

        /// <summary>
        /// Get Properties
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="propertyRequest">propertyRequest</param>
        /// <returns>HttpResponseMessage</returns>
        public async Task<HttpResponseMessage> GetProperties(string token, PropertyRequest propertyRequest)
        {
            return await this.restClient.Post(Url.StockOverviewProperties, propertyRequest, token);
        }

        /// <summary>
        /// Get Flats
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="flatrequest">flatrequest</param>
        /// <returns>HttpResponseMessage</returns>
        public async Task<HttpResponseMessage> GetFlats(string token, FlatRequest flatrequest)
        {
            return await this.restClient.Post(Url.StockOverviewGetFlats, flatrequest, token);
        }

        /// <summary>
        /// Get Open Letter
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="userId">userId</param>
        /// <param name="propertyId">propertyId</param>
        /// <param name="flatId">flatId</param>
        /// <returns>HttpResponseMessage</returns>
        public async Task<HttpResponseMessage> GetOpenLetter(string token, int userId, int propertyId, int? flatId)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("userId", userId.ToString());
            parameters.Add("propertyId", propertyId.ToString());
            if (flatId != null)
            {
                parameters.Add("flatId", flatId.ToString());
            }

            return await this.restClient.Get(Url.StockOverviewGetOpenLetter, parameters, token);
        }
    }
}
