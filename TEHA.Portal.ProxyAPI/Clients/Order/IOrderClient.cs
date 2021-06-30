// <copyright file="IOrderClient.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.ProxyAPI.Order
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using TEHA.Portal.Data.Models.Order;

    /// <summary>
    /// Contains Order methods
    /// </summary>
    public interface IOrderClient
    {
        /// <summary>
        /// Get Orders
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="orderRequest">orderRequest</param>
        /// <returns>orders list</returns>
        public Task<HttpResponseMessage> Get(string token, OrderRequest orderRequest);

        /// <summary>
        /// Get Plumbing Data to Edit
        /// </summary>
        /// <remarks>This endpoint Gets plumbing order data for editing.</remarks>
        /// <param name="token">token</param>
        /// <param name="userId">userId</param>
        /// <param name="propertyId">propertyId</param>
        /// <param name="orderId">orderId</param>
        /// <returns>orders data</returns>
        public Task<HttpResponseMessage> GetEditPlumbing(string token, int userId, int propertyId, int orderId);

        /// <summary>
        /// Get Reading Data to Edit
        /// </summary>
        /// <remarks>This endpoint Gets Reading order data for editing.</remarks>
        /// <param name="token">token</param>
        /// <param name="userId">userId</param>
        /// <param name="propertyId">propertyId</param>
        /// <param name="orderId">orderId</param>
        /// <returns>orders data</returns>
        public Task<HttpResponseMessage> GetEditReading(string token, int userId, int propertyId, int orderId);

        /// <summary>
        /// Get SmokeDetectorTest Data to Edit
        /// </summary>
        /// <remarks>This endpoint Gets SmokeDetectorTest order data for editing.</remarks>
        /// <param name="token">token</param>
        /// <param name="userId">userId</param>
        /// <param name="propertyId">propertyId</param>
        /// <param name="orderId">orderId</param>
        /// <returns>orders data</returns>
        public Task<HttpResponseMessage> GetEditSmokeDetectorTest(string token, int userId, int propertyId, int orderId);

        /// <summary>
        /// Get InterimReading Data to Edit
        /// </summary>
        /// <remarks>This endpoint Gets InterimReading order data for editing.</remarks>
        /// <param name="token">token</param>
        /// <param name="userId">userId</param>
        /// <param name="propertyId">propertyId</param>
        /// <param name="orderId">orderId</param>
        /// <returns>orders data</returns>
        public Task<HttpResponseMessage> GetEditInterimReading(string token, int userId, int propertyId, int orderId);

        /// <summary>
        /// Get InterimReadingSelf Data to Edit
        /// </summary>
        /// <remarks>This endpoint Gets InterimReadingSelf order data for editing.</remarks>
        /// <param name="token">token</param>
        /// <param name="userId">userId</param>
        /// <param name="propertyId">propertyId</param>
        /// <param name="orderId">orderId</param>
        /// <returns>orders data</returns>
        public Task<HttpResponseMessage> GetEditInterimReadingSelf(string token, int userId, int propertyId, int orderId);

        /// <summary>
        /// Get EnergyPerformance Data to Edit
        /// </summary>
        /// <remarks>This endpoint Gets EnergyPerformance order data for editing.</remarks>
        /// <param name="token">token</param>
        /// <param name="userId">userId</param>
        /// <param name="propertyId">propertyId</param>
        /// <param name="orderId">orderId</param>
        /// <returns>orders data</returns>
        public Task<HttpResponseMessage> GetEditEnergyPerformance(string token, int userId, int propertyId, int orderId);

        /// <summary>
        /// Get OfferRequest Data to Edit
        /// </summary>
        /// <remarks>This endpoint Gets OfferRequest order data for editing.</remarks>
        /// <param name="token">token</param>
        /// <param name="userId">userId</param>
        /// <param name="orderId">orderId</param>
        /// <returns>orders data</returns>
        public Task<HttpResponseMessage> GetEditOfferRequest(string token, int userId, int orderId);

        /// <summary>
        /// Gets open order count with brief property details
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="userId">UserId</param>
        /// <returns>List<Contract.PropertyInfo></returns>
        public Task<HttpResponseMessage> GetOpenOrderCount(string token, int userId);

        /// <summary>
        /// Sends request for Interim Reading
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="readingRequest">readingRequest</param>
        /// <returns>ok</returns>
        public Task<HttpResponseMessage> RequestInterimReading(string token, ReadingRequest readingRequest);

        /// <summary>
        /// Sends request for Interim Reading user moving out
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="userId">User Id</param>
        /// <param name="propertyId">Property Id</param>
        /// <param name="flatId">Flat Id</param>
        /// <returns>ok</returns>
        public Task<HttpResponseMessage> GetInterimReadingUserMovingOut(string token, int userId, int propertyId, int flatId);

        /// <summary>
        /// Sends request for offer
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="offerRequest">offerRequest</param>
        /// <returns>ok</returns>
        public Task<HttpResponseMessage> RequestOffer(string token, OfferRequest offerRequest);

        /// <summary>
        /// Sends request for plumbing
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="plumbingRequest">plumbingRequest</param>
        /// <returns>ok</returns>
        public Task<HttpResponseMessage> RequestPlumbing(string token, PlumbingRequest plumbingRequest);

        /// <summary>
        /// Sends request for interim reading
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="interimReadingSelf">interimReadingSelf</param>
        /// <returns>ok</returns>
        public Task<HttpResponseMessage> PostInterimReading(string token, InterimReadingSelf interimReadingSelf);

        /// <summary>
        /// Sends request for reading
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="readingRequest">readingRequest</param>
        /// <returns>ok</returns>
        public Task<HttpResponseMessage> RequestReading(string token, ReadingRequest readingRequest);

        /// <summary>
        /// Sends request for drinking water sampling
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="waterSamplingRequest">waterSamplingRequest</param>
        /// <returns>ok</returns>
        public Task<HttpResponseMessage> RequestDrinkingWaterSampling(string token, WaterSamplingRequest waterSamplingRequest);

        /// <summary>
        /// Sends request for energy certificate
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="performanceCertificate">performanceCertificate</param>
        /// <returns>ok</returns>
        public Task<HttpResponseMessage> RequestEnergyPerformanceCertificate(string token, PerformanceCertificate performanceCertificate);

        /// <summary>
        /// Get's energy certificate data
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="userId">User Id</param>
        /// <param name="propertyId">Property Id</param>
        /// <returns>ok</returns>
        public Task<HttpResponseMessage> GetEnergyCertificatePreFillData(string token, int userId, int propertyId);

        /// <summary>
        /// Sends request for smoke detector test
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="smokeDetectorRequest">plumbingRequest</param>
        /// <returns>ok</returns>
        public Task<HttpResponseMessage> RequestSmokeDetectorTest(string token, SmokeDetectorRequest smokeDetectorRequest);

        /// <summary>
        /// Sends request for order cancellation
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="orderCancelRequest">OrderCancelRequest</param>
        /// <returns>ok</returns>
        public Task<HttpResponseMessage> Cancel(string token, OrderCancelRequest orderCancelRequest);

        /// <summary>
        /// Get Last Reading
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="userId">userId</param>
        /// <param name="propertyId">propertyId</param>
        /// <param name="flatId">flatId</param>
        /// <param name="meterId">meterId</param>
        /// <param name="moveOutDate">moveOutDate</param>
        /// <returns>ok</returns>
        public Task<HttpResponseMessage> GetLastReading(string token, int userId, int propertyId, int flatId, int? meterId, string moveOutDate);

        /// <summary>
        /// Sends request for interim reading
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="interimReadingSelf">AccountinginterimReadingSelf</param>
        /// <returns>ok</returns>
        public Task<HttpResponseMessage> AccountingInterimReadingSelf(string token, AccountingInterimReadingSelf interimReadingSelf);

        /// <summary>
        /// Get offers
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="userId">orderRequest</param>
        /// <returns>offers list</returns>
        public Task<HttpResponseMessage> GetOffers(string token, int userId);

        /// <summary>
        /// Get offer document
        /// </summary>
        /// <param name="token">Token</param>
        /// <param name="userId">User Id</param>
        /// <param name="id">offer Id</param>
        /// <returns>Task</returns>
        public Task<HttpResponseMessage> GetOfferDocument(string token, int userId, int id);
    }
}
