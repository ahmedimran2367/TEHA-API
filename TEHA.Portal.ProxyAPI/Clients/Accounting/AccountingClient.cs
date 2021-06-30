// <copyright file="AccountingClient.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.ProxyAPI.Clients.Accounting
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using TEHA.Portal.Data.Models.Accounting;
    using TEHA.Portal.ProxyAPI.Constant;

    /// <summary>
    /// Contains Accounting Endpoints
    /// </summary>
    public class AccountingClient : IAccountingClient
    {
        private readonly RestClient restClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountingClient"/> class.
        /// </summary>
        public AccountingClient()
        {
            this.restClient = new RestClient();
        }

        /// <summary>
        /// Gets accounting information by year
        /// </summary>
        /// <remarks>Gets accounting information by year. Use to populate previuse year data while accounting process</remarks>
        /// <param name="token">token</param>
        /// <param name="userId">User ID</param>
        /// <param name="propertyId">Property ID</param>
        /// <param name="year">Payroll year</param>
        /// <response code="200">OK</response>
        /// <returns>TEHA.Portal.Data.Models.Accounting.Information</returns>
        public async Task<HttpResponseMessage> GetCosts(string token, int userId, int propertyId, int year)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("userId", userId.ToString());
            parameters.Add("propertyId", propertyId.ToString());
            parameters.Add("payrollYear", year.ToString());
            return await this.restClient.Get(Url.AccountingGetCosts, parameters, token);
        }

        /// <summary>
        /// Get Flat Users
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="userId">User ID, to enforce authorization.</param>
        /// <param name="propertyId">Property ID</param>
        /// <param name="year">Payroll Year</param>
        /// <returns>List of Data.Models.Accounting.FlatData</returns>
        public async Task<HttpResponseMessage> GetFlatUsers(string token, int userId, int propertyId, int year)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("userId", userId.ToString());
            parameters.Add("propertyId", propertyId.ToString());
            parameters.Add("payrollYear", year.ToString());
            return await this.restClient.Get(Url.AccountingGetFlatUsers, parameters, token);
        }

        /// <summary>
        /// Submit cost
        /// </summary>
        /// <param name="token">JWT Token</param>
        /// <param name="blockPeriodRequest">BlockPeriodRequest</param>
        /// <returns>Submit successfuly</returns>
        public async Task<HttpResponseMessage> Submit(string token, BlockPeriodRequest blockPeriodRequest)
        {
            return await this.restClient.Post(Url.AccountingSubmit, blockPeriodRequest, token);
        }

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
        public async Task<HttpResponseMessage> DeleteConcept(string token, int userId, int propertyId, int conceptId)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("userId", userId.ToString());
            parameters.Add("propertyId", propertyId.ToString());
            parameters.Add("conceptId", conceptId.ToString());
            return await this.restClient.Delete(Url.AccountingDeleteConcept, parameters, token);
        }

        /// <summary>
        /// Delete Cost
        /// </summary>
        /// <remarks>Deletes specific cost</remarks>
        /// <param name="token">JWT Token</param>
        /// <param name="userId">User ID</param>
        /// <param name="propertyId">Property ID</param>
        /// <param name="costId">Cost Id</param>
        /// <response code="200">OK</response>
        /// <response code="404">Cost Not Found</response>
        /// <returns>Deleted Successfully</returns>
        public async Task<HttpResponseMessage> DeleteCost(string token, int userId, int propertyId, int costId)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("userId", userId.ToString());
            parameters.Add("propertyId", propertyId.ToString());
            parameters.Add("costId", costId.ToString());
            return await this.restClient.Delete(Url.AccountingDeleteCost, parameters, token);
        }

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
        public async Task<HttpResponseMessage> SaveCosts(string token, CostData information)
        {
            return await this.restClient.Post(Url.AccountingSaveCosts, information, token);
        }

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
        public async Task<HttpResponseMessage> SaveFlatUsers(string token, FlatData flatData)
        {
            return await this.restClient.Post(Url.AccountingSaveFlatUsers, flatData, token);
        }

        /// <summary>
        /// Get Last Updated Date
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="userId">User ID, to enforce authorization.</param>
        /// <param name="propertyId">Property ID</param>
        /// <param name="year">Payroll Year</param>
        /// <returns>return last updated dates</returns>
        public async Task<HttpResponseMessage> GetLastUpdatedDate(string token, int userId, int propertyId, int year)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("userId", userId.ToString());
            parameters.Add("propertyId", propertyId.ToString());
            parameters.Add("payrollYear", year.ToString());
            return await this.restClient.Get(Url.AccountingGetLastUpdatedDates, parameters, token);
        }

        /// <summary>
        /// Get Summary And Release Info
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="userId">User ID, to enforce authorization.</param>
        /// <param name="propertyId">Property ID</param>
        /// <param name="year">Payroll Year</param>
        /// <returns>SummaryAndRelease</returns>
        public async Task<HttpResponseMessage> GetSummaryAndReleaseInfo(string token, int userId, int propertyId, int year)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("userId", userId.ToString());
            parameters.Add("propertyId", propertyId.ToString());
            parameters.Add("payrollYear", year.ToString());
            return await this.restClient.Get(Url.AccountingGetSummaryAndReleaseInfo, parameters, token);
        }

        /// <summary>
        /// Save Summar And Release Info
        /// </summary>
        /// <param name="token">string</param>
        /// <param name="summaryAndRelease">BlockPeriodRequest</param>
        /// <returns>ok</returns>
        public async Task<HttpResponseMessage> SaveSummaryAndReleaseInfo(string token, SummaryAndRelease summaryAndRelease)
        {
            return await this.restClient.Post(Url.AccountingSetSummaryAndReleaseInfo, summaryAndRelease, token);
        }

        /// <summary>
        /// Get Properties
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="accountingRequest">AccountingRequest</param>
        /// <returns>HttpResponseMessage</returns>
        public async Task<HttpResponseMessage> GetAccountingPeriods(string token, AccountingRequest accountingRequest)
        {
            return await this.restClient.Post(Url.AccountingGetAccountingPeriods, accountingRequest, token);
        }

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
        public async Task<HttpResponseMessage> DeleteOnwer(string token, int userId, int propertyId, int flatId, int onwerId)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("userId", userId.ToString());
            parameters.Add("propertyId", propertyId.ToString());
            parameters.Add("flatId", flatId.ToString());
            parameters.Add("onwerId", onwerId.ToString());
            return await this.restClient.Delete(Url.AccountingDeleteOnwer, parameters, token);
        }

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
        public async Task<HttpResponseMessage> DeleteRent(string token, int userId, int propertyId, int flatId, int rentId)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("userId", userId.ToString());
            parameters.Add("propertyId", propertyId.ToString());
            parameters.Add("flatId", flatId.ToString());
            parameters.Add("rentId", rentId.ToString());
            return await this.restClient.Delete(Url.AccountingDeleteRent, parameters, token);
        }
    }
}
