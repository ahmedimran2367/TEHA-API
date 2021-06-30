// <copyright file="LookupController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.API.Controllers.Administration
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using TEHA.Portal.API.Helpers;
    using TEHA.Portal.Data.Models.Administration;

    /// <summary>
    /// Contains lookup details
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class LookupController : ApiControllerBase
    {
        /// <summary>
        /// Get All Lookups
        /// </summary>
        /// <remarks>Get List of Lookups</remarks>
        /// <response code="200">OK</response>
        /// <returns>lookups list</returns>
        [HttpGet]
        [Route("Get")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<LookupBase>))]
        public IActionResult Get()
        {
            return this.Result(ResponseStatus.OK, new List<LookupBase>(), null);
        }

        /// <summary>
        /// Edit LookUp
        /// </summary>
        /// <remarks>Updates a lookup entry</remarks>
        /// <param name="lookUps">LookUps</param>
        /// <response code="200">OK</response>
        /// <returns>ok</returns>
        [HttpPut]
        [Route("Update")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<LookUps>))]
        public IActionResult Update([FromBody]LookUps lookUps)
        {
            return this.Result(ResponseStatus.OK, new List<LookUps>(), null);
        }
    }
}
