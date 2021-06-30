// <copyright file="OrderControllerTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.API.Test
{
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using TEHA.Portal.API.Controllers;
    using TEHA.Portal.API.Helpers;
    using TEHA.Portal.API.Test.Helper;
    using TEHA.Portal.Data.Models.Common;
    using TEHA.Portal.Data.Models.Contract;
    using TEHA.Portal.Data.Models.Order;
    using TEHA.Portal.ProxyAPI;
    using TEHA.Portal.ProxyAPI.Clients.StockOverview;
    using Xunit;

    /// <summary>
    /// Implements Orders tests.
    /// </summary>
    [Trait("Category", "Order")]
    public class OrderControllerTest : TestBase
    {
        private readonly string path = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName}/Json/Order";
        private readonly string stockOverviewPath = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName}/Json/StockOverview";

        private readonly OrderClient orderClient = new OrderClient();
        private readonly IStockOverviewClient stockOverviewClient = new StockOverviewClient();

        /// <summary>
        /// Get Order unit test
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>ok</returns>
        [Theory]
        [InlineData("2")]
        public async Task GetOrders_Should_Return_OK(string username)
        {
            OrderRequest orderRequest = JsonConvert.DeserializeObject<OrderRequest>(File.ReadAllText($"{this.path}/DefaultOrderRequest.json"));

            OrderController sut = new OrderController(this.orderClient);

            sut.CurrentUser = await this.GetUser(username);
            orderRequest.UserId = sut.CurrentUser.Id;
            var okResult = await sut.Get(orderRequest) as ObjectResult;
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.IsType<OrderResponse>((okResult.Value as Response<OrderResponse>).Data);
        }

        /// <summary>
        /// Get Order unit test
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
        public async Task GetOrders_Should_Return_NotFound(string username)
        {
            OrderRequest orderRequest = JsonConvert.DeserializeObject<OrderRequest>(File.ReadAllText($"{this.path}/DefaultOrderRequest.json"));

            OrderController sut = new OrderController(this.orderClient);

            sut.CurrentUser = await this.GetUser(username);
            orderRequest.UserId = 1; // Invalid userId
            var okResult = await sut.Get(orderRequest) as ObjectResult;

            Assert.Equal(StatusCodes.Status404NotFound, okResult.StatusCode);
        }

        /// <summary>
        /// Get Order unit test
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
        public async Task GetOpenOrdersCount_Should_Return_OK(string username)
        {
            OrderController sut = new OrderController(this.orderClient);

            sut.CurrentUser = await this.GetUser(username);

            var okResult = await sut.GetOpenOrderCount(sut.CurrentUser.Id) as ObjectResult;
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.IsType<List<PropertyInfo>>((okResult.Value as Response<List<PropertyInfo>>).Data);
        }

        /// <summary>
        /// Request Interim Reading unit test
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
        public async Task RequestInterimReading_Should_Return_OK(string username)
        {
            ReadingRequest readingRequest = JsonConvert.DeserializeObject<ReadingRequest>(File.ReadAllText($"{this.path}/DefaultReadingRequest.json"));

            OrderController sut = new OrderController(this.orderClient);

            sut.CurrentUser = await this.GetUser(username);
            readingRequest.UserId = sut.CurrentUser.Id;
            var okResult = await sut.RequestInterimReading(readingRequest) as ObjectResult;
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        }

        /// <summary>
        /// Request Interim Reading unit test
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
        public async Task RequestInterimReading_Should_Return_BadRequest(string username)
        {
            ReadingRequest readingRequest = JsonConvert.DeserializeObject<ReadingRequest>(File.ReadAllText($"{this.path}/DefaultReadingRequest.json"));

            OrderController sut = new OrderController(this.orderClient);

            sut.CurrentUser = await this.GetUser(username);
            readingRequest.UserId = 1; // Invalid userId
            var okResult = await sut.RequestInterimReading(readingRequest) as ObjectResult;
            Assert.Equal(StatusCodes.Status400BadRequest, okResult.StatusCode);
        }

        /// <summary>
        /// Request Offe unit test
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
        public async Task RequestOffer_Should_Return_OK(string username)
        {
            OfferRequest offerRequest = JsonConvert.DeserializeObject<OfferRequest>(File.ReadAllText($"{this.path}/DefaultOfferRequest.json"));

            OrderController sut = new OrderController(this.orderClient);

            sut.CurrentUser = await this.GetUser(username);
            offerRequest.UserId = sut.CurrentUser.Id;
            var okResult = await sut.RequestOffer(offerRequest) as ObjectResult;
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        }

        /// <summary>
        /// Request Offe unit test
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
        public async Task RequestOffer_Should_Return_BadRequest(string username)
        {
            OfferRequest offerRequest = JsonConvert.DeserializeObject<OfferRequest>(File.ReadAllText($"{this.path}/DefaultOfferRequest.json"));

            OrderController sut = new OrderController(this.orderClient);

            sut.CurrentUser = await this.GetUser(username);
            offerRequest.UserId = 1; // Invalid userId
            var okResult = await sut.RequestOffer(offerRequest) as ObjectResult;
            Assert.Equal(StatusCodes.Status404NotFound, okResult.StatusCode);
        }

        /// <summary>
        /// Request Plumbing unit test
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>ok</returns>
        [Theory]
        [InlineData("2")]
        //[InlineData("3168")]
        //[InlineData("2234")]
        //[InlineData("134")]
        //[InlineData("2817")]
        //[InlineData("2270")]
        //[InlineData("2318")]
        //[InlineData("5451")]
        //[InlineData("4606")]
        //[InlineData("3804")]
        public async Task RequestPlumbing_Should_Return_OK(string username)
        {
            PlumbingRequest plumbingRequest = JsonConvert.DeserializeObject<PlumbingRequest>(File.ReadAllText($"{this.path}/DefaultPlumbingRequest.json"));

            OrderController sut = new OrderController(this.orderClient);

            sut.CurrentUser = await this.GetUser(username);
            plumbingRequest.UserId = sut.CurrentUser.Id;
            var okResult = await sut.RequestPlumbing(plumbingRequest) as ObjectResult;
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        }

        /// <summary>
        /// Request Plumbing unit test
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
        public async Task RequestPlumbing_Should_Return_NotFound(string username)
        {
            PlumbingRequest plumbingRequest = JsonConvert.DeserializeObject<PlumbingRequest>(File.ReadAllText($"{this.path}/DefaultPlumbingRequest.json"));

            OrderController sut = new OrderController(this.orderClient);

            sut.CurrentUser = await this.GetUser(username);
            plumbingRequest.UserId = 1; // Invalid userId
            var okResult = await sut.RequestPlumbing(plumbingRequest) as ObjectResult;
            Assert.Equal(StatusCodes.Status404NotFound, okResult.StatusCode);
        }

        /// <summary>
        /// Post Interim Reading unit test
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="propertyId">PropertyId</param>
        /// <param name="flatId">FlatId</param>
        /// <returns>ok</returns>
        [Theory]
        [InlineData("2", 39541, 568748)]
        public async Task PostInterimReading_Should_Return_OK(string username, int propertyId, int flatId)
        {
            InterimReadingSelf interimReadingSelf = JsonConvert.DeserializeObject<InterimReadingSelf>(File.ReadAllText($"{this.path}/DefaultInterimReadingSelf.json"));

            OrderController sut = new OrderController(this.orderClient);

            sut.CurrentUser = await this.GetUser(username);
            interimReadingSelf.UserId = sut.CurrentUser.Id;
            interimReadingSelf.PropertyId = propertyId;
            interimReadingSelf.FlatId = flatId;

            var okResult = await sut.PostInterimReading(interimReadingSelf) as ObjectResult;
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        }

        /// <summary>
        /// Post Interim Reading unit test
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="propertyId">PropertyId</param>
        /// <param name="flatId">FlatId</param>
        /// <returns>Not Found</returns>
        [Theory]
        [InlineData("2", 39541, 568748)]
        public async Task PostInterimReading_Should_Return_NotFound(string username, int propertyId, int flatId)
        {
            InterimReadingSelf interimReadingSelf = JsonConvert.DeserializeObject<InterimReadingSelf>(File.ReadAllText($"{this.path}/DefaultInterimReadingSelf.json"));

            OrderController sut = new OrderController(this.orderClient);

            sut.CurrentUser = await this.GetUser(username);
            interimReadingSelf.UserId = 1; // Invalid userId
            interimReadingSelf.PropertyId = propertyId;
            interimReadingSelf.FlatId = flatId;

            var okResult = await sut.PostInterimReading(interimReadingSelf) as ObjectResult;
            Assert.Equal(StatusCodes.Status404NotFound, okResult.StatusCode);
        }

        /// <summary>
        /// Request Reading unit test
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
        public async Task RequestReading_Should_Return_OK(string username)
        {
            ReadingRequest readingRequest = JsonConvert.DeserializeObject<ReadingRequest>(File.ReadAllText($"{this.path}/DefaultReadingRequest.json"));

            OrderController sut = new OrderController(this.orderClient);

            sut.CurrentUser = await this.GetUser(username);
            readingRequest.UserId = sut.CurrentUser.Id;
            var okResult = await sut.RequestReading(readingRequest) as ObjectResult;
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        }

        /// <summary>
        /// Request Reading unit test
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
        public async Task RequestReading_Should_Return_BadRequest(string username)
        {
            ReadingRequest readingRequest = JsonConvert.DeserializeObject<ReadingRequest>(File.ReadAllText($"{this.path}/DefaultReadingRequest.json"));

            OrderController sut = new OrderController(this.orderClient);

            sut.CurrentUser = await this.GetUser(username);
            readingRequest.UserId = 1; // Invalid userId
            var okResult = await sut.RequestReading(readingRequest) as ObjectResult;
            Assert.Equal(StatusCodes.Status400BadRequest, okResult.StatusCode);
        }

        /// <summary>
        /// Request Drinking Water Sampling unit test
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="propertyId">PropertyId</param>
        /// <returns>ok</returns>
        [Theory]
        [InlineData("2", 39541)]
        [InlineData("134", 40877)]
        public async Task RequestDrinkingWaterSampling_Should_Return_OK(string username, int propertyId)
        {
            WaterSamplingRequest waterSamplingRequest = JsonConvert.DeserializeObject<WaterSamplingRequest>(File.ReadAllText($"{this.path}/DefaultWaterSamplingRequest.json"));

            OrderController sut = new OrderController(this.orderClient);

            sut.CurrentUser = await this.GetUser(username);
            waterSamplingRequest.UserId = sut.CurrentUser.Id;
            waterSamplingRequest.PropertyId = propertyId;
            var okResult = await sut.RequestDrinkingWaterSampling(waterSamplingRequest) as ObjectResult;
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        }

        /// <summary>
        /// Request Drinking Water Sampling unit test
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="propertyId">PropertyId</param>
        /// <returns>Not Found</returns>
        [Theory]
        [InlineData("2", 39541)]
        [InlineData("134", 40877)]
        public async Task RequestDrinkingWaterSampling_Should_Return_NotFound(string username, int propertyId)
        {
            WaterSamplingRequest waterSamplingRequest = JsonConvert.DeserializeObject<WaterSamplingRequest>(File.ReadAllText($"{this.path}/DefaultWaterSamplingRequest.json"));

            OrderController sut = new OrderController(this.orderClient);

            sut.CurrentUser = await this.GetUser(username);
            waterSamplingRequest.UserId = 1; // Invalid userId
            waterSamplingRequest.PropertyId = propertyId;
            var okResult = await sut.RequestDrinkingWaterSampling(waterSamplingRequest) as ObjectResult;
            Assert.Equal(StatusCodes.Status404NotFound, okResult.StatusCode);
        }

        /// <summary>
        /// Request Energy Performance Certificate unit test
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
        public async Task RequestEnergyPerformanceCertificate_Should_Return_OK(string username)
        {
            PerformanceCertificate performanceCertificate = JsonConvert.DeserializeObject<PerformanceCertificate>(File.ReadAllText($"{this.path}/DefaultPerformanceCertificate.json"));

            OrderController sut = new OrderController(this.orderClient);

            StockOverviewController stockOverviewController = new StockOverviewController(this.stockOverviewClient);

            PropertyRequest propertyRequest = JsonConvert.DeserializeObject<PropertyRequest>(File.ReadAllText($"{this.stockOverviewPath}/DefaultPropertyRequest.json"));

            sut.CurrentUser = await this.GetUser(username);
            stockOverviewController.CurrentUser = sut.CurrentUser;

            performanceCertificate.UserId = sut.CurrentUser.Id;

            propertyRequest.UserId = sut.CurrentUser.Id;
            propertyRequest.IncludeChildren = false;
            propertyRequest.PageSize = 1000;
            var propertyResult = await stockOverviewController.GetProperties(propertyRequest) as ObjectResult;

            var properties = (propertyResult.Value as Response<PropertyResult>).Data.Items;

            foreach (var property in properties)
            {
                performanceCertificate.PropertyId = property.Id;
                var okResult = await sut.RequestEnergyPerformanceCertificate(performanceCertificate) as ObjectResult;
                Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            }
        }

        /// <summary>
        /// Request Energy Performance Certificate unit test
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="propertyId">PropertyId</param>
        /// <returns>ok</returns>
        [Theory]
        [InlineData("2", 39541)]
        [InlineData("134", 40877)]
        public async Task RequestEnergyPerformanceCertificate_Should_Return_NotFound(string username, int propertyId)
        {
            PerformanceCertificate performanceCertificate = JsonConvert.DeserializeObject<PerformanceCertificate>(File.ReadAllText($"{this.path}/DefaultPerformanceCertificate.json"));

            OrderController sut = new OrderController(this.orderClient);

            sut.CurrentUser = await this.GetUser(username);
            performanceCertificate.UserId = 1; // Invalid userId
            performanceCertificate.PropertyId = propertyId;
            var okResult = await sut.RequestEnergyPerformanceCertificate(performanceCertificate) as ObjectResult;
            Assert.Equal(StatusCodes.Status404NotFound, okResult.StatusCode);
        }

        /// <summary>
        /// Request Smoke Detector Test unit test
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
        public async Task RequestSmokeDetectorTest_Should_Return_OK(string username)
        {
            SmokeDetectorRequest smokeDetectorRequest = JsonConvert.DeserializeObject<SmokeDetectorRequest>(File.ReadAllText($"{this.path}/DefaultSmokeDetectorRequest.json"));

            OrderController sut = new OrderController(this.orderClient);

            sut.CurrentUser = await this.GetUser(username);
            smokeDetectorRequest.UserId = sut.CurrentUser.Id;
            var okResult = await sut.RequestSmokeDetectorTest(smokeDetectorRequest) as ObjectResult;
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        }

        /// <summary>
        /// Request Smoke Detector Test unit test
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
        public async Task RequestSmokeDetectorTest_Should_Return_BadRequest(string username)
        {
            SmokeDetectorRequest smokeDetectorRequest = JsonConvert.DeserializeObject<SmokeDetectorRequest>(File.ReadAllText($"{this.path}/DefaultSmokeDetectorRequest.json"));

            OrderController sut = new OrderController(this.orderClient);

            sut.CurrentUser = await this.GetUser(username);
            smokeDetectorRequest.UserId = 1; // Invalid userId
            var okResult = await sut.RequestSmokeDetectorTest(smokeDetectorRequest) as ObjectResult;
            Assert.Equal(StatusCodes.Status400BadRequest, okResult.StatusCode);
        }

        /// <summary>
        /// Cancel order unit test
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
        public async Task Cancel_Should_Return_OK(string username)
        {
            OrderController sut = new OrderController(this.orderClient);
            sut.CurrentUser = await this.GetUser(username);
            int orderId = 568;
            var okResult = await sut.Cancel(sut.CurrentUser.Id, orderId) as ObjectResult;
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        }

        /// <summary>
        /// Cancel order unit test
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
        public async Task Cancel_Should_Return_BadRequest(string username)
        {
            OrderController sut = new OrderController(this.orderClient);
            sut.CurrentUser = await this.GetUser(username);
            int orderId = 99;
            sut.CurrentUser.Id = 1; // Invalid userId
            var okResult = await sut.Cancel(sut.CurrentUser.Id, orderId) as ObjectResult;
            Assert.Equal(StatusCodes.Status400BadRequest, okResult.StatusCode);
        }
    }
}
