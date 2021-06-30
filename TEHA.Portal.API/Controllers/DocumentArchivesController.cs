// <copyright file="DocumentArchivesController.cs" company="PlaceholderCompany">
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
    using TEHA.Portal.Data.Models.Document;
    using TEHA.Portal.ProxyAPI.Clients.Document;

    /// <summary>
    /// Implements document archives endpoints
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentArchivesController : ApiControllerBase
    {
        private readonly IDocumentClient documentClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentArchivesController"/> class.
        /// </summary>
        /// <param name="documentClient">Document Client</param>
        public DocumentArchivesController(IDocumentClient documentClient)
        {
            this.documentClient = documentClient;
        }

        /// <summary>
        /// Get Documents
        /// </summary>
        /// <remarks>This endpoint returns a list of all documents related to selected properties(buildings) based on type</remarks>
        /// <param name="body">Get Document Request</param>
        /// <response code="200">OK</response>
        /// <response code="404">No Document Found.</response>
        /// <returns>DocumentInfo</returns>
        [HttpPost]
        [Route("GetDocuments")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetDocumentsResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetDocuments([FromBody] GetDocumentsRequest body)
        {
            return await this.Result<GetDocumentsResponse>(await this.documentClient.GetDocuments(this.CurrentUser.ExternalToken, body));
        }

        /// <summary>
        /// Get SEPA document byte array
        /// </summary>
        /// <remarks>SEPA Direct Debit Mandate process will remain as it is as it includes legal obligations to access bank accounts.
        /// This section will have the downloadable permission form</remarks>
        /// <param name="userId">User</param>
        /// <param name="propertyId">property Id</param>
        /// <param name="newInd">New Indicator</param>
        /// <response code="200">OK</response>
        /// <response code="400">Document not found.</response>
        /// <returns>Base64 byte array of the document</returns>
        [HttpGet]
        [Route("GetSEPADocument")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FileContentResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetSEPADocument(int userId, int propertyId, bool newInd)
        {
            return await this.Result<FileContentResponse>(await this.documentClient.GetSEPADocument(this.CurrentUser.ExternalToken, userId, propertyId, newInd));
        }

        /// <summary>
        /// Get All SEPA Documents
        /// </summary>
        /// <remarks>Get All SEPA document property wise.</remarks>
        /// <param name="userId">User ID</param>
        /// <response code="200">OK</response>
        /// <response code="400">Not found</response>
        /// <returns>List of Data.Models.Contract.PropertyInfo</returns>
        [HttpGet]
        [Route("GetAllSEPADocuments")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Data.Models.Contract.PropertyInfo>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllSEPADocuments([FromQuery] int userId)
        {
            return await this.Result<List<Data.Models.Contract.PropertyInfo>>(await this.documentClient.GetAllSEPADocuments(this.CurrentUser.ExternalToken, userId));
        }

        /// <summary>
        /// Gets document content by id
        /// </summary>
        /// <remarks>This endpoint gets the specific document by id</remarks>
        /// <param name="userId">User Id to enforce authorization</param>
        /// <param name="id">Document Id</param>
        /// <param name="propertyId">Property Id</param>
        /// <param name="type">Type/Category of the document e.g. Accounting, Invoice etc.</param>
        /// <param name="levelIndicator">Enum for level indicator: "P" => Download all property level documents. "F" => Download All Flat level documents. "M" => Download All Meter Documents</param>
        /// <param name="payrollYearId">Payroll year Id required when Type = 'A' or 'R'  and LevelIndicator is Not Null</param>
        /// <response code="200">OK</response>
        /// <response code="404">No document found</response>
        /// <returns>base64 string</returns>
        [HttpGet]
        [Route("GetDocumentContent")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FileContentResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetDocumentContent([FromQuery]int userId, [FromQuery]int id, [FromQuery]int propertyId, [FromQuery]string type, [FromQuery]string levelIndicator, [FromQuery]int? payrollYearId)
        {
            return await this.Result<FileContentResponse>(await this.documentClient.GetDocumentContent(this.CurrentUser.ExternalToken, userId, id, propertyId, type, levelIndicator, payrollYearId));
        }

        /// <summary>
        /// Get Invoices
        /// </summary>
        /// <remarks>This endpoint returns a list of invoices related to selected properties(buildings)</remarks>
        /// <param name="userId">User Id</param>
        /// <param name="propertyId">property ID</param>
        /// <param name="payrollYear">Payroll year for which the document(s) is/are requested</param>
        /// <response code="200">OK</response>
        /// <response code="404">No Invoices found</response>
        /// <returns>List<Invoice></returns>
        [HttpGet]
        [Route("GetInvoices")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Invoice>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetInvoices([FromQuery]int userId, [FromQuery] int? propertyId, [FromQuery]int? payrollYear)
        {
            return await this.Result<List<Invoice>>(await this.documentClient.GetInvoices(this.CurrentUser.ExternalToken, userId, propertyId, payrollYear));
        }

        /// <summary>
        /// Get accounting document by flat
        /// </summary>
        /// <param name="userId">User ID</param>
        /// <param name="propertyId">Property ID</param>
        /// <param name="payrollYear">Payroll year for which the document(s) is/are requested</param>
        /// <response code="200">OK</response>
        /// <response code="404">No Document Found.</response>
        /// <returns>list</returns>
        [HttpGet]
        [Route("GetAccountingDocumentByFlat")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAccountingDocumentByFlat([FromQuery] int userId, [FromQuery] int propertyId, [FromQuery] int payrollYear)
        {
            return await this.Result<List<AccountingFlatDocumentInfo>>(await this.documentClient.GetAccountingDocumentByFlat(this.CurrentUser.ExternalToken, userId, propertyId, payrollYear));
        }

        /// <summary>
        /// Gets Accounting Flat document content by id
        /// </summary>
        /// <remarks>This endpoint gets the specific document by id</remarks>
        /// <param name="userId">User Id to enforce authorization</param>
        /// <param name="rentId">Rent ID</param>
        /// <param name="propertyId">Property Id</param>
        /// <response code="200">OK</response>
        /// <response code="404">No document found</response>
        /// <returns>empty</returns>
        [HttpGet]
        [Route("GetAccountingFlatDocumentContent")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAccountingFlatDocumentContent([FromQuery] int userId, [FromQuery] int rentId, [FromQuery] int? propertyId)
        {
            return await this.Result<HttpResponse>(await this.documentClient.GetAccountingFlatDocumentContent(this.CurrentUser.ExternalToken, userId, rentId, propertyId));
        }
    }
}
