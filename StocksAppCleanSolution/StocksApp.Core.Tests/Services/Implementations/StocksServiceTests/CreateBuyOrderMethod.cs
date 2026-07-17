using AutoFixture;
using AutoFixture.AutoMoq;
using AutoMapper;
using FluentAssertions;
using Moq;
using StocksApp.Core.DTOs;
using StocksApp.Core.Exceptions;
using StocksApp.Core.Services.Contracts;
using StocksApp.Core.Services.Implementations;
using StocksApp.Domain.Entites;
using StocksApp.Domain.RepositoryContracts;

namespace StocksApp.Core.Tests.Services.Implementations.StocksServiceTests;

public class CreateBuyOrderMethod
{
    private readonly IStocksService _stocksService;
    private readonly IFixture _fixture;
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IStocksRepository> _stocksRepoMock;

    public CreateBuyOrderMethod()
    {
        _mapperMock = new Mock<IMapper>();
        _stocksRepoMock = new Mock<IStocksRepository>();

        _stocksService = new StocksService(_mapperMock.Object, _stocksRepoMock.Object);
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
    }

    #region CreateBuyOrder
    [Fact]
    public async Task CreateBuyOrder_TestNullRequest_ThrowArgumentNullException()
    {
        // Arrange
        BuyOrderRequest request = null!;

        // Act
        Func<Task> action = async () => await _stocksService.CreateBuyOrderAsync(request);

        // Assert
        await action.Should().ThrowAsync<ArgumentNullException>();
    }

    [Fact]
    public async Task CreateBuyOrder_TestQuantity0Request_ThrowCustomValidationException()
    {
        // Arrange
        uint quantity = 0;
        var request = _fixture.Build<BuyOrderRequest>().With(x => x.Quantity, quantity).Create();

        // Act
        Func<Task> action = async () => await _stocksService.CreateBuyOrderAsync(request);

        // Assert
        var exceptionAssertion = await action.Should().ThrowAsync<CustomValidationException>();

        var exception = exceptionAssertion.Which;

        exception.Errors.Should().ContainKey(nameof(BuyOrderRequest.Quantity));
    }

    [Fact]
    public async Task CreateBuyOrder_TestQuantity100001Request_ThrowCustomValidationException()
    {
        // Arrange
        uint quantity = 100001;
        var request = _fixture.Build<BuyOrderRequest>().With(x => x.Quantity, quantity).Create();

        // Act
        Func<Task> action = async () => await _stocksService.CreateBuyOrderAsync(request);

        // Assert

        var exceptionAssert = await action.Should().ThrowAsync<CustomValidationException>();
        var exception = exceptionAssert.Which;

        exception.Errors.Should().ContainKey(nameof(BuyOrderRequest.Quantity));
    }

    [Fact]
    public async Task CreateBuyOrder_TestPrice0Request_ThrowCustomValidationException()
    {
        // Arrange
        double price = 0;
        var request = _fixture.Build<BuyOrderRequest>().With(x => x.Price, price).Create();

        // Act
        Func<Task> action = async () => await _stocksService.CreateBuyOrderAsync(request);

        // Assert
        var exceptionAssert = await action.Should().ThrowAsync<CustomValidationException>();

        var ex = exceptionAssert.Which;
        ex.Errors.Should().ContainKey(nameof(BuyOrderRequest.Price));
    }

    [Fact]
    public async Task CreateBuyOrder_TestPrice10001Request_ThrowCustomValidationException()
    {
        // Arrange
        double price = 10001;
        var request = _fixture.Build<BuyOrderRequest>().With(x => x.Price, price).Create();
        // Act
        Func<Task> action = async () => await _stocksService.CreateBuyOrderAsync(request);

        // Assert

        var exceptionAssert = await action.Should().ThrowAsync<CustomValidationException>();
        var ex = exceptionAssert.Which;
        ex.Errors.Should().ContainKey(nameof(BuyOrderRequest.Price));
    }

    [Fact]
    public async Task CreateBuyOrder_TestStockSymbolNotNullRequest_ThrowCustomValidationException()
    {
        // Arrange
        string? stockSymbol = null;
        var request = _fixture.Build<BuyOrderRequest>().With(x => x.StockSymbol, stockSymbol).Create();

        // Act
        Func<Task> action = async () => await _stocksService.CreateBuyOrderAsync(request);

        // Assert
        var exceptionAssert = await action.Should().ThrowAsync<CustomValidationException>();
        var ex = exceptionAssert.Which;
        ex.Errors.Should().ContainKey(nameof(BuyOrderRequest.StockSymbol));
    }

    [Fact]
    public async Task CreateBuyOrder_TestDateAndTimeOfOrderRequest_ThrowCustomValidationException()
    {
        // Arrange
        var date = Convert.ToDateTime("1999-12-31");
        var request = _fixture.Build<BuyOrderRequest>().With(x => x.DateAndTimeOfOrder, date).Create();

        // Act
        Func<Task> action = async () => await _stocksService.CreateBuyOrderAsync(request);

        // Assert
        var exceptionAssert = await action.Should().ThrowAsync<CustomValidationException>();
        var ex = exceptionAssert.Which;
        ex.Errors.Should().ContainKey(nameof(BuyOrderRequest.DateAndTimeOfOrder));
    }

    [Fact]
    public async Task CreateBuyOrder_TestValidRequest_ReturnsBuyOrderResponse()
    {
        // Arrange
        var stockSymbol = "ABCD";

        BuyOrderRequest request = _fixture.Build<BuyOrderRequest>()
            .With(x => x.StockSymbol, stockSymbol)
            .Create();

        var orderId = Guid.NewGuid();

        var buyOrderEntity = _fixture.Build<BuyOrder>()
            .With(x => x.BuyOrderID, orderId)
            .With(x => x.StockSymbol, stockSymbol)
            .Create();

        var expectedResponse = _fixture.Build<BuyOrderResponse>()
            .With(x => x.BuyOrderID, orderId)
            .With(x => x.StockSymbol, stockSymbol)
            .Create();

        _mapperMock.Setup(m => m.Map<BuyOrder>(request)).Returns(buyOrderEntity);

        _stocksRepoMock.Setup(repo => repo.CreateBuyOrderAsync(It.IsAny<BuyOrder>()))
            .ReturnsAsync(buyOrderEntity);

        _mapperMock.Setup(m => m.Map<BuyOrderResponse>(buyOrderEntity)).Returns(expectedResponse);


        // Act
        var response = await _stocksService.CreateBuyOrderAsync(request);

        // Assert
        response.Should().NotBeNull().And.BeOfType<BuyOrderResponse>();
        response.BuyOrderID.Should().Be(orderId);
        response.StockSymbol.Should().Be(request.StockSymbol);

        _stocksRepoMock.Verify(repo => repo.CreateBuyOrderAsync(It.IsAny<BuyOrder>()), Times.Once);
    }
    #endregion
}



