// <copyright file="OrderController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.API.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using TEHA.Portal.API.Helpers;
    using TEHA.Portal.Data.Models.Common;
    using TEHA.Portal.Data.Models.Order;
    using TEHA.Portal.ProxyAPI.Order;

    /// <summary>
    /// Implements orders endpoints
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ApiControllerBase
    {
        private readonly IOrderClient orderClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderController"/> class.
        /// Initialze
        /// </summary>
        /// <param name="orderClient">orderClient</param>
        public OrderController(IOrderClient orderClient)
        {
            this.orderClient = orderClient;
        }

        /// <summary>
        /// Gets list of orders
        /// </summary>
        /// <remarks>This endpoint gets the list of orders placed by the building manager with their respective statuses.</remarks>
        /// <param name="body">OrderRequest</param>
        /// <response code="200">OK</response>
        /// <response code="404">No order found based on search criteria.</response>
        /// <returns>returns list of orders</returns>
        [HttpPost]
        [Route("Get")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Order>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get([FromBody]OrderRequest body)
        {
            return await this.Result<OrderResponse>(await this.orderClient.Get(this.CurrentUser.ExternalToken, body));
        }

        /// <summary>
        /// Get Plumbing Data to Edit
        /// </summary>
        /// <remarks>This endpoint Gets plumbing order data for editing.</remarks>
        /// <param name="userId">userId</param>
        /// <param name="propertyId">propertyId</param>
        /// <param name="orderId">orderId</param>
        /// <response code="200">OK</response>
        /// <response code="404">No order found based on search criteria.</response>
        /// <returns>returns order data</returns>
        [HttpGet]
        [Route("GetEditPlumbing")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PlumbingRequest))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetEditPlumbing([FromQuery] int userId, [FromQuery] int propertyId, [FromQuery] int orderId)
        {
            return await this.Result<PlumbingRequest>(await this.orderClient.GetEditPlumbing(this.CurrentUser.ExternalToken, userId, propertyId, orderId));
        }

        /// <summary>
        /// Get Reading Data to Edit
        /// </summary>
        /// <remarks>This endpoint Gets Reading order data for editing.</remarks>
        /// <param name="userId">userId</param>
        /// <param name="propertyId">propertyId</param>
        /// <param name="orderId">orderId</param>
        /// <response code="200">OK</response>
        /// <response code="404">No order found based on search criteria.</response>
        /// <returns>returns order data</returns>
        [HttpGet]
        [Route("GetEditReading")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ReadingRequest))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetEditReading([FromQuery] int userId, [FromQuery] int propertyId, [FromQuery] int orderId)
        {
            return await this.Result<ReadingRequest>(await this.orderClient.GetEditReading(this.CurrentUser.ExternalToken, userId, propertyId, orderId));
        }

        /// <summary>
        /// Get SmokeDetector Test Data to Edit
        /// </summary>
        /// <remarks>This endpoint Gets SmokeDetectorTest order data for editing.</remarks>
        /// <param name="userId">userId</param>
        /// <param name="propertyId">propertyId</param>
        /// <param name="orderId">orderId</param>
        /// <response code="200">OK</response>
        /// <response code="404">No order found based on search criteria.</response>
        /// <returns>returns order data</returns>
        [HttpGet]
        [Route("GetEditSmokeDetectorTest")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SmokeDetectorRequest))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetEditSmokeDetectorTest([FromQuery] int userId, [FromQuery] int propertyId, [FromQuery] int orderId)
        {
            return await this.Result<SmokeDetectorRequest>(await this.orderClient.GetEditSmokeDetectorTest(this.CurrentUser.ExternalToken, userId, propertyId, orderId));
        }

        /// <summary>
        /// Get Interim Reading Data to Edit
        /// </summary>
        /// <remarks>This endpoint Gets Interim Reading order data for editing.</remarks>
        /// <param name="userId">userId</param>
        /// <param name="propertyId">propertyId</param>
        /// <param name="orderId">orderId</param>
        /// <response code="200">OK</response>
        /// <response code="404">No order found based on search criteria.</response>
        /// <returns>returns order data</returns>
        [HttpGet]
        [Route("GetEditInterimReading")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ReadingRequest))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetEditInterimReading([FromQuery] int userId, [FromQuery] int propertyId, [FromQuery] int orderId)
        {
            return await this.Result<ReadingRequest>(await this.orderClient.GetEditInterimReading(this.CurrentUser.ExternalToken, userId, propertyId, orderId));
        }

        /// <summary>
        /// Get InterimReadingSelf data to edit
        /// </summary>
        /// <remarks>This endpoint Gets InterimReadingSelf order data for editing.</remarks>
        /// <param name="userId">userId</param>
        /// <param name="propertyId">propertyId</param>
        /// <param name="orderId">orderId</param>
        /// <response code="200">OK</response>
        /// <response code="404">No order found based on search criteria.</response>
        /// <returns>returns order data</returns>
        [HttpGet]
        [Route("GetEditInterimReadingSelf")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InterimReadingSelf))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetEditInterimReadingSelf([FromQuery] int userId, [FromQuery] int propertyId, [FromQuery] int orderId)
        {
            return await this.Result<InterimReadingSelf>(await this.orderClient.GetEditInterimReadingSelf(this.CurrentUser.ExternalToken, userId, propertyId, orderId));
        }

        /// <summary>
        /// Get EnergyPerformance Data to Edit
        /// </summary>
        /// <remarks>This endpoint Get Edit EnergyPerformance order data for editing.</remarks>
        /// <param name="userId">userId</param>
        /// <param name="propertyId">propertyId</param>
        /// <param name="orderId">orderId</param>
        /// <response code="200">OK</response>
        /// <response code="404">No order found based on search criteria.</response>
        /// <returns>returns order data</returns>
        [HttpGet]
        [Route("GetEditEnergyPerformance")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PerformanceCertificate))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetEditEnergyPerformance([FromQuery] int userId, [FromQuery] int propertyId, [FromQuery] int orderId)
        {
            return await this.Result<PerformanceCertificate>(await this.orderClient.GetEditEnergyPerformance(this.CurrentUser.ExternalToken, userId, propertyId, orderId));
        }

        /// <summary>
        /// Get OfferRequest Data to Edit
        /// </summary>
        /// <remarks>This endpoint Get OfferRequest order data for editing.</remarks>
        /// <param name="userId">userId</param>
        /// <param name="orderId">orderId</param>
        /// <response code="200">OK</response>
        /// <response code="404">No order found based on search criteria.</response>
        /// <returns>returns order data</returns>
        [HttpGet]
        [Route("GetEditOfferRequest")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OfferRequest))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetEditOfferRequest([FromQuery] int userId, [FromQuery] int orderId)
        {
            return await this.Result<OfferRequest>(await this.orderClient.GetEditOfferRequest(this.CurrentUser.ExternalToken, userId, orderId));
        }

        /// <summary>
        /// This endpoint gets the list of properties with open orders count.
        /// </summary>
        /// <remarks>Gets open order count with brief property details</remarks>
        /// <param name="userId">UserId</param>
        /// <response code="200">OK</response>
        /// <returns><List<Contract.PropertyInfo>></returns>
        [HttpGet]
        [Route("GetOpenOrderCount")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Data.Models.Contract.PropertyInfo>))]
        public async Task<IActionResult> GetOpenOrderCount([FromQuery] int userId)
        {
            return await this.Result<List<Data.Models.Contract.PropertyInfo>>(await this.orderClient.GetOpenOrderCount(this.CurrentUser.ExternalToken, userId));
        }

        /// <summary>
        /// Sends request for a non schedule reading service.
        /// </summary>
        /// <remarks>Requests for interim reading when a new user comes in or an existing user leaves the a flat.</remarks>
        /// <param name="body">ReadingRequest</param>
        /// <response code="200">OK</response>
        /// <response code="400">Not Found</response>
        /// <response code="409">Validation Errors</response>
        /// <returns>ok</returns>
        [HttpPost]
        [Route("RequestInterimReading")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(TEHA.Portal.Data.Models.Validation.Response))]
        public async Task<IActionResult> RequestInterimReading([FromBody]ReadingRequest body)
        {
            return await this.Result<HttpResponse>(await this.orderClient.RequestInterimReading(this.CurrentUser.ExternalToken, body));
        }

        /// <summary>
        /// Get's interim reading user moving out data
        /// </summary>
        /// <remarks>Requests for interim reading when a new user comes in or an existing user leaves the a flat.</remarks>
        /// <param name="userId">User ID</param>
        /// <param name="propertyId">Property ID</param>
        /// <param name="flatId">Flat ID</param>
        /// <response code="200">OK</response>
        /// <response code="400">Not Found</response>
        /// <response code="409">Validation Errors</response>
        /// <returns>ok</returns>
        [HttpGet]
        [Route("GetInterimReadingUserMovingOut")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ContactPerson))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(TEHA.Portal.Data.Models.Validation.Response))]
        public async Task<IActionResult> GetInterimReadingUserMovingOut([FromQuery] int userId, [FromQuery] int propertyId, [FromQuery] int flatId)
        {
            return await this.Result<ContactPerson>(await this.orderClient.GetInterimReadingUserMovingOut(this.CurrentUser.ExternalToken, userId, propertyId, flatId));
        }

        /// <summary>
        /// Sends request for service enhancement for new property.
        /// </summary>
        /// <remarks>An existing user(Building manager) can request for service enhancement by providing details of property and services.</remarks>
        /// <param name="body">OfferRequest</param>
        /// <response code="200">OK</response>
        /// <response code="400">Not Found</response>
        /// <response code="409">Validation Errors</response>
        /// <returns>ok</returns>
        [HttpPost]
        [Route("RequestOffer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(TEHA.Portal.Data.Models.Validation.Response))]
        public async Task<IActionResult> RequestOffer([FromBody]OfferRequest body)
        {
            return await this.Result<HttpResponse>(await this.orderClient.RequestOffer(this.CurrentUser.ExternalToken, body));
        }

        /// <summary>
        /// Sends request for plumbing service.
        /// </summary>
        /// <remarks>Sends request for any type plumbing required.</remarks>
        /// <param name="body">PlumbingRequest</param>
        /// <response code="200">OK</response>
        /// <response code="400">Not Found</response>
        /// <response code="409">Validation Errors</response>
        /// <returns>ok</returns>
        [HttpPost]
        [Route("RequestPlumbing")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(TEHA.Portal.Data.Models.Validation.Response))]
        public async Task<IActionResult> RequestPlumbing([FromBody]PlumbingRequest body)
        {
            return await this.Result<HttpResponse>(await this.orderClient.RequestPlumbing(this.CurrentUser.ExternalToken, body));
        }

        /// <summary>
        /// Posts the interim reading of the meter.
        /// </summary>
        /// <remarks>Instead of requesting for interim reading, the building manager enters the interim reading details explicitly when a user leaves the flat. </remarks>
        /// <param name="body">InterimReadingSelf</param>
        /// <response code="200">OK</response>
        /// <response code="400">Not Found</response>
        /// <response code="409">Validation Errors</response>
        /// <returns>ok</returns>
        [HttpPost]
        [Route("PostInterimReading")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(TEHA.Portal.Data.Models.Validation.Response))]
        public async Task<IActionResult> PostInterimReading([FromBody]InterimReadingSelf body)
        {
            return await this.Result<HttpResponse>(await this.orderClient.PostInterimReading(this.CurrentUser.ExternalToken, body));
        }

        /// <summary>
        /// Sends request for meter reading service.
        /// </summary>
        /// <remarks>Requests for scheduled meter reading service.</remarks>
        /// <param name="body">ReadingRequest</param>
        /// <response code="200">OK</response>
        /// <response code="400">Bad Request</response>
        /// <returns>ok</returns>
        [HttpPost]
        [Route("RequestReading")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RequestReading([FromBody]ReadingRequest body)
        {
            return await this.Result<HttpResponse>(await this.orderClient.RequestReading(this.CurrentUser.ExternalToken, body));
        }

        /// <summary>
        /// Sends request for building drinking water sampling.
        /// </summary>
        /// <remarks>Requests drinking water sampling for a building.</remarks>
        /// <param name="body">WaterSamplingRequest</param>
        /// <response code="200">OK</response>
        /// <response code="400">Not Found</response>
        /// <response code="409">Validation Errors</response>
        /// <returns>ok</returns>
        [HttpPost]
        [Route("RequestDrinkingWaterSampling")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(TEHA.Portal.Data.Models.Validation.Response))]
        public async Task<IActionResult> RequestDrinkingWaterSampling([FromBody]WaterSamplingRequest body)
        {
            return await this.Result<HttpResponse>(await this.orderClient.RequestDrinkingWaterSampling(this.CurrentUser.ExternalToken, body));
        }

        /// <summary>
        /// Sends a request for Energy Performance Certificate
        /// </summary>
        /// <remarks>Sends a request for Energy Performance Certificate.</remarks>
        /// <param name="body">PerformanceCertificate</param>
        /// <response code="200">OK</response>
        /// <response code="400">Not Found</response>
        /// <response code="409">Validation Errors</response>
        /// <returns>ok</returns>
        [HttpPost]
        [Route("RequestEnergyPerformanceCertificate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(TEHA.Portal.Data.Models.Validation.Response))]
        public async Task<IActionResult> RequestEnergyPerformanceCertificate([FromBody]PerformanceCertificate body)
        {
            return await this.Result<HttpResponse>(await this.orderClient.RequestEnergyPerformanceCertificate(this.CurrentUser.ExternalToken, body));
        }

        /// <summary>
        /// Get's Energy Performance Certificate Data
        /// </summary>
        /// <remarks>Sends a request for Energy Performance Certificate.</remarks>
        /// <param name="userId">User ID</param>
        /// <param name="propertyId">Property ID</param>
        /// <response code="200">OK</response>
        /// <response code="400">Not Found</response>
        /// <response code="409">Validation Errors</response>
        /// <returns>ok</returns>
        [HttpGet]
        [Route("GetEnergyCertificatePreFillData")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PerformanceCertificate))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(TEHA.Portal.Data.Models.Validation.Response))]
        public async Task<IActionResult> GetEnergyCertificatePreFillData([FromQuery] int userId, [FromQuery] int propertyId)
        {
            return await this.Result<PerformanceCertificate>(await this.orderClient.GetEnergyCertificatePreFillData(this.CurrentUser.ExternalToken, userId, propertyId));
        }

        /// <summary>
        /// Sends request for smoke detector test service.
        /// </summary>
        /// <remarks>Sends request for smoke detector test service</remarks>
        /// <param name="body">PlumbingRequest</param>
        /// <response code="200">OK</response>
        /// <response code="400">Not Found.</response>
        /// <response code="409">Validation Errors</response>
        /// <returns>ok</returns>
        [HttpPost]
        [Route("RequestSmokeDetectorTest")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(TEHA.Portal.Data.Models.Validation.Response))]
        public async Task<IActionResult> RequestSmokeDetectorTest([FromBody] SmokeDetectorRequest body)
        {
            return await this.Result<HttpResponse>(await this.orderClient.RequestSmokeDetectorTest(this.CurrentUser.ExternalToken, body));
        }

        /// <summary>
        /// Cancels order based on id.
        /// </summary>
        /// <remarks>It cancels the order if cancellation is available for the specific order.</remarks>
        /// <param name="orderCancelRequest">OrderCancelRequest</param>
        /// <response code="200">OK</response>
        /// <response code="400">Bad Request</response>
        /// <returns>ok</returns>
        [HttpPut]
        [Route("Cancel")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(TEHA.Portal.Data.Models.Validation.Response))]
        public async Task<IActionResult> Cancel([FromBody]OrderCancelRequest orderCancelRequest)
        {
            return await this.Result<HttpResponse>(await this.orderClient.Cancel(this.CurrentUser.ExternalToken, orderCancelRequest));
        }

        /// <summary>
        /// Get Last Readings of meter
        /// </summary>
        /// <param name="userId">userId</param>
        /// <param name="propertyId">propertyId</param>
        /// <param name="flatId">flatId</param>
        /// <param name="meterId">meterId</param>
        /// <param name="moveOutDate">moveOutDate</param>
        /// <returns>ok</returns>
        [HttpGet]
        [Route("GetLastReading")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<LastReading>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetLastReading([FromQuery] int userId, [FromQuery] int propertyId, [FromQuery] int flatId, [FromQuery] int? meterId, [FromQuery] string moveOutDate)
        {
            return await this.Result<List<LastReading>>(await this.orderClient.GetLastReading(this.CurrentUser.ExternalToken, userId, propertyId, flatId, meterId, moveOutDate));
        }

        /// <summary>
        /// Posts the interim reading of the meter.
        /// </summary>
        /// <remarks>Instead of requesting for interim reading, the building manager enters the interim reading details explicitly when a user leaves the flat. </remarks>
        /// <param name="body">AccountingInterimReadingSelf</param>
        /// <response code="200">OK</response>
        /// <response code="400">Not Found</response>
        /// <response code="409">Validation Errors</response>
        /// <returns>ok</returns>
        [HttpPost]
        [Route("AccountingPostInterimReading")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(TEHA.Portal.Data.Models.Validation.Response))]
        public async Task<IActionResult> AccountingPostInterimReading([FromBody] AccountingInterimReadingSelf body)
        {
            return await this.Result<HttpResponse>(await this.orderClient.AccountingInterimReadingSelf(this.CurrentUser.ExternalToken, body));
        }

        /// <summary>
        /// Get's offers list
        /// </summary>
        /// <remarks>It get's offers list for the current user.</remarks>
        /// <param name="userId">userId</param>
        /// <response code="200">OK</response>
        /// <response code="400">Bad Request</response>
        /// <returns>ok</returns>
        [HttpGet]
        [Route("GetOffers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(TEHA.Portal.Data.Models.Validation.Response))]
        public async Task<IActionResult> GetOffers([FromQuery] int userId)
        {
            return await this.Result<List<OfferData>>(await this.orderClient.GetOffers(this.CurrentUser.ExternalToken, userId));
        }

        /// <summary>
        /// Gets base64 array of offer document
        /// </summary>
        /// <param name="userId">userId </param>
        /// <param name="id">offer ID </param>
        /// <response code="200">OK</response>
        /// <response code="400">Invalid offer Id.</response>
        /// <returns>Bytes Array</returns>
        [HttpGet]
        [Route("GetOfferDocument")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FileContentResponse))]
        public async Task<IActionResult> GetOfferDocument([FromQuery] int userId, [FromQuery] int id)
        {
            return await this.Result<FileContentResponse>(await this.orderClient.GetOfferDocument(this.CurrentUser.ExternalToken, userId, id));
        }
    }
}
