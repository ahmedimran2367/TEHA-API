// <copyright file="DocumentClient.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.ProxyAPI.Clients.Document
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using TEHA.Portal.Data.Models.Document;
    using TEHA.Portal.ProxyAPI.Constant;

    /// <summary>
    /// Document Client which implements Document Archives endpoints
    /// </summary>
    public class DocumentClient : IDocumentClient
    {
        private readonly RestClient restClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentClient"/> class.
        /// </summary>
        public DocumentClient()
        {
            this.restClient = new RestClient();
        }

        /// <summary>
        /// Get Documents
        /// </summary>
        /// <remarks>This returns a list of all documents related to selected properties(buildings) based on type</remarks>
        /// <param name="token">token</param>
        /// <param name="body">Get Documents Request</param>
        /// <returns>HttpResponseMessage</returns>
        public async Task<HttpResponseMessage> GetDocuments(string token, GetDocumentsRequest body)
        {
            return await this.restClient.Post(Url.DocumentArchivesAll, body, token);
        }

        /// <summary>
        /// Get SEPA document byte array
        /// </summary>
        /// <remarks>SEPA Direct Debit Mandate process will remain as it is as it includes legal obligations to access bank accounts.
        /// This section will have the downloadable permission form</remarks>
        /// <param name="token">token</param>
        /// <param name="userId">User</param>
        /// <param name="propertyId">property Id</param>
        /// <param name="newInd">New Indicator</param>
        /// <returns>HttpResponseMesage</returns>
        public async Task<HttpResponseMessage> GetSEPADocument(string token, int userId, int propertyId, bool newInd)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("userId", userId.ToString());
            parameters.Add("propertyId", propertyId.ToString());
            parameters.Add("newInd", newInd.ToString());

            return await this.restClient.Get(Url.DocumentArchivesGetSEPA, parameters, token);
        }

        /// <summary>
        /// Get All SEPA Documents
        /// </summary>
        /// <remarks>Get All SEPA document property wise.</remarks>
        /// <param name="token">token</param>
        /// <param name="userId">User ID</param>
        /// <returns>HttpResponseMessage</returns>
        public async Task<HttpResponseMessage> GetAllSEPADocuments(string token, int userId)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("userId", userId.ToString());

            return await this.restClient.Get(Url.DocumentArchivesAllSEPA, parameters, token);
        }

        /// <summary>
        /// Gets document content by id
        /// </summary>
        /// <remarks>This gets the specific document content by id</remarks>
        /// <param name="token">token</param>
        /// <param name="userId">User Id to enforce authorization</param>
        /// <param name="id">Document Id</param>
        /// <param name="propertyId">Property Id</param>
        /// <param name="type">Type/Category of the document e.g. Accounting, Invoice etc.</param>
        /// <param name="levelIndicator">Enum for level indicator: "P" => Download all property level documents. "F" => Download All Flat level documents. "M" => Download All Meter Documents</param>
        /// <param name="payrollYearId">Payroll year Id required when Type = 'A' or 'R'  and LevelIndicator is Not Null</param>
        /// <returns>HttpResponseMessage</returns>
        public async Task<HttpResponseMessage> GetDocumentContent(string token, int userId, int id, int propertyId, string type, string levelIndicator, int? payrollYearId)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("userId", userId.ToString());
            if (levelIndicator != null)
            {
                parameters.Add("levelIndicator", levelIndicator.ToString());
            }

            if (payrollYearId != null)
            {
                parameters.Add("payrollYearId", payrollYearId.ToString());
            }

            parameters.Add("id", id.ToString());
            parameters.Add("propertyId", propertyId.ToString());
            parameters.Add("type", type.ToString());

            return await this.restClient.Get(Url.DocumentArchivesGetContent, parameters, token);
        }

        /// <summary>
        /// Get Invoices
        /// </summary>
        /// <remarks>This endpoint returns a list of invoices related to selected properties(buildings)</remarks>
        /// <param name="token">token</param>
        /// <param name="userId">User Id</param>
        /// <param name="propertyId">property ID</param>
        /// <param name="payrollYear">Payroll year for which the document(s) is/are requested</param>
        /// <returns>HttpResponseMessage</returns>
        public async Task<HttpResponseMessage> GetInvoices(string token, int userId, int? propertyId, int? payrollYear)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("userId", userId.ToString());
            parameters.Add("propertyId", propertyId.ToString());
            if (payrollYear != null)
            {
                parameters.Add("payrollYear", payrollYear.ToString());
            }

            return await this.restClient.Get(Url.DocumentArchivesGetInvoices, parameters, token);
        }

        /// <summary>
        /// Get accounting document by flat
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="userId">User ID</param>
        /// <param name="propertyId">Property ID</param>
        /// <param name="payrollYear">Payroll year for which the document(s) is/are requested</param>
        /// <response code="200">OK</response>
        /// <response code="404">No Document Found.</response>
        /// <returns>HttpResponseMessage</returns>
        public async Task<HttpResponseMessage> GetAccountingDocumentByFlat(string token, int userId, int propertyId, int payrollYear)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("userId", userId.ToString());
            parameters.Add("propertyId", propertyId.ToString());
            parameters.Add("payrollYear", payrollYear.ToString());
            return await this.restClient.Get(Url.DocumentArchivesGetAccountingDocumentByFlat, parameters, token);
        }

        /// <summary>
        /// Gets Accounting Flat document content by id
        /// </summary>
        /// <remarks>This endpoint gets the specific document by id</remarks>
        /// <param name="token">token</param>
        /// <param name="userId">User Id to enforce authorization</param>
        /// <param name="rentId">Rent ID</param>
        /// <param name="propertyId">Property Id</param>
        /// <response code="200">OK</response>
        /// <response code="404">No document found</response>
        /// <returns>HttpResponseMessage</returns>
        public async Task<HttpResponseMessage> GetAccountingFlatDocumentContent(string token, int userId, int rentId, int? propertyId)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("userId", userId.ToString());
            parameters.Add("rentId", rentId.ToString());
            if (propertyId != null)
            {
                parameters.Add("propertyId", propertyId.ToString());
            }

            return await this.restClient.Get(Url.DocumentArchivesGetAccountingFlatDocumentContent, parameters, token);
        }
    }
}
