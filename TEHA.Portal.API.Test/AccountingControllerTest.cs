// <copyright file="AccountingControllerTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.API.Test
{
    using System.IO;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using TEHA.Portal.API.Controllers;
    using TEHA.Portal.API.Helpers;
    using TEHA.Portal.API.Test.Helper;
    using TEHA.Portal.Data.Models.Accounting;
    using TEHA.Portal.ProxyAPI.Clients.Accounting;
    using Xunit;

    /// <summary>
    /// Contains Accounting test cases.
    /// </summary>
    [Trait("Category", "Accounting")]
    public class AccountingControllerTest : TestBase
    {
        private readonly string path = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName}/Json/Accounting";

        private readonly AccountingClient accountingClient = new AccountingClient();

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountingControllerTest"/> class.
        /// </summary>
        public AccountingControllerTest()
        {
        }

        /// <summary>
        /// Get Costs unit test
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="propertyID">propertyID</param>
        /// <param name="year">year</param>
        /// <returns>ok</returns>
        [Theory]
        [InlineData("2", 39541, 199769)]
        public async Task GetCosts_Should_Return_OK(string username, int propertyID, int year)
        {
            AccountingController sut = new AccountingController(this.accountingClient);

            sut.CurrentUser = await this.GetUser(username);
            var okResult = await sut.GetCosts(sut.CurrentUser.Id, propertyID, year) as ObjectResult;

            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.IsType<CostData>((okResult.Value as Response<CostData>).Data);
        }

        /// <summary>
        /// GetCosts unit test
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="propertyID">propertyID</param>
        /// <param name="year">year</param>
        /// <returns>Error</returns>
        [Theory]
        [InlineData("2", 23, 2020)]
        public async Task GetCosts_InvalidUserId_Should_Return_NotFound(string username, int propertyID, int year)
        {
            AccountingController sut = new AccountingController(this.accountingClient);

            sut.CurrentUser = await this.GetUser(username);

            // Changing userId to invalid userId
            sut.CurrentUser.Id = 1;
            var okResult = await sut.GetCosts(sut.CurrentUser.Id, propertyID, year) as ObjectResult;

            Assert.Equal(StatusCodes.Status404NotFound, okResult.StatusCode);
        }

        /// <summary>
        /// Get Flat Users unit test
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="propertyID">propertyID</param>
        /// <param name="year">Payroll Year</param>
        /// <returns>ok</returns>
        [Theory]
        [InlineData("2", 39541, 211078)]
        public async Task GetFlatUsers_Should_Return_OK(string username, int propertyID, int year)
        {
            AccountingController sut = new AccountingController(this.accountingClient);

            sut.CurrentUser = await this.GetUser(username);
            var okResult = await sut.GetFlatUsers(sut.CurrentUser.Id, propertyID, year) as ObjectResult;

            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        }

        /// <summary>
        /// Get Flat Users unit test
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="propertyID">propertyID</param>
        /// <param name="year">Payroll Year</param>
        /// <returns>Error</returns>
        [Theory]
        [InlineData("2", 23, 2002)]
        public async Task GetFlatUsers_InvalidUserId_Should_Return_NotFound(string username, int propertyID, int year)
        {
            AccountingController sut = new AccountingController(this.accountingClient);

            sut.CurrentUser = await this.GetUser(username);

            // Changing userId to invalid userId
            sut.CurrentUser.Id = 1;
            var okResult = await sut.GetFlatUsers(sut.CurrentUser.Id, propertyID, year) as ObjectResult;

            Assert.Equal(StatusCodes.Status404NotFound, okResult.StatusCode);
        }

        /// <summary>
        /// Submit unit test
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

        // [InlineData("5451")] //Internal Server Error
        [InlineData("4606")]
        [InlineData("3804")]
        public async Task Submit_Should_Return_OK(string username)
        {
            BlockPeriodRequest blockPeriodRequest = JsonConvert.DeserializeObject<BlockPeriodRequest>(File.ReadAllText($"{this.path}/BlockPeriodRequest.json"));

            AccountingController sut = new AccountingController(this.accountingClient);

            sut.CurrentUser = await this.GetUser(username);
            blockPeriodRequest.UserId = sut.CurrentUser.Id;
            var okResult = await sut.Submit(blockPeriodRequest) as ObjectResult;

            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        }

        /// <summary>
        /// Returns Not Found with invalid UserId
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

        // [InlineData("5451")] //Internal Server Error
        [InlineData("4606")]
        [InlineData("3804")]
        public async Task Submit_Should_Return_Not_Found(string username)
        {
            BlockPeriodRequest blockPeriodRequest = JsonConvert.DeserializeObject<BlockPeriodRequest>(File.ReadAllText($"{this.path}/BlockPeriodRequest.json"));

            AccountingController sut = new AccountingController(this.accountingClient);

            sut.CurrentUser = await this.GetUser(username);
            blockPeriodRequest.UserId = sut.CurrentUser.Id;
            var notFoundResult = await sut.Submit(blockPeriodRequest) as ObjectResult;

            Assert.Equal(StatusCodes.Status404NotFound, notFoundResult.StatusCode);
        }

        /// <summary>
        /// Delete Concept unit test
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="propertyId">propertyId</param>
        /// <param name="conceptId">ConceptIdr</param>
        /// <returns>ok</returns>
        [Theory]
        [InlineData("2", 23, 2020)]
        [InlineData("3168", 23, 2020)]
        public async Task DeleteConcept_Should_Return_OK(string username, int propertyId, int conceptId)
        {
            AccountingController sut = new AccountingController(this.accountingClient);

            sut.CurrentUser = await this.GetUser(username);
            var okResult = await sut.DeleteConcept(sut.CurrentUser.Id, propertyId, conceptId) as ObjectResult;

            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        }

        /// <summary>
        /// Delete Cost unit test
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="propertyId">propertyId</param>
        /// <param name="costId">CostId</param>
        /// <returns>ok</returns>
        [Theory]
        [InlineData("2", 23, 2020)]
        [InlineData("3168", 23, 2020)]
        public async Task DeleteCost_Should_Return_OK(string username, int propertyId, int costId)
        {
            AccountingController sut = new AccountingController(this.accountingClient);

            sut.CurrentUser = await this.GetUser(username);
            var okResult = await sut.DeleteCost(sut.CurrentUser.Id, propertyId, costId) as ObjectResult;

            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        }

        /// <summary>
        /// Save Costs unit test
        /// </summary>
        /// <param name="username">username</param>
        /// <returns>ok</returns>
        [Theory]
        [InlineData("2")]
        [InlineData("3168")]
        public async Task SaveCosts_Should_Return_OK(string username)
        {
            CostData information = JsonConvert.DeserializeObject<CostData>(File.ReadAllText($"{this.path}/SaveCostsRequest.json"));

            AccountingController sut = new AccountingController(this.accountingClient);

            sut.CurrentUser = await this.GetUser(username);
            information.UserId = sut.CurrentUser.Id;
            var okResult = await sut.SaveCosts(information) as ObjectResult;

            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        }

        /// <summary>
        /// Save Flat Users unit test
        /// </summary>
        /// <param name="username">username</param>
        /// <returns>ok</returns>
        [Theory]
        [InlineData("2")]
        [InlineData("3168")]
        public async Task SaveFlatUsers_Should_Return_OK(string username)
        {
            FlatData flatData = JsonConvert.DeserializeObject<FlatData>(File.ReadAllText($"{this.path}/SaveFlatUsersRequest.json"));

            AccountingController sut = new AccountingController(this.accountingClient);

            sut.CurrentUser = await this.GetUser(username);
            flatData.UserId = sut.CurrentUser.Id;
            var okResult = await sut.SaveFlatUsers(flatData) as ObjectResult;

            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        }
    }
}
