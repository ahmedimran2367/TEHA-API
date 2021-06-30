// <copyright file="InfoController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.API.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using TEHA.Portal.API.Helpers;
    using TEHA.Portal.Data.Models.Info;
    using TEHA.Portal.ProxyAPI.Clients.Info;

    /// <summary>
    /// Implements Info endpoints
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class InfoController : ApiControllerBase
    {
        private readonly IInfoClient infoClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="InfoController"/> class.
        /// </summary>
        /// <param name="infoClient">Info Client</param>
        public InfoController(IInfoClient infoClient)
        {
            this.infoClient = infoClient;
        }

        /// <summary>
        /// Gets contact persons details
        /// </summary>
        /// <remarks>Gets contact details for specific persons for specific service types.</remarks>
        /// <param name="userId">User ID</param>
        /// <response code="200">OK</response>
        /// <response code="404">No Contacts Found</response>
        /// <returns>Service contacts</returns>
        [HttpGet]
        [Route("GetContactPersons")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ServiceContacts))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetContactPersons([FromQuery] int userId)
        {
            return await this.Result<ServiceContacts>(await this.infoClient.GetContactPersons(this.CurrentUser.ExternalToken, userId));
        }

        /// <summary>
        /// Get Pay Roll Year
        /// </summary>
        /// <remarks>Get list of payroll years</remarks>
        /// <param name="userId">User ID</param>
        /// <param name="propertyId">Property ID</param>
        /// <response code="200">OK</response>
        /// <returns>List of Data.Models.Info.PayrollYear</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<PayrollYear>))]
        [Route("GetPayRollYear")]
        public async Task<IActionResult> GetPayrollYear([FromQuery] int userId, [FromQuery] int propertyId)
        {
            return await this.Result<List<PayrollYear>>(await this.infoClient.GetPayrollYear(this.CurrentUser.ExternalToken, userId, propertyId));
        }
    }
}
