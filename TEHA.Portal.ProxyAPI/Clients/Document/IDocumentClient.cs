// <copyright file="IDocumentClient.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.ProxyAPI.Clients.Document
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using TEHA.Portal.Data.Models.Document;

    /// <summary>
    /// DocumentArchives endpoint methods
    /// </summary>
    public interface IDocumentClient
    {
        /// <summary>
        /// Get Documents
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="body">Get Documents Request</param>
        /// <returns>HttpResponseMessage</returns>
        public Task<HttpResponseMessage> GetDocuments(string token, GetDocumentsRequest body);

        /// <summary>
        /// Get SEPA document byte array
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="userId">User</param>
        /// <param name="propertyId">property Id</param>
        /// <param name="newInd">New Indicator</param>
        /// <returns>HttpResponseMesage</returns>
        public Task<HttpResponseMessage> GetSEPADocument(string token, int userId, int propertyId, bool newInd);

        /// <summary>
        /// Get All SEPA Documents
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="userId">User ID</param>
        /// <returns>HttpResponseMessage</returns>
        public Task<HttpResponseMessage> GetAllSEPADocuments(string token, int userId);

        /// <summary>
        /// Gets document content by id
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="userId">User Id to enforce authorization</param>
        /// <param name="id">Document Id</param>
        /// <param name="propertyId">Property Id</param>
        /// <param name="type">Type/Category of the document e.g. Accounting, Invoice etc.</param>
        /// <param name="levelIndicator">Enum for level indicator: "P" => Download all property level documents. "F" => Download All Flat level documents. "M" => Download All Meter Documents</param>
        /// <param name="payrollYearId">Payroll year Id required when Type = 'A' or 'R'  and LevelIndicator is Not Null</param>
        /// <returns>HttpResponseMessage</returns>
        public Task<HttpResponseMessage> GetDocumentContent(string token, int userId, int id, int propertyId, string type, string levelIndicator, int? payrollYearId);

        /// <summary>
        /// Get Invoices
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="userId">User Id</param>
        /// <param name="propertyId">property ID</param>
        /// <param name="payrollYear">Payroll year for which the document(s) is/are requested</param>
        /// <returns>HttpResponseMessage</returns>
        public Task<HttpResponseMessage> GetInvoices(string token, int userId, int? propertyId, int? payrollYear);

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
        public Task<HttpResponseMessage> GetAccountingDocumentByFlat(string token, int userId, int propertyId, int payrollYear);

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
        public Task<HttpResponseMessage> GetAccountingFlatDocumentContent(string token, int userId, int rentId, int? propertyId);
    }
}
