using AutoFixture;
using AutoFixture.AutoMoq;
using AutoMapper;
using FluentAssertions;
using Moq;
using StocksApp.BLL.DTOs;
using StocksApp.BLL.Exceptions;
using StocksApp.BLL.Services.Contracts;
using StocksApp.BLL.Services.Implementations;
using StocksApp.DAL.Entities;
using StocksApp.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StocksApp.BLL.Tests.Services.Implementations.StocksServiceTests;

public class CreateSellOrderMethod
{
    private readonly Mock<IStocksRepository> _stocksRepoMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly IStocksService _stocksService;
    private readonly IFixture _fixture;

    public CreateSellOrderMethod()
    {
        _stocksRepoMock = new Mock<IStocksRepository>();
        _mapperMock = new Mock<IMapper>();
        _stocksService = new StocksService(_mapperMock.Object, _stocksRepoMock.Object);
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
    }



    #region CreateSellOrder 

    [Fact]
    public async Task CreateSellOrder_TestNullRequest_ThrowNullArgumentException()
    {
        // Arrange
        SellOrderRequest request = null!;

        // Act
        Func<Task> action = async () => await _stocksService.CreateSellOrderAsync(request);

        // Assert
        await action.Should().ThrowAsync<ArgumentNullException>();
    }

    [Fact]
    public async Task CreateSellOrder_TestQuantity0Request_ThrowCustomValidationException()
    {
        // Arrange
        uint quantity = 0;
        SellOrderRequest request =
            _fixture.Build<SellOrderRequest>().With(x => x.Quantity, quantity).Create();


        // Act
        Func<Task> action = async () => await _stocksService.CreateSellOrderAsync(request);

        // Assert
        var exceptionAssert = await action.Should().ThrowAsync<CustomValidationException>();
        var ex = exceptionAssert.Which;

        ex.Errors.Should().ContainKey(nameof(SellOrderRequest.Quantity));
    }

    [Fact]
    public async Task CreateSellOrder_TestQuantity100001Request_ThrowCustomValidationException()
    {
        // Arrange
        uint quantity = 100001;
        SellOrderRequest request =
            _fixture.Build<SellOrderRequest>().With(x => x.Quantity, quantity).Create();

        // Act
        Func<Task> action = async () => await _stocksService.CreateSellOrderAsync(request);

        // Assert
        var exceptionAssert = await action.Should().ThrowAsync<CustomValidationException>();
        var ex = exceptionAssert.Which;

        ex.Errors.Should().ContainKey(nameof(SellOrderRequest.Quantity));
    }

    [Fact]
    public async Task CreateSellOrder_TestPrice0Request_ThrowCustomValidationException()
    {
        // Arrange
        double price = 0;
        SellOrderRequest request =
            _fixture.Build<SellOrderRequest>().With(x => x.Price, price).Create();

        // Act
        Func<Task> action = async () => await _stocksService.CreateSellOrderAsync(request);

        // Assert
        var exceptionAssert = await action.Should().ThrowAsync<CustomValidationException>();
        var ex = exceptionAssert.Which;

        ex.Errors.Should().ContainKey(nameof(SellOrderRequest.Price));
    }

    [Fact]
    public async Task CreateSellOrder_TestPrice10001Request_ThrowCustomValidationException()
    {
        // Arrange
        double price = 10001;
        SellOrderRequest request =
            _fixture.Build<SellOrderRequest>().With(x => x.Price, price).Create();

        // Act
        Func<Task> action = async () => await _stocksService.CreateSellOrderAsync(request);

        // Assert
        var exceptionAssert = await action.Should().ThrowAsync<CustomValidationException>();
        var ex = exceptionAssert.Which;

        ex.Errors.Should().ContainKey(nameof(SellOrderRequest.Price));
    }

    [Fact]
    public async Task CreateSellOrder_TestStockSymbolNotNullRequest_ThrowCustomValidationException()
    {
        // Arrange
        string? stockSymbol = null;
        SellOrderRequest request =
            _fixture.Build<SellOrderRequest>().With(x => x.StockSymbol, stockSymbol).Create();

        // Act
        Func<Task> action = async () => await _stocksService.CreateSellOrderAsync(request);

        // Assert
        var exceptionAssert = await action.Should().ThrowAsync<CustomValidationException>();
        var ex = exceptionAssert.Which;

        ex.Errors.Should().ContainKey(nameof(SellOrderRequest.StockSymbol));
    }

    [Fact]
    public async Task CreateSellOrder_TestDateAndTimeOfOrderRequest_ThrowCustomValidationException()
    {
        // Arrange
        var date = Convert.ToDateTime("1999-12-31");
        SellOrderRequest request =
            _fixture.Build<SellOrderRequest>().With(x => x.DateAndTimeOfOrder, date).Create();

        // Act
        Func<Task> action = async () => await _stocksService.CreateSellOrderAsync(request);

        // Assert
        var exceptionAssert = await action.Should().ThrowAsync<CustomValidationException>();
        var ex = exceptionAssert.Which;

        ex.Errors.Should().ContainKey(nameof(SellOrderRequest.DateAndTimeOfOrder));
    }

    [Fact]
    public async Task CreateSellOrder_TestValidRequest()
    {
        // Arrange
        var request = _fixture.Create<SellOrderRequest>();


        var orderID = Guid.NewGuid();
        var entity = _fixture.Build<SellOrder>()
            .With(x => x.SellOrderID, orderID)
            .Create();

        var expectedResponse = _fixture.Build<SellOrderResponse>()
            .With(x => x.SellOrderID, orderID)
            .Create();



        _mapperMock.Setup(m => m.Map<SellOrder>(request)).Returns(entity);

        _stocksRepoMock.Setup(r => r.CreateSellOrderAsync(It.IsAny<SellOrder>()))
            .ReturnsAsync(entity);

        _mapperMock.Setup(m => m.Map<SellOrderResponse>(entity))
            .Returns(expectedResponse);

        // Act
        var response = await _stocksService.CreateSellOrderAsync(request);

        // Assert
        response.Should().NotBeNull().And.BeOfType<SellOrderResponse>();
        response.SellOrderID.Should().Be(orderID);

        _stocksRepoMock.Verify(r => r.CreateSellOrderAsync(It.IsAny<SellOrder>()), Times.Once);
    }
    #endregion
}
