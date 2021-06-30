// <copyright file="AccountingController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.API.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using TEHA.Portal.API.Helpers;
    using TEHA.Portal.Data.Models.Accounting;
    using TEHA.Portal.ProxyAPI.Clients.Accounting;

    /// <summary>
    /// Implements Accounting Endpoints
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AccountingController : ApiControllerBase
    {
        private readonly IAccountingClient accountingClient;

        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountingController"/> class.
        /// </summary>
        /// <param name="accountingClient">AccountingClient</param>
        /// <param name="mapper">IMapper</param>
        public AccountingController(IAccountingClient accountingClient, IMapper mapper)
        {
            this.accountingClient = accountingClient;
            this.mapper = mapper;
        }

        /// <summary>
        /// Filters the list of properties based on any parameter
        /// </summary>
        /// <remarks>Based on some parameters this will return a filtered list of all the properties with details like:
        /// TEHA – LG # Administrator – LG # Street Postcode RWM Status Accounting Status Reading Status Plumbing Status</remarks>
        /// <param name="accountingRequest">AccountingRequest</param>
        /// <response code="200">OK</response>
        /// <response code="404">No Accounting found based on the criteria</response>
        /// <returns>TEHA.Portal.Data.Models.accounting.AccountingRequest</returns>
        [HttpPost]
        [Route("GetAccountingPeriods")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AccountingResult))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAccountingPeriods([FromBody] AccountingRequest accountingRequest)
        {
            return await this.Result<AccountingResult>(await this.accountingClient.GetAccountingPeriods(this.CurrentUser.ExternalToken, accountingRequest));
        }

        /// <summary>
        /// Gets accounting cost information by year
        /// </summary>
        /// <remarks>Gets accounting cost information by year. Use to populate previous year data in accounting process</remarks>
        /// <param name="userId">User ID</param>
        /// <param name="propertyId">Property ID</param>
        /// <param name="payrollYear">Payroll year</param>
        /// <response code="200">OK</response>
        /// <returns>TEHA.Portal.Data.Models.Accounting.Information</returns>
        [HttpGet]
        [Route("GetCosts")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CostData))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCosts([FromQuery] int userId, [FromQuery] int propertyId, [FromQuery] int payrollYear)
        {
            return await this.Result<CostData>(await this.accountingClient.GetCosts(this.CurrentUser.ExternalToken, userId, propertyId, payrollYear));
        }

        /// <summary>
        /// Get Flat Current User
        /// </summary>
        /// <remarks>Get Flat Current User Information</remarks>
        /// <param name="userId">User ID, to enforce authorization.</param>
        /// <param name="propertyId">Property ID</param>
        /// <param name="payrollYear">Payroll Year</param>
        /// <response code="200">OK</response>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Not Found</response>
        /// <returns>List of Data.Models.Accounting.FlatData</returns>
        [HttpGet]
        [Route("GetFlatUsers")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Data.Models.Accounting.FlatData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetFlatUsers([FromQuery] int userId, [FromQuery] int propertyId, [FromQuery] int payrollYear)
        {
            return await this.Result<FlatData>(await this.accountingClient.GetFlatUsers(this.CurrentUser.ExternalToken, userId, propertyId, payrollYear));
        }

        /// <summary>
        /// Submit accounting information by year
        /// </summary>
        /// <remarks>Blocks/ Submits final accounting information by year, which cannot be edited later on.</remarks>
        /// <param name="blockPeriodRequest">Block Period Request</param>
        /// <response code="200">OK</response>
        /// <response code="404">Not Found</response>
        /// <response code="409">Validation Errors</response>
        /// <returns>Submitted successfully</returns>
        [HttpPost]
        [Route("Submit")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(TEHA.Portal.Data.Models.Validation.Response))]
        public async Task<IActionResult> Submit([FromBody] BlockPeriodRequest blockPeriodRequest)
        {
            return await this.Result<string>(await this.accountingClient.Submit(this.CurrentUser.ExternalToken, blockPeriodRequest));
        }

        /// <summary>
        /// Delete Concept
        /// </summary>
        /// <remarks>Delete specific cost concept.</remarks>
        /// <param name="userId">User ID</param>
        /// <param name="propertyId">Property ID</param>
        /// <param name="conceptId">Concept Id</param>
        /// <response code="200">OK</response>
        /// <response code="404">Concept Not Found</response>
        /// <returns>Deleted Successfully</returns>
        [HttpDelete]
        [Route("DeleteConcept")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteConcept([FromQuery] int userId, [FromQuery] int propertyId, [FromQuery] int conceptId)
        {
            return await this.Result<string>(await this.accountingClient.DeleteConcept(this.CurrentUser.ExternalToken, userId, propertyId, conceptId));
        }

        /// <summary>
        /// Delete Cost
        /// </summary>
        /// <remarks>Deletes specific cost </remarks>
        /// <param name="userId">User ID</param>
        /// <param name="propertyId">Property ID</param>
        /// <param name="costId">Cost Id</param>
        /// <response code="200">OK</response>
        /// <response code="404">Cost Not Found</response>
        /// <returns>Deleted Successfully</returns>
        [HttpDelete]
        [Route("DeleteCost")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCost([FromQuery] int userId, [FromQuery] int propertyId, [FromQuery] int costId)
        {
            return await this.Result<string>(await this.accountingClient.DeleteCost(this.CurrentUser.ExternalToken, userId, propertyId, costId));
        }

        /// <summary>
        /// Save costs
        /// </summary>
        /// <remarks>Save cost information about one specific selected property (Building), which is editable later on.</remarks>
        /// <param name="information">Information</param>
        /// <response code="200">OK</response>
        /// <response code="400">Not Found</response>
        /// <response code="409">Validation Errors</response>
        /// <returns>Ok</returns>
        [HttpPost]
        [Route("SaveCosts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(TEHA.Portal.Data.Models.Validation.Response))]
        public async Task<IActionResult> SaveCosts([FromBody] CostData information)
        {
            return await this.Result<CostData>(await this.accountingClient.SaveCosts(this.CurrentUser.ExternalToken, information));
        }

        /// <summary>
        /// Save Flat Users
        /// </summary>
        /// <remarks>Saves flat users of accounting, which can be edited later on.</remarks>
        /// <param name="flatData">FlatData</param>
        /// <response code="200">OK</response>
        /// <response code="400">Not Found</response>
        /// <response code="409">Validation Errors</response>
        /// <returns>Ok</returns>
        [HttpPost]
        [Route("SaveFlatUsers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(TEHA.Portal.Data.Models.Validation.Response))]
        public async Task<IActionResult> SaveFlatUsers([FromBody] FlatData flatData)
        {
            return await this.Result<FlatData>(await this.accountingClient.SaveFlatUsers(this.CurrentUser.ExternalToken, flatData));
        }

        /// <summary>
        /// Get Last Updated Date
        /// </summary>
        /// <remarks>Get Last Updated Dates.</remarks>
        /// <param name="userId">User ID, to enforce authorization.</param>
        /// <param name="propertyId">Property ID</param>
        /// <param name="payrollYear">Payroll Year</param>
        /// <response code="200">OK</response>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Not Found</response>
        /// <returns>Data.Models.Accounting.LastUpdatedDates</returns>
        [HttpGet]
        [Route("GetLastUpdatedDates")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Data.Models.Accounting.LastUpdatedDates>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetLastUpdatedDates([FromQuery] int userId, [FromQuery] int propertyId, [FromQuery] int payrollYear)
        {
            return await this.Result<LastUpdatedDates>(await this.accountingClient.GetLastUpdatedDate(this.CurrentUser.ExternalToken, userId, propertyId, payrollYear));
        }

        /// <summary>
        /// Get Summary And Release Info
        /// </summary>
        /// <param name="userId">User ID, to enforce authorization.</param>
        /// <param name="propertyId">Property ID</param>
        /// <param name="payrollYear">Payroll Year</param>
        /// <returns>SummaryAndRelease</returns>
        [HttpGet]
        [Route("GetSummaryAndReleaseInfo")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Data.Models.Accounting.SummaryAndRelease>))]
        public async Task<IActionResult> GetSummaryAndReleaseInfo([FromQuery] int userId, [FromQuery] int propertyId, [FromQuery] int payrollYear)
        {
            return await this.Result<SummaryAndRelease>(await this.accountingClient.GetSummaryAndReleaseInfo(this.CurrentUser.ExternalToken, userId, propertyId, payrollYear));
        }

        /// <summary>
        /// Set Summary And Release Info
        /// </summary>
        /// <param name="summaryAndRelease">BlockPeriodRequest</param>
        /// <returns>ok</returns>
        [HttpPost]
        [Route("SetSummaryAndReleaseInfo")]
        public async Task<IActionResult> SaveSummaryAndReleaseInfo([FromBody] SummaryAndRelease summaryAndRelease)
        {
            return await this.Result<string>(await this.accountingClient.SaveSummaryAndReleaseInfo(this.CurrentUser.ExternalToken, summaryAndRelease));
        }

        /// <summary>
        /// Delete Onwer
        /// </summary>
        /// <remarks>Deletes specific cost </remarks>
        /// <param name="userId">User ID</param>
        /// <param name="propertyId">Property ID</param>
        /// /// <param name="flatId">flat Id</param>
        /// <param name="onwerId">Onwer Id</param>
        /// <response code="200">OK</response>
        /// <response code="404">Cost Not Found</response>
        /// <returns>Deleted Successfully</returns>
        [HttpDelete]
        [Route("DeleteOnwer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteOnwer([FromQuery] int userId, [FromQuery] int propertyId, [FromQuery] int flatId, [FromQuery] int onwerId)
        {
            return await this.Result<string>(await this.accountingClient.DeleteOnwer(this.CurrentUser.ExternalToken, userId, propertyId, flatId, onwerId));
        }

        /// <summary>
        /// Delete Cost
        /// </summary>
        /// <remarks>Deletes specific cost </remarks>
        /// <param name="userId">User ID</param>
        /// <param name="propertyId">Property ID</param>
        /// <param name="flatId">flat Id</param>
        /// /// <param name="rentId">rent Id</param>
        /// <response code="200">OK</response>
        /// <response code="404">Cost Not Found</response>
        /// <returns>Deleted Successfully</returns>
        [HttpDelete]
        [Route("DeleteRent")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteRent([FromQuery] int userId, [FromQuery] int propertyId, [FromQuery] int flatId, [FromQuery] int rentId)
        {
            return await this.Result<string>(await this.accountingClient.DeleteRent(this.CurrentUser.ExternalToken, userId, propertyId, flatId, rentId));
        }
    }
}
