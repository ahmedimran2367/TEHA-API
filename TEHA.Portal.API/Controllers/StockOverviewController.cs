// <copyright file="StockOverviewController.cs" company="PlaceholderCompany">
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
    using TEHA.Portal.Data.Models.StockOverview;
    using TEHA.Portal.ProxyAPI.Clients.StockOverview;

    /// <summary>
    /// Implements stock overview endpoints
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class StockOverviewController : ApiControllerBase
    {
        private readonly IStockOverviewClient stockOverviewClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="StockOverviewController"/> class.
        /// </summary>
        /// <param name="stockOverviewClient">StockOverviewClient</param>
        public StockOverviewController(IStockOverviewClient stockOverviewClient)
        {
            this.stockOverviewClient = stockOverviewClient;
        }

        /// <summary>
        /// Gets Stock Overview Summary
        /// </summary>
        /// <remarks>It provides the following information based on user properties user have access to.  No. of Buildings No. of Flats No. of Meters Meter by type/status</remarks>
        /// <param name="userId">User Id</param>
        /// <response code="200">OK</response>
        /// <returns>TEHA.Portal.Data.Models.StockOverview.Summary</returns>
        [HttpGet]
        [Route("GetSummary")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Summary))]
        public async Task<IActionResult> GetSummary([FromQuery] int userId)
        {
            return await this.Result<Summary>(await this.stockOverviewClient.GetSummary(this.CurrentUser.ExternalToken, userId));
        }

        /// <summary>
        /// Get open letter downloadable document
        /// </summary>
        /// <remarks>Gets the Open letter document</remarks>
        /// <param name="userId">User ID</param>
        /// <param name="propertyId">Property ID</param>
        /// <param name="flatId">Flat ID</param>
        /// <response code="200">OK</response>
        /// <response code="404">No file found with this record</response>
        /// <returns>Base64/byte Array</returns>
        [HttpGet]
        [Route("GetOpenLetter")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FileContentResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetOpenLetter([FromQuery] int userId, [FromQuery] int propertyId, [FromQuery] int? flatId)
        {
            return await this.Result<FileContentResponse>(await this.stockOverviewClient.GetOpenLetter(this.CurrentUser.ExternalToken, userId, propertyId, flatId));
        }

        /// <summary>
        /// Filters the list of properties based on any parameter
        /// </summary>
        /// <remarks>Based on some parameters this will return a filtered list of all the properties with details like:
        /// TEHA – LG # Administrator – LG # Street Postcode RWM Status Accounting Status Reading Status Plumbing Status</remarks>
        /// <param name="propertyRequest">PropertyRequest</param>
        /// <response code="200">OK</response>
        /// <response code="404">No Property found based on the criteria</response>
        /// <returns>TEHA.Portal.Data.Models.StockOverview.PropertyRequest</returns>
        [HttpPost]
        [Route("GetProperties")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PropertyResult))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProperties([FromBody] PropertyRequest propertyRequest)
        {
            return await this.Result<PropertyResult>(await this.stockOverviewClient.GetProperties(this.CurrentUser.ExternalToken, propertyRequest));
        }

        /// <summary>
        /// Filters flats based on any parameter
        /// </summary>
        /// <remarks>This endpoint will filter the flats in a property based on any following parameter:
        /// TEHA – LG # Administrator – LG # Street Postcode Place RWM Status Accounting Status Reading Status Plumbing Status</remarks>
        /// <param name="flatRequest">FlatRequest</param>
        /// <response code="200">OK</response>
        /// <response code="404">No flat found based on the criteria</response>
        /// <returns>TEHA.Portal.Data.Models.StockOverview.Flat</returns>
        [HttpPost]
        [Route("GetFlats")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FlatResult))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetFlats([FromBody] FlatRequest flatRequest)
        {
            return await this.Result<FlatResult>(await this.stockOverviewClient.GetFlats(this.CurrentUser.ExternalToken, flatRequest));
        }

        /// <summary>
        /// Get all meters of a building
        /// </summary>
        /// <remarks>Gets all meters of a building/property including general meters.</remarks>
        /// <param name="userId">User ID</param>
        /// <param name="propertyId">Property ID</param>
        /// <response code="200">OK</response>
        /// <response code="404">No meters found based on the criteria</response>
        /// <returns>List<TEHA.Portal.Data.Models.StockOverview.Meter></TEHA.Portal.Data.Models.StockOverview.Meter></returns>
        [HttpGet]
        [Route("GetAllMeters")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Meter>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllMeters([FromQuery] int userId, [FromQuery] int propertyId)
        {
            return await this.Result<List<Meter>>(await this.stockOverviewClient.GetAllMeters(this.CurrentUser.ExternalToken, userId, propertyId));
        }
    }
}
