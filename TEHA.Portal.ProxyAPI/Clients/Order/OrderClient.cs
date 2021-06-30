// <copyright file="OrderClient.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.ProxyAPI
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using TEHA.Portal.Data.Models.Order;
    using TEHA.Portal.ProxyAPI.Constant;
    using TEHA.Portal.ProxyAPI.Order;

    /// <summary>
    /// Contains order Endpoints
    /// </summary>
    public class OrderClient : IOrderClient
    {
        private readonly RestClient restClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderClient"/> class.
        /// </summary>
        public OrderClient()
        {
            this.restClient = new RestClient();
        }

        /// <summary>
        /// Get Orders
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="orderRequest">orderRequest</param>
        /// <returns>HttpResponseMessage</returns>
        public async Task<HttpResponseMessage> Get(string token, OrderRequest orderRequest)
        {
            return await this.restClient.Post(Url.OrderGet, orderRequest, token);
        }

        /// <summary>
        /// Get Plumbing Data to Edit
        /// </summary>
        /// <remarks>This endpoint Gets plumbing order data for editing.</remarks>
        /// <param name="token">token</param>
        /// <param name="userId">userId</param>
        /// <param name="propertyId">propertyId</param>
        /// <param name="orderId">orderId</param>
        /// <returns>HttpResponseMessage</returns>
        public async Task<HttpResponseMessage> GetEditPlumbing(string token, int userId, int propertyId, int orderId)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("userId", userId.ToString());
            parameters.Add("propertyId", propertyId.ToString());
            parameters.Add("orderId", orderId.ToString());
            return await this.restClient.Get(Url.OrderGetEditPlumbing, parameters, token);
        }

        /// <summary>
        /// Get Reading Data to Edit
        /// </summary>
        /// <remarks>This endpoint Gets Reading order data for editing.</remarks>
        /// <param name="token">token</param>
        /// <param name="userId">userId</param>
        /// <param name="propertyId">propertyId</param>
        /// <param name="orderId">orderId</param>
        /// <returns>HttpResponseMessage</returns>
        public async Task<HttpResponseMessage> GetEditReading(string token, int userId, int propertyId, int orderId)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("userId", userId.ToString());
            parameters.Add("propertyId", propertyId.ToString());
            parameters.Add("orderId", orderId.ToString());
            return await this.restClient.Get(Url.OrderGetEditReading, parameters, token);
        }

        /// <summary>
        /// Get SmokeDetectorTest Data to Edit
        /// </summary>
        /// <remarks>This endpoint Gets SmokeDetectorTest order data for editing.</remarks>
        /// <param name="token">token</param>
        /// <param name="userId">userId</param>
        /// <param name="propertyId">propertyId</param>
        /// <param name="orderId">orderId</param>
        /// <returns>HttpResponseMessage</returns>
        public async Task<HttpResponseMessage> GetEditSmokeDetectorTest(string token, int userId, int propertyId, int orderId)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("userId", userId.ToString());
            parameters.Add("propertyId", propertyId.ToString());
            parameters.Add("orderId", orderId.ToString());
            return await this.restClient.Get(Url.OrderGetEditSmokeDetectorTest, parameters, token);
        }

        /// <summary>
        /// Get InterimReading Data to Edit
        /// </summary>
        /// <remarks>This endpoint Gets InterimReading order data for editing.</remarks>
        /// <param name="token">token</param>
        /// <param name="userId">userId</param>
        /// <param name="propertyId">propertyId</param>
        /// <param name="orderId">orderId</param>
        /// <returns>HttpResponseMessage</returns>
        public async Task<HttpResponseMessage> GetEditInterimReading(string token, int userId, int propertyId, int orderId)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("userId", userId.ToString());
            parameters.Add("propertyId", propertyId.ToString());
            parameters.Add("orderId", orderId.ToString());
            return await this.restClient.Get(Url.OrderGetEditInterimReading, parameters, token);
        }

        /// <summary>
        /// Get InterimReadingSelf Data to Edit
        /// </summary>
        /// <remarks>This endpoint Gets InterimReadingSelf order data for editing.</remarks>
        /// <param name="token">token</param>
        /// <param name="userId">userId</param>
        /// <param name="propertyId">propertyId</param>
        /// <param name="orderId">orderId</param>
        /// <returns>HttpResponseMessage</returns>
        public async Task<HttpResponseMessage> GetEditInterimReadingSelf(string token, int userId, int propertyId, int orderId)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("userId", userId.ToString());
            parameters.Add("propertyId", propertyId.ToString());
            parameters.Add("orderId", orderId.ToString());
            return await this.restClient.Get(Url.OrderGetEditInterimReadingSelf, parameters, token);
        }

        /// <summary>
        /// Get EnergyPerformance Data to Edit
        /// </summary>
        /// <remarks>This endpoint Gets EnergyPerformance order data for editing.</remarks>
        /// <param name="token">token</param>
        /// <param name="userId">userId</param>
        /// <param name="propertyId">propertyId</param>
        /// <param name="orderId">orderId</param>
        /// <returns>HttpResponseMessage</returns>
        public async Task<HttpResponseMessage> GetEditEnergyPerformance(string token, int userId, int propertyId, int orderId)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("userId", userId.ToString());
            parameters.Add("propertyId", propertyId.ToString());
            parameters.Add("orderId", orderId.ToString());
            return await this.restClient.Get(Url.OrderGetEditEnergyPerformance, parameters, token);
        }

        /// <summary>
        /// Get OfferRequest Data to Edit
        /// </summary>
        /// <remarks>This endpoint Gets OfferRequest order data for editing.</remarks>
        /// <param name="token">token</param>
        /// <param name="userId">userId</param>
        /// <param name="orderId">orderId</param>
        /// <returns>HttpResponseMessage</returns>
        public async Task<HttpResponseMessage> GetEditOfferRequest(string token, int userId, int orderId)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("userId", userId.ToString());
            parameters.Add("orderId", orderId.ToString());
            return await this.restClient.Get(Url.OrderGetEditOfferRequest, parameters, token);
        }

        /// <summary>
        /// Gets open order count with brief property details
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="userId">User Id</param>
        /// <returns>HttpResponseMessage</returns>
        public async Task<HttpResponseMessage> GetOpenOrderCount(string token, int userId)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("userId", userId.ToString());
            return await this.restClient.Get(Url.OrderGetOpenOrderCount, parameters, token);
        }

        /// <summary>
        /// Sends request for interim reading
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="readingRequest">readingRequest</param>
        /// <returns>HttpResponseMessage</returns>
        public async Task<HttpResponseMessage> RequestInterimReading(string token, ReadingRequest readingRequest)
        {
            return await this.restClient.Post(Url.OrderRequestInterimReading, readingRequest, token);
        }

        /// <summary>
        /// Sends request for Interim Reading user moving out
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="userId">User Id</param>
        /// <param name="propertyId">Property Id</param>
        /// <param name="flatId">Flat Id</param>
        /// <returns>ok</returns>
        public async Task<HttpResponseMessage> GetInterimReadingUserMovingOut(string token, int userId, int propertyId, int flatId)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("userId", userId.ToString());
            parameters.Add("propertyId", propertyId.ToString());
            parameters.Add("flatId", flatId.ToString());
            return await this.restClient.Get(Url.GetInterimReadingUserMovingOut, parameters, token);
        }

        /// <summary>
        /// Sends request for offer
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="offerRequest">offerRequest</param>
        /// <returns>HttpResponseMessage</returns>
        public async Task<HttpResponseMessage> RequestOffer(string token, OfferRequest offerRequest)
        {
            return await this.restClient.Post(Url.OrderRequestOffer, offerRequest, token);
        }

        /// <summary>
        /// Sends request for plumbing
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="plumbingRequest">plumbingRequest</param>
        /// <returns>HttpResponseMessage</returns>
        public async Task<HttpResponseMessage> RequestPlumbing(string token, PlumbingRequest plumbingRequest)
        {
            return await this.restClient.Post(Url.OrderRequestPlumbing, plumbingRequest, token);
        }

        /// <summary>
        /// Sends request for postInterimReading
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="interimReadingSelf">interimReadingSelf</param>
        /// <returns>HttpResponseMessage</returns>
        public async Task<HttpResponseMessage> PostInterimReading(string token, InterimReadingSelf interimReadingSelf)
        {
            return await this.restClient.Post(Url.OrderPostInterimReading, interimReadingSelf, token);
        }

        /// <summary>
        /// Sends request for postInterimReading
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="readingRequest">readingRequest</param>
        /// <returns>HttpResponseMessage</returns>
        public async Task<HttpResponseMessage> RequestReading(string token, ReadingRequest readingRequest)
        {
            return await this.restClient.Post(Url.OrderRequestReading, readingRequest, token);
        }

        /// <summary>
        /// Sends request for postInterimReading
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="waterSamplingRequest">waterSamplingRequest</param>
        /// <returns>HttpResponseMessage</returns>
        public async Task<HttpResponseMessage> RequestDrinkingWaterSampling(string token, WaterSamplingRequest waterSamplingRequest)
        {
            return await this.restClient.Post(Url.OrderRequestDrinkingWaterSampling, waterSamplingRequest, token);
        }

        /// <summary>
        /// Sends request for energy certificate
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="performanceCertificate">performanceCertificate</param>
        /// <returns>HttpResponseMessage</returns>
        public async Task<HttpResponseMessage> RequestEnergyPerformanceCertificate(string token, PerformanceCertificate performanceCertificate)
        {
            return await this.restClient.Post(Url.OrderRequestEnergyPerformanceCertificate, performanceCertificate, token);
        }

        /// <summary>
        /// Get's energy certificate data
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="userId">User Id</param>
        /// <param name="propertyId">Property Id</param>
        /// <returns>ok</returns>
        public async Task<HttpResponseMessage> GetEnergyCertificatePreFillData(string token, int userId, int propertyId)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("userId", userId.ToString());
            parameters.Add("propertyId", propertyId.ToString());
            return await this.restClient.Get(Url.GetEnergyCertificatePreFillData, parameters, token);
        }

        /// <summary>
        /// Sends request for smoke detector test
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="smokeDetectorRequest">plumbingRequest</param>
        /// <returns>HttpResponseMessage</returns>
        public async Task<HttpResponseMessage> RequestSmokeDetectorTest(string token, SmokeDetectorRequest smokeDetectorRequest)
        {
            return await this.restClient.Post(Url.OrderRequestSmokeDetectorTest, smokeDetectorRequest, token);
        }

        /// <summary>
        /// Sends request for order cancellation
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="orderCancelRequest">OrderCancelRequest</param>
        /// <returns>HttpResponseMessage</returns>
        public async Task<HttpResponseMessage> Cancel(string token, OrderCancelRequest orderCancelRequest)
        {
            return await this.restClient.Put(Url.OrderCancel, orderCancelRequest, token);
        }

        /// <summary>
        /// Get Last Reading
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="userId">userId</param>
        /// <param name="propertyId">propertyId</param>
        /// <param name="flatId">flatId</param>
        /// <param name="meterId">meterId</param>
        /// <param name="moveOutDate">moveOutDate</param>
        /// <returns>HttpResponseMessage</returns>
        public async Task<HttpResponseMessage> GetLastReading(string token, int userId, int propertyId, int flatId, int? meterId, string moveOutDate)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("userId", userId.ToString());
            parameters.Add("propertyId", propertyId.ToString());
            parameters.Add("flatId", flatId.ToString());
            if (meterId != null)
            {
                parameters.Add("meterId", meterId.ToString());
            }

            if (moveOutDate != null)
            {
                parameters.Add("moveOutDate", moveOutDate.ToString());
            }

            return await this.restClient.Get(Url.OrderGetLastReading, parameters, token);
        }

        /// <summary>
        /// Sends request for accounting postInterimReading
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="interimReadingSelf">accountingInterimReadingSelf</param>
        /// <returns>HttpResponseMessage</returns>
        public async Task<HttpResponseMessage> AccountingInterimReadingSelf(string token, AccountingInterimReadingSelf interimReadingSelf)
        {
            return await this.restClient.Post(Url.AccountingPostInterimReading, interimReadingSelf, token);
        }

        /// <summary>
        /// Get offers list
        /// </summary>
        /// <remarks>This endpoint Gets offers data.</remarks>
        /// <param name="token">token</param>
        /// <param name="userId">userId</param>
        /// <returns>HttpResponseMessage</returns>
        public async Task<HttpResponseMessage> GetOffers(string token, int userId)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("userId", userId.ToString());
            return await this.restClient.Get(Url.GetOffers, parameters, token);
        }

        /// <summary>
        /// Get offer document
        /// </summary>
        /// <param name="token">Token</param>
        /// <param name="userId">User Id</param>
        /// <param name="id">Offer Id</param>
        /// <returns>Task</returns>
        public async Task<HttpResponseMessage> GetOfferDocument(string token, int userId, int id)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("userId", userId.ToString());
            parameters.Add("id", id.ToString());
            return await this.restClient.Get(Url.GetOfferDocument, parameters, token);
        }
    }
}
