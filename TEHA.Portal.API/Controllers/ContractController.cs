// <copyright file="ContractController.cs" company="PlaceholderCompany">
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
    using TEHA.Portal.ProxyAPI.Clients.Contract;

    /// <summary>
    /// Implements Contract Endpoints
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ApiControllerBase
    {
        private readonly IContractClient contractClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContractController"/> class.
        /// </summary>
        /// <param name="contractClient">Contract Client</param>
        public ContractController(IContractClient contractClient)
        {
            this.contractClient = contractClient;
        }

        /// <summary>
        /// Gets base64 array of contract document
        /// </summary>
        /// <param name="userId">User ID. To avoid inaccessible contract being downloaded.</param>
        /// <param name="propertyId">Property ID. To avoid inaccessible contract being downloaded.</param>
        /// <param name="id">Contract ID </param>
        /// <response code="200">OK</response>
        /// <response code="400">Invalid Contract Id.</response>
        /// <returns>Bytes Array</returns>
        [HttpGet]
        [Route("GetContractDocument")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FileContentResponse))]
        public async Task<IActionResult> GetContractDocument([FromQuery] int userId, [FromQuery] int propertyId, [FromQuery] int id)
        {
            return await this.Result<FileContentResponse>(await this.contractClient.GetContractDocument(this.CurrentUser.ExternalToken, userId, propertyId, id));
        }

        /// <summary>
        /// Search contracts by properties
        /// </summary>
        /// <remarks>Search contracts by properties.</remarks>
        /// <param name="userId">User ID. To avoid inaccessible properties being searched.</param>
        /// <response code="200">OK</response>
        /// <response code="404">Not Found.</response>
        /// <returns>List of Data.Models.Contract.Contract</returns>
        [HttpGet]
        [Route("Get")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Data.Models.Contract.Contract>))]
        public async Task<IActionResult> Get([FromQuery] int userId)
        {
            return await this.Result<List<TEHA.Portal.Data.Models.Contract.Contract>>(await this.contractClient.Get(this.CurrentUser.ExternalToken, userId));
        }
    }
}
