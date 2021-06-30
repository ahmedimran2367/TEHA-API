// <copyright file="StockOverviewControllerTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.API.Test.StockOverview
{
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
    using TEHA.Portal.Data.Models.StockOverview;
    using TEHA.Portal.ProxyAPI.Clients.StockOverview;
    using Xunit;

    /// <summary>
    /// Contains stock overview test cases.
    /// </summary>
    [Trait("Category", "StockOverview")]
    public class StockOverviewControllerTest : TestBase
    {
        private readonly string path = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName}/Json/StockOverview";

        private readonly StockOverviewClient stockOverviewClient = new StockOverviewClient();

        /// <summary>
        /// Get summary unit test
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
        public async Task GetSummary_Should_Return_OK(string username)
        {
            StockOverviewController sut = new StockOverviewController(this.stockOverviewClient);

            sut.CurrentUser = await this.GetUser(username);
            var okResult = await sut.GetSummary(sut.CurrentUser.Id) as ObjectResult;

            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.IsType<Summary>((okResult.Value as Response<Summary>).Data);
        }

        /// <summary>
        /// Get summary unit test
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>ok</returns>
        [Theory]
        [InlineData("2")]
        public async Task GetSummary_InvalidUserId_Should_Return_NotFound(string username)
        {
            StockOverviewController sut = new StockOverviewController(this.stockOverviewClient);

            sut.CurrentUser = await this.GetUser(username);

            // Changing userId to invalid userId
            sut.CurrentUser.Id = 1;
            var okResult = await sut.GetSummary(sut.CurrentUser.Id) as ObjectResult;

            Assert.Equal(StatusCodes.Status404NotFound, okResult.StatusCode);
        }

        /// <summary>
        /// Get properties unit test
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
        public async Task GetProperties_Should_Return_OK(string username)
        {
            PropertyRequest propertyRequest = JsonConvert.DeserializeObject<PropertyRequest>(File.ReadAllText($"{this.path}/DefaultPropertyRequest.json"));

            StockOverviewController sut = new StockOverviewController(this.stockOverviewClient);

            sut.CurrentUser = await this.GetUser(username);
            propertyRequest.UserId = sut.CurrentUser.Id;
            var okResult = await sut.GetProperties(propertyRequest) as ObjectResult;

            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.IsType<PropertyResult>((okResult.Value as Response<PropertyResult>).Data);
            (okResult.Value as Response<PropertyResult>).Data.Items.Count.Should().BeGreaterThan(0);
            Assert.True((okResult.Value as Response<PropertyResult>).Data.Items.All(p => p.Flats.Any(f => f.Meters.Count > 0)));
        }

        /// <summary>
        /// Get properties unit test for child true
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

        // [InlineData("3804")] //Meter count is 0
        public async Task GetProperties_Should_Return_FlatsAndMeters_When_ChildInd_Is_True(string username)
        {
            PropertyRequest propertyRequest = JsonConvert.DeserializeObject<PropertyRequest>(File.ReadAllText($"{this.path}/DefaultPropertyRequest.json"));

            StockOverviewController sut = new StockOverviewController(this.stockOverviewClient);

            sut.CurrentUser = await this.GetUser(username);
            propertyRequest.UserId = sut.CurrentUser.Id;
            propertyRequest.IncludeChildren = true;
            var okResult = await sut.GetProperties(propertyRequest) as ObjectResult;

            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);

            (okResult.Value as Response<PropertyResult>).Data.Items.FirstOrDefault().Flats.Any(f => f.Meters.Count > 0).Should().BeTrue();
        }

        /// <summary>
        /// Get properties unit test for child false
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
        public async Task GetProperties_Should_Not_Return_FlatsAndMeters_When_ChildInd_Is_False(string username)
        {
            PropertyRequest propertyRequest = JsonConvert.DeserializeObject<PropertyRequest>(File.ReadAllText($"{this.path}/DefaultPropertyRequest.json"));

            StockOverviewController sut = new StockOverviewController(this.stockOverviewClient);

            sut.CurrentUser = await this.GetUser(username);
            propertyRequest.UserId = sut.CurrentUser.Id;
            propertyRequest.IncludeChildren = false;
            var okResult = await sut.GetProperties(propertyRequest) as ObjectResult;

            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);

            (okResult.Value as Response<PropertyResult>).Data.Items.All(p => p.Flats == null).Should().BeTrue();
        }

        /// <summary>
        /// Returns Not Found with invalid UserId
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>ok</returns>
        [Theory]
        [InlineData("2")]
        public async Task GetProperties_InvalidUserId_Should_Return_NotFound(string username)
        {
            PropertyRequest invalidPropertyRequest = JsonConvert.DeserializeObject<PropertyRequest>(File.ReadAllText($"{this.path}/DefaultPropertyRequest.json"));

            StockOverviewController sut = new StockOverviewController(this.stockOverviewClient);

            sut.CurrentUser = await this.GetUser(username);

            // Changing userId to invalid userId
            sut.CurrentUser.Id = 1;
            invalidPropertyRequest.UserId = sut.CurrentUser.Id;
            var okResult = await sut.GetProperties(invalidPropertyRequest) as ObjectResult;

            Assert.Equal(StatusCodes.Status404NotFound, okResult.StatusCode);
        }

        /// <summary>
        /// Get properties unit test
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
        public async Task GetFlats_Should_Return_OK(string username)
        {
            FlatRequest flatRequest = JsonConvert.DeserializeObject<FlatRequest>(File.ReadAllText($"{this.path}/DefaultFlatRequest.json"));

            PropertyRequest propertyRequest = JsonConvert.DeserializeObject<PropertyRequest>(File.ReadAllText($"{this.path}/DefaultPropertyRequest.json"));

            StockOverviewController sut = new StockOverviewController(this.stockOverviewClient);

            sut.CurrentUser = await this.GetUser(username);
            propertyRequest.UserId = sut.CurrentUser.Id;

            var properties = await sut.GetProperties(propertyRequest) as ObjectResult;

            flatRequest.UserId = sut.CurrentUser.Id;
            flatRequest.PropertyIds.AddRange((properties.Value as Response<PropertyResult>).Data.Items.Select(i => i.Id));
            var okResult = await sut.GetFlats(flatRequest) as ObjectResult;

            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.IsType<FlatResult>((okResult.Value as Response<FlatResult>).Data);
            (okResult.Value as Response<FlatResult>).Data.Items.Count.Should().BeGreaterThan(0);
        }

        /// <summary>
        /// Get properties unit test
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
        public async Task GetFlats_Should_Include_Children_When_ChildInd_isTrue(string username)
        {
            FlatRequest flatRequest = JsonConvert.DeserializeObject<FlatRequest>(File.ReadAllText($"{this.path}/DefaultFlatRequest.json"));

            PropertyRequest propertyRequest = JsonConvert.DeserializeObject<PropertyRequest>(File.ReadAllText($"{this.path}/DefaultPropertyRequest.json"));

            StockOverviewController sut = new StockOverviewController(this.stockOverviewClient);

            sut.CurrentUser = await this.GetUser(username);
            propertyRequest.UserId = sut.CurrentUser.Id;

            var properties = await sut.GetProperties(propertyRequest) as ObjectResult;

            flatRequest.UserId = sut.CurrentUser.Id;
            flatRequest.IncludeChildren = true;
            flatRequest.PropertyIds.AddRange((properties.Value as Response<PropertyResult>).Data.Items.Select(i => i.Id));
            var okResult = await sut.GetFlats(flatRequest) as ObjectResult;

            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            (okResult.Value as Response<FlatResult>).Data.Items.Any(f => f.Meters.Count > 0).Should().BeTrue();
        }

        /// <summary>
        /// Get properties unit test
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
        public async Task GetFlats_Should_Not_Include_Children_When_ChildInd_is_False(string username)
        {
            FlatRequest flatRequest = JsonConvert.DeserializeObject<FlatRequest>(File.ReadAllText($"{this.path}/DefaultFlatRequest.json"));

            PropertyRequest propertyRequest = JsonConvert.DeserializeObject<PropertyRequest>(File.ReadAllText($"{this.path}/DefaultPropertyRequest.json"));

            StockOverviewController sut = new StockOverviewController(this.stockOverviewClient);

            sut.CurrentUser = await this.GetUser(username);
            propertyRequest.UserId = sut.CurrentUser.Id;

            var properties = await sut.GetProperties(propertyRequest) as ObjectResult;

            flatRequest.UserId = sut.CurrentUser.Id;
            flatRequest.IncludeChildren = false;
            flatRequest.PropertyIds.AddRange((properties.Value as Response<PropertyResult>).Data.Items.Select(i => i.Id));
            var okResult = await sut.GetFlats(flatRequest) as ObjectResult;

            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            (okResult.Value as Response<FlatResult>).Data.Items.All(f => f.Meters == null).Should().BeTrue();
        }

        /// <summary>
        /// Get properties unit test
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>ok</returns>
        [Theory]
        [InlineData("2")]
        public async Task GetOpenLetter_Should_Return_OK(string username)
        {
            PropertyRequest propertyRequest = JsonConvert.DeserializeObject<PropertyRequest>(File.ReadAllText($"{this.path}/DefaultPropertyRequest.json"));

            StockOverviewController sut = new StockOverviewController(this.stockOverviewClient);
            sut.CurrentUser = await this.GetUser(username);

            int userId = sut.CurrentUser.Id;
            propertyRequest.UserId = userId;
            var properties = await sut.GetProperties(propertyRequest) as ObjectResult;

            var okResult = await sut.GetOpenLetter(userId, (properties.Value as Response<PropertyResult>).Data.Items.First(p => p.OpenLetterInd).Id, null) as ObjectResult;
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.IsType<byte[]>((okResult.Value as Response<byte[]>).Data);
        }

        /// <summary>
        /// Get OpenLetter unit test
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>ok</returns>
        [Theory]
        [InlineData("2")]
        public async Task GetOpenLetter_InvalidUserId_Should_Return_NotFound(string username)
        {
            PropertyRequest propertyRequest = JsonConvert.DeserializeObject<PropertyRequest>(File.ReadAllText($"{this.path}/DefaultPropertyRequest.json"));

            StockOverviewController sut = new StockOverviewController(this.stockOverviewClient);

            sut.CurrentUser = await this.GetUser(username);

            propertyRequest.UserId = sut.CurrentUser.Id;
            var properties = await sut.GetProperties(propertyRequest) as ObjectResult;

            // Changing userId to invalid userId
            sut.CurrentUser.Id = 1;

            var notFoundResult = await sut.GetOpenLetter(sut.CurrentUser.Id, (properties.Value as Response<PropertyResult>).Data.Items.First(p => p.OpenLetterInd).Id, null) as ObjectResult;
            Assert.Equal(StatusCodes.Status404NotFound, notFoundResult.StatusCode);
        }
    }
}
