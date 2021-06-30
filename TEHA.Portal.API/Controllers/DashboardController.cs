// <copyright file="DashboardController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.API.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using TEHA.Portal.API.Helpers;
    using TEHA.Portal.ProxyAPI.Clients.Dashboard;

    /// <summary>
    /// Implements Dashboard Endpoints
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ApiControllerBase
    {
        private readonly IDashboardClient dashboardClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="DashboardController"/> class.
        /// </summary>
        /// <param name="dashboardClient">Dashboard Client</param>
        public DashboardController(IDashboardClient dashboardClient)
        {
            this.dashboardClient = dashboardClient;
        }

        /// <summary>
        /// Get dashboard information.
        /// </summary>
        /// <remarks>Get dashboard informations</remarks>
        /// <param name="userId">User ID</param>
        /// <response code="200">OK</response>
        /// <returns>Data.Models.Dashboard.Info</returns>
        [HttpGet]
        [Route("Get")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Data.Models.Dashboard.Info))]
        public async Task<IActionResult> Get([FromQuery] int userId)
        {
            return await this.Result<Data.Models.Dashboard.Info>(await this.dashboardClient.Get(this.CurrentUser.ExternalToken, userId));
        }
    }
}
