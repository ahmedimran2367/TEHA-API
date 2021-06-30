// <copyright file="DashboardControllerTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.API.Test
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using TEHA.Portal.API.Controllers;
    using TEHA.Portal.API.Helpers;
    using TEHA.Portal.API.Test.Helper;
    using TEHA.Portal.ProxyAPI.Clients.Dashboard;
    using Xunit;

    /// <summary>
    /// Contains Dashboard test cases.
    /// </summary>
    [Trait("Category", "Dashboard")]
    public class DashboardControllerTest : TestBase
    {
        private readonly IDashboardClient dashboardClient = new DashboardClient();

        /// <summary>
        /// Get dashboard data unit test
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
        public async Task GetDashboard_Should_Return_OK(string username)
        {
            DashboardController sut = new DashboardController(this.dashboardClient);

            sut.CurrentUser = await this.GetUser(username);
            var okResult = await sut.Get(sut.CurrentUser.Id) as ObjectResult;

            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.IsType<Data.Models.Dashboard.Info>((okResult.Value as Response<Data.Models.Dashboard.Info>).Data);
        }
    }
}
