// <copyright file="ContractControllerTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.API.Test
{
    using System.IO;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using TEHA.Portal.API.Controllers;
    using TEHA.Portal.API.Test.Helper;
    using TEHA.Portal.ProxyAPI.Clients.Contract;
    using Xunit;

    /// <summary>
    /// Contains Contract test cases.
    /// </summary>
    [Trait("Category", "Contract")]
    public class ContractControllerTest : TestBase
    {
        private readonly string path = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName}/Json/Contract";

        private readonly ContractClient contractClient = new ContractClient();

        /// <summary>
        /// Contract search ok
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>Task</returns>
        [Theory]
        [InlineData("2")]
        [InlineData("134")]
        public async Task Get_Should_Return_OK(string username)
        {
            ContractController sut = new ContractController(this.contractClient);
            sut.CurrentUser = await this.GetUser(username);
            var okResult = await sut.Get(sut.CurrentUser.Id) as ObjectResult;
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        }

        /// <summary>
        /// Contract search not found
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>Task</returns>
        [Theory]
        [InlineData("2")]
        public async Task Get_Should_Return_NotFound(string username)
        {
            ContractController sut = new ContractController(this.contractClient);
            sut.CurrentUser = await this.GetUser(username);
            var okResult = await sut.Get(sut.CurrentUser.Id) as ObjectResult;
            Assert.Equal(StatusCodes.Status404NotFound, okResult.StatusCode);
        }

        /// <summary>
        /// Get Contract Document ok
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="propertyId">PropertyId</param>
        /// <param name="documentId">DocumentId</param>
        /// <returns>task</returns>
        [Theory]
        [InlineData("2", 39541, 23430)]
        public async Task Contract_Document_Should_Return_OK(string username, int propertyId, int documentId)
        {
            ContractController sut = new ContractController(this.contractClient);
            sut.CurrentUser = await this.GetUser(username);
            var okResult = await sut.GetContractDocument(sut.CurrentUser.Id, propertyId, documentId) as ObjectResult;
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        }

        /// <summary>
        /// Get Contract Document not found
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="propertyId">PropertyId</param>
        /// <param name="documentId">DocumentId</param>
        /// <returns>task</returns>
        [Theory]
        [InlineData("2", 39541, 22)]
        public async Task Contract_Document_Should_Return_NotFound(string username, int propertyId, int documentId)
        {
            ContractController sut = new ContractController(this.contractClient);
            sut.CurrentUser = await this.GetUser(username);
            var okResult = await sut.GetContractDocument(sut.CurrentUser.Id, propertyId, documentId) as ObjectResult;
            Assert.Equal(StatusCodes.Status404NotFound, okResult.StatusCode);
        }
    }
}
