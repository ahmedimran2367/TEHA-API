// <copyright file="DocumentArchivesControllerTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.API.Test.DocumentArchives
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using FluentAssertions;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using TEHA.Portal.API.Controllers;
    using TEHA.Portal.API.Helpers;
    using TEHA.Portal.API.Test.Helper;
    using TEHA.Portal.Data.Models.Common;
    using TEHA.Portal.Data.Models.Document;
    using TEHA.Portal.ProxyAPI.Clients.Document;
    using TEHA.Portal.ProxyAPI.Clients.StockOverview;
    using Xunit;

    /// <summary>
    /// Contains stock overview test cases.
    /// </summary>
    [Trait("Category", "DocumentArchives")]
    public class DocumentArchivesControllerTest : TestBase
    {
        private readonly string path = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName}/Json/StockOverview";

        private readonly IDocumentClient documentClient = new DocumentClient();
        private readonly IStockOverviewClient stockOverviewClient = new StockOverviewClient();

        private readonly Dictionary<string, string> documentTypes = new Dictionary<string, string>()
        {
            { "R", "Reading" },
            { "A", "Accounting" },
            { "P", "Plumbing" },
            { "D", "Drinking Water Samples" },
            { "E", "Energy Certificates" },
            { "I", "InvoiceService" },
        };

        /// <summary>
        /// Get Documents unit test
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="propertyId">Property Id</param>
        /// <param name="type">Document Type</param>
        /// <returns>ok</returns>
        [Theory]
        [InlineData("2", 39541, "R")]
        public async Task GetDocuments_Should_Return_OK(string username, int propertyId, string type)
        {
            DocumentArchivesController sut = new DocumentArchivesController(this.documentClient);

            sut.CurrentUser = await this.GetUser(username);

            var okResult = await sut.GetDocuments(sut.CurrentUser.Id, propertyId, null, type) as ObjectResult;

            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.IsType<List<DocumentInfo>>((okResult.Value as Response<List<DocumentInfo>>).Data);
            (okResult.Value as Response<List<DocumentInfo>>).Data.All(d => d.Type == this.documentTypes[type]).Should().BeTrue();
        }

        /// <summary>
        /// Get Documents unit test
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>ok</returns>
        [Theory]
        [InlineData("2")]
        [InlineData("3168")]
        [InlineData("2234")]
        [InlineData("134")]
        [InlineData("2817")]
        [InlineData("2270")]
        [InlineData("2318")]
        [InlineData("5451")]
        [InlineData("4606")]
        [InlineData("3804")]
        public async Task GetDocuments_Should_Return_OK_ALL_Types(string username)
        {
            DocumentArchivesController sut = new DocumentArchivesController(this.documentClient);
            StockOverviewController stockOverviewController = new StockOverviewController(this.stockOverviewClient);

            PropertyRequest propertyRequest = JsonConvert.DeserializeObject<PropertyRequest>(File.ReadAllText($"{this.path}/DefaultPropertyRequest.json"));

            sut.CurrentUser = await this.GetUser(username);
            stockOverviewController.CurrentUser = sut.CurrentUser;

            propertyRequest.UserId = sut.CurrentUser.Id;
            propertyRequest.IncludeChildren = false;
            propertyRequest.PageSize = 1000;
            var propertyResult = await stockOverviewController.GetProperties(propertyRequest) as ObjectResult;

            var properties = (propertyResult.Value as Response<PropertyResult>).Data.Items;

            var hasOtherDocuments = false;
            foreach (var property in properties)
            {
                var okResult = await sut.GetDocuments(sut.CurrentUser.Id, property.Id, null, "ALL") as ObjectResult;

                if (okResult.StatusCode == StatusCodes.Status200OK)
                {
                    Assert.IsType<List<DocumentInfo>>((okResult.Value as Response<List<DocumentInfo>>).Data);
                    hasOtherDocuments = (okResult.Value as Response<List<DocumentInfo>>).Data.Any(d => d.Type != "Reading");
                    if (hasOtherDocuments)
                    {
                        break;
                    }
                }
            }

            hasOtherDocuments.Should().BeTrue();
        }

        /// <summary>
        /// Get documents unit test with payroll
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="propertyId">Property Id</param>
        /// <param name="payrollYear">PayrollYear Id</param>
        /// <param name="type">Document Type</param>
        /// <returns>ok</returns>
        [Theory]
        [InlineData("2", 39541, 190148, "R")]
        public async Task GetDocuments_Should_Return_Documents_with_Specific_Payroll(string username, int propertyId, int payrollYear, string type)
        {
            DocumentArchivesController sut = new DocumentArchivesController(this.documentClient);

            sut.CurrentUser = await this.GetUser(username);

            var okResult = await sut.GetDocuments(sut.CurrentUser.Id, propertyId, payrollYear, type) as ObjectResult;

            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            (okResult.Value as Response<List<DocumentInfo>>).Data.All(d => d.PayrollYearId == payrollYear).Should().BeTrue();
            (okResult.Value as Response<List<DocumentInfo>>).Data.All(d => d.Type == this.documentTypes[type]).Should().BeTrue();
        }

        /// <summary>
        /// Get Documents unit test with invalid data
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="propertyId">Property Id</param>
        /// <param name="type">Document Type</param>
        /// <returns>ok</returns>
        [Theory]
        [InlineData("2", 39540, "R")]
        [InlineData("2", 39541, "I")]
        [InlineData("134", 39542, "R")]
        public async Task GetDocuments_Should_Return_Not_Found_with_Invalid_Info(string username, int propertyId, string type)
        {
            DocumentArchivesController sut = new DocumentArchivesController(this.documentClient);

            sut.CurrentUser = await this.GetUser(username);

            var errorResult = await sut.GetDocuments(sut.CurrentUser.Id, propertyId, null, type) as ObjectResult;

            Assert.Equal(StatusCodes.Status404NotFound, errorResult.StatusCode);
        }

        /// <summary>
        /// Get SEPA Document unit test
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="propertyId">Property Id</param>
        /// <param name="newInd">New Indicator</param>
        /// <returns>ok</returns>
        [Theory]
        [InlineData("2", 39541, true)]
        [InlineData("2", 39412, true)]
        [InlineData("134", 74772, true)]
        [InlineData("134", 40877, true)]
        public async Task GetSEPADocument_Should_Return_OK(string username, int propertyId, bool newInd)
        {
            DocumentArchivesController sut = new DocumentArchivesController(this.documentClient);

            sut.CurrentUser = await this.GetUser(username);

            var okResult = await sut.GetSEPADocument(sut.CurrentUser.Id, propertyId, newInd) as ObjectResult;

            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.IsType<byte[]>((okResult.Value as Response<byte[]>).Data);
        }

        /// <summary>
        /// Get SEPA Document unit test with invalid data
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="propertyId">Property Id</param>
        /// <param name="newInd">New Indicator</param>
        /// <returns>ok</returns>
        [Theory]
        [InlineData("134", 39540, true)]
        [InlineData("2", 39541, false)]
        [InlineData("134", 39542, true)]
        public async Task GetSEPADocument_Should_Return_Not_Found_with_Invalid_Info(string username, int propertyId, bool newInd)
        {
            DocumentArchivesController sut = new DocumentArchivesController(this.documentClient);

            sut.CurrentUser = await this.GetUser(username);

            var errorResult = await sut.GetSEPADocument(sut.CurrentUser.Id, propertyId, newInd) as ObjectResult;

            Assert.Equal(StatusCodes.Status404NotFound, errorResult.StatusCode);
        }

        /// <summary>
        /// Get Documents unit test
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>ok</returns>
        [Theory]
        [InlineData("2")]
        public async Task GetAllSEPADocuments_Should_Return_OK(string username)
        {
            DocumentArchivesController sut = new DocumentArchivesController(this.documentClient);

            sut.CurrentUser = await this.GetUser(username);

            var okResult = await sut.GetAllSEPADocuments(sut.CurrentUser.Id) as ObjectResult;

            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.IsType<List<Data.Models.Contract.PropertyInfo>>((okResult.Value as Response<List<Data.Models.Contract.PropertyInfo>>).Data);
        }

        /// <summary>
        /// Get All SEPA Document unit test with invalid data
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>ok</returns>
        [Theory]
        [InlineData("134")]
        [InlineData("2")]
        public async Task GetAllSEPADocuments_Should_Return_Not_Found_with_Invalid_Info(string username)
        {
            DocumentArchivesController sut = new DocumentArchivesController(this.documentClient);

            sut.CurrentUser = await this.GetUser(username);
            sut.CurrentUser.Id = 1;

            var errorResult = await sut.GetAllSEPADocuments(sut.CurrentUser.Id) as ObjectResult;

            Assert.Equal(StatusCodes.Status404NotFound, errorResult.StatusCode);
        }

        /// <summary>
        /// Get Document Content unit test
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="id">Document Id</param>
        /// <param name="propertyId">Property Id</param>
        /// <param name="type">Document type</param>
        /// <returns>ok</returns>
        [Theory]

        // [InlineData("134", 643306, 40877, "R")]
        // [InlineData("134", 632796, 40877, "R")]
        [InlineData("2", 60542, 39541, "I")]
        [InlineData("2", 65910, 39541, "I")]
        public async Task GetDocumentContent_Should_Return_OK(string username, int id, int propertyId, string type)
        {
            DocumentArchivesController sut = new DocumentArchivesController(this.documentClient);

            sut.CurrentUser = await this.GetUser(username);

            var okResult = await sut.GetDocumentContent(sut.CurrentUser.Id, id, propertyId, this.documentTypes[type]) as ObjectResult;

            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.IsType<byte[]>((okResult.Value as Response<byte[]>).Data);
        }

        /// <summary>
        /// Get Document Content unit test with invalid info
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="id">Document Id</param>
        /// <param name="propertyId">Property Id</param>
        /// <param name="type">Document type</param>
        /// <returns>ok</returns>
        [Theory]
        [InlineData("2", 643306, 40877, "R")]
        [InlineData("2", 62796, 40877, "R")]
        [InlineData("134", 455824, 39541, "R")]
        [InlineData("134", 455825, 39541, "I")]
        public async Task GetDocumentContent_Should_Return_Not_Found_with_Invalid_Info(string username, int id, int propertyId, string type)
        {
            DocumentArchivesController sut = new DocumentArchivesController(this.documentClient);

            sut.CurrentUser = await this.GetUser(username);

            var errorResult = await sut.GetDocumentContent(sut.CurrentUser.Id, id, propertyId, type) as ObjectResult;
            Assert.Equal(StatusCodes.Status404NotFound, errorResult.StatusCode);
        }

        /// <summary>
        /// Get Invoices unit test
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="propertyId">Property Id</param>
        /// <returns>ok</returns>
        [Theory]
        [InlineData("2", 39541)]
        [InlineData("134", 40877)]
        public async Task GetInvoices_Should_Return_OK(string username, int propertyId)
        {
            DocumentArchivesController sut = new DocumentArchivesController(this.documentClient);

            sut.CurrentUser = await this.GetUser(username);

            var okResult = await sut.GetInvoices(sut.CurrentUser.Id, propertyId, null) as ObjectResult;

            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.IsType<List<Invoice>>((okResult.Value as Response<List<Invoice>>).Data);
        }

        /// <summary>
        /// Get documents unit test with payroll
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="propertyId">Property Id</param>
        /// <param name="payrollYear">PayrollYear Id</param>
        /// <returns>ok</returns>
        [Theory]
        [InlineData("2", 39541, 190148)]
        public async Task GetInvoices_Should_Return_Documents_with_Specific_Payroll(string username, int propertyId, int payrollYear)
        {
            DocumentArchivesController sut = new DocumentArchivesController(this.documentClient);

            sut.CurrentUser = await this.GetUser(username);

            var okResult = await sut.GetInvoices(sut.CurrentUser.Id, propertyId, payrollYear) as ObjectResult;

            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        }

        /// <summary>
        /// Get Invoices unit test with invalid data
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="propertyId">Property Id</param>
        /// <returns>ok</returns>
        [Theory]
        [InlineData("2", 39741)]
        [InlineData("134", 40877)]
        public async Task GetInvoices_Should_Return_Not_Found_with_Invalid_Info(string username, int propertyId)
        {
            DocumentArchivesController sut = new DocumentArchivesController(this.documentClient);

            sut.CurrentUser = await this.GetUser(username);
            sut.CurrentUser.Id = 1;

            var errorResult = await sut.GetInvoices(sut.CurrentUser.Id, propertyId, null) as ObjectResult;

            Assert.Equal(StatusCodes.Status404NotFound, errorResult.StatusCode);
        }

        /// <summary>
        /// GetAccountingDocumentByFlat unit test
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="propertyId">propertyId</param>
        /// <param name="payrolYear">payrolYear</param>
        /// <returns>ok</returns>
        [Theory]
        [InlineData("4606", 99, 2020)]
        public async Task GetAccountingDocumentByFlat_Should_Return_OK(string username, int propertyId, int payrolYear)
        {
            DocumentArchivesController sut = new DocumentArchivesController(this.documentClient);

            sut.CurrentUser = await this.GetUser(username);

            var okResult = await sut.GetAccountingDocumentByFlat(sut.CurrentUser.Id, propertyId, payrolYear) as ObjectResult;

            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        }

        /// <summary>
        /// GetAccountingDocumentByFlat unit test
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="propertyId">propertyId</param>
        /// <param name="payrolYear">payrolYear</param>
        /// <returns>ok</returns>
        [Theory]
        [InlineData("4606", 99, 2020)]
        public async Task GetAccountingDocumentByFlat_Should_Return_NotFound(string username, int propertyId, int payrolYear)
        {
            DocumentArchivesController sut = new DocumentArchivesController(this.documentClient);

            sut.CurrentUser = await this.GetUser(username);
            sut.CurrentUser.Id = 1;

            var errorResult = await sut.GetAccountingDocumentByFlat(sut.CurrentUser.Id, propertyId, payrolYear) as ObjectResult;

            Assert.Equal(StatusCodes.Status404NotFound, errorResult.StatusCode);
        }

        /// <summary>
        /// GetAccountingFlatDocumentContent unit test
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="rentId">rentId</param>
        /// <param name="propertyId">propertyId</param>
        /// <returns>ok</returns>
        [Theory]
        [InlineData("4606", 20, 8)]
        public async Task GetAccountingFlatDocumentContent_Should_Return_OK(string username, int rentId, int? propertyId)
        {
            DocumentArchivesController sut = new DocumentArchivesController(this.documentClient);

            sut.CurrentUser = await this.GetUser(username);

            var okResult = await sut.GetAccountingFlatDocumentContent(sut.CurrentUser.Id, rentId, propertyId) as ObjectResult;

            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        }

        /// <summary>
        /// GetAccountingFlatDocumentContent unit test
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="rentId">rentId</param>
        /// <param name="propertyId">propertyId</param>
        /// <returns>ok</returns>
        [Theory]
        [InlineData("4606", 20, 8)]
        public async Task GetAccountingFlatDocumentContent_Should_Return_NotFound(string username, int rentId, int? propertyId)
        {
            DocumentArchivesController sut = new DocumentArchivesController(this.documentClient);

            sut.CurrentUser = await this.GetUser(username);
            sut.CurrentUser.Id = 1;

            var errorResult = await sut.GetAccountingFlatDocumentContent(sut.CurrentUser.Id, rentId, propertyId) as ObjectResult;

            Assert.Equal(StatusCodes.Status404NotFound, errorResult.StatusCode);
        }
    }
}
