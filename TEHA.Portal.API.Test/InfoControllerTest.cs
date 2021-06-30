// <copyright file="InfoControllerTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.API.Test
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using TEHA.Portal.API.Controllers;
    using TEHA.Portal.API.Test.Helper;
    using TEHA.Portal.ProxyAPI.Clients.Info;
    using Xunit;

    /// <summary>
    /// Contains Info unit tests
    /// </summary>
    [Trait("Category", "Info")]
    public class InfoControllerTest : TestBase
    {
        private readonly InfoClient infoClient = new InfoClient();

        /// <summary>
        /// GetContactPersons unit test
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
        public async Task GetContactPersons_Should_Return_OK(string username)
        {
            InfoController sut = new InfoController(this.infoClient)
            {
                CurrentUser = await this.GetUser(username),
            };
            var okResult = await sut.GetContactPersons(sut.CurrentUser.Id) as ObjectResult;
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        }

        /// <summary>
        /// GetContactPersons unit test
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>Not Found</returns>
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
        public async Task GetContactPersons_Should_Return_NotFound(string username)
        {
            InfoController sut = new InfoController(this.infoClient)
            {
                CurrentUser = await this.GetUser(username),
            };
            sut.CurrentUser.Id = 1;
            var okResult = await sut.GetContactPersons(sut.CurrentUser.Id) as ObjectResult;
            Assert.Equal(StatusCodes.Status404NotFound, okResult.StatusCode);
        }

        /// <summary>
        /// GetPayrollYear unit test
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="propertyId">PropertyId</param>
        /// <returns>OK</returns>
        [Theory]
        [InlineData("2", 39541)]
        [InlineData("134", 40877)]
        public async Task GetPayrollYear_Should_Return_OK(string username, int propertyId)
        {
            InfoController sut = new InfoController(this.infoClient)
            {
                CurrentUser = await this.GetUser(username),
            };

            var okResult = await sut.GetPayrollYear(sut.CurrentUser.Id, propertyId) as ObjectResult;
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        }
    }
}
