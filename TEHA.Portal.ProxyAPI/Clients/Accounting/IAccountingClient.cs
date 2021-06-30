// <copyright file="IAccountingClient.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.ProxyAPI.Clients.Accounting
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using TEHA.Portal.Data.Models.Accounting;

    /// <summary>
    /// Accounting endpoints methods
    /// </summary>
    public interface IAccountingClient
    {
        /// <summary>
        /// Gets accounting information by year
        /// </summary>
        /// <remarks>Gets accounting information by year. Use to populate previuse year data while accounting process</remarks>
        /// <param name="token">token</param>
        /// <param name="userId">User ID</param>
        /// <param name="propertyId">Property ID</param>
        /// <param name="year">Payroll year</param>
        /// <returns>TEHA.Portal.Data.Models.Accounting.Information</returns>
        public Task<HttpResponseMessage> GetCosts(string token, int userId, int propertyId, int year);

        /// <summary>
        /// Get Flat USers
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="userId">User ID, to enforce authorization.</param>
        /// <param name="propertyId">Property ID</param>
        /// <param name="year">Payroll Year</param>
        /// <returns>List of Data.Models.Accounting.FlatData</returns>
        public Task<HttpResponseMessage> GetFlatUsers(string token, int userId, int propertyId, int year);

        /// <summary>
        /// Submit cost
        /// </summary>
        /// <param name="token">JWT Token</param>
        /// <param name="blockPeriodRequest">BlockPeriodRequest</param>
        /// <returns>Submit successfuly</returns>
        public Task<HttpResponseMessage> Submit(string token, BlockPeriodRequest blockPeriodRequest);

        /// <summary>
        /// Delete Concept
        /// </summary>
        /// <remarks>Delete specific cost concept.</remarks>
        /// <param name="token">JWT Token</param>
        /// <param name="userId">User ID</param>
        /// <param name="propertyId">Property ID</param>
        /// <param name="conceptId">Concept Id</param>
        /// <response code="200">OK</response>
        /// <response code="404">Concept Not Found</response>
        /// <returns>Deleted Successfully</returns>
        public Task<HttpResponseMessage> DeleteConcept(string token, int userId, int propertyId, int conceptId);

        /// <summary>
        /// Delete Cost
        /// </summary>
        /// <remarks>Deletes specific cost </remarks>
        /// <param name="token">JWT Token</param>
        /// <param name="userId">User ID</param>
        /// <param name="propertyId">Property ID</param>
        /// <param name="costId">Cost Id</param>
        /// <response code="200">OK</response>
        /// <response code="404">Cost Not Found</response>
        /// <returns>HttpResponseMessage</returns>
        public Task<HttpResponseMessage> DeleteCost(string token, int userId, int propertyId, int costId);

        /// <summary>
        /// Save costs
        /// </summary>
        /// <remarks>Save cost information about one specific selected property (Building), which is editable later on.</remarks>
        /// <param name="token">JWT Token</param>
        /// <param name="information">Information</param>
        /// <response code="200">OK</response>
        /// <response code="400">Not Found</response>
        /// <response code="409">Validation Errors</response>
        /// <returns>HttpResponseMessage</returns>
        public Task<HttpResponseMessage> SaveCosts(string token, CostData information);

        /// <summary>
        /// Save Flat Users
        /// </summary>
        /// <remarks>Saves flat users of accounting, which can be edited later on.</remarks>
        /// <param name="token">JWT token</param>
        /// <param name="flatData">FlatData</param>
        /// <response code="200">OK</response>
        /// <response code="400">Not Found</response>
        /// <response code="409">Validation Errors</response>
        /// <returns>HttpResponseMessage</returns>
        public Task<HttpResponseMessage> SaveFlatUsers(string token, FlatData flatData);

        /// <summary>
        /// Get Last Updated Date
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="userId">User ID, to enforce authorization.</param>
        /// <param name="propertyId">Property ID</param>
        /// <param name="year">Payroll Year</param>
        /// <returns>List of Data.Models.Accounting.FlatData</returns>
        public Task<HttpResponseMessage> GetLastUpdatedDate(string token, int userId, int propertyId, int year);

        /// <summary>
        /// Get Summary And Release Info
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="userId">User ID, to enforce authorization.</param>
        /// <param name="propertyId">Property ID</param>
        /// <param name="year">Payroll Year</param>
        /// <returns>SummaryAndRelease</returns>
        public Task<HttpResponseMessage> GetSummaryAndReleaseInfo(string token, int userId, int propertyId, int year);

        /// <summary>
        /// Set Summary And Release Info
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="summaryAndRelease">BlockPeriodRequest</param>
        /// <returns>ok</returns>
        public Task<HttpResponseMessage> SaveSummaryAndReleaseInfo(string token, SummaryAndRelease summaryAndRelease);

        /// <summary>
        /// Get Accounting Periods
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="accountingRequest">AccountingRequest</param>
        /// <returns>HttpResponseMessage</returns>
        public Task<HttpResponseMessage> GetAccountingPeriods(string token, AccountingRequest accountingRequest);

        /// <summary>
        /// Delete Onwer
        /// </summary>
        /// <remarks>Deletes specific Onwer </remarks>
        /// <param name="token">JWT Token</param>
        /// <param name="userId">User ID</param>
        /// <param name="propertyId">Property ID</param>
        /// /// <param name="flatId">flat Id</param>
        /// <param name="onwerId">Onwer Id</param>
        /// <response code="200">OK</response>
        /// <response code="404">Cost Not Found</response>
        /// <returns>HttpResponseMessage</returns>
        public Task<HttpResponseMessage> DeleteOnwer(string token, int userId, int propertyId, int flatId,int onwerId);

        /// <summary>
        /// Delete Rent
        /// </summary>
        /// <remarks>Deletes specific Onwer </remarks>
        /// <param name="token">JWT Token</param>
        /// <param name="userId">User ID</param>
        /// <param name="propertyId">Property ID</param>
        /// <param name="flatId">flat Id</param>
        /// /// <param name="rentId">rent Id</param>
        /// <response code="200">OK</response>
        /// <response code="404">Cost Not Found</response>
        /// <returns>HttpResponseMessage</returns>
        public Task<HttpResponseMessage> DeleteRent(string token, int userId, int propertyId, int flatId, int rentId);
    }
}
