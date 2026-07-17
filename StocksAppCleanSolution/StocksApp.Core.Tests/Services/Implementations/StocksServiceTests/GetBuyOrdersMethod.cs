using AutoFixture;
using AutoFixture.AutoMoq;
using AutoMapper;
using FluentAssertions;
using Moq;
using StocksApp.Core.DTOs;
using StocksApp.Core.Services.Contracts;
using StocksApp.Core.Services.Implementations;
using StocksApp.Domain.Entites;
using StocksApp.Domain.RepositoryContracts;

namespace StocksApp.Core.Tests.Services.Implementations.StocksServiceTests;

public class GetBuyOrdersMethod
{
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IStocksRepository> _stocksRepoMock;
    private readonly IStocksService _stocksService;
    private readonly IFixture _fixture;

    public GetBuyOrdersMethod()
    {
        _mapperMock = new Mock<IMapper>();
        _stocksRepoMock = new Mock<IStocksRepository>();
        _stocksService = new StocksService(_mapperMock.Object, _stocksRepoMock.Object);
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
    }
    #region GetAllBuyOrders

    [Fact]
    public async Task GetAllBuyOrders_TestEmptyListResult_EmptyResponse()
    {
        // Arrange
        var emptyEntities = new List<BuyOrder>();

        _stocksRepoMock.Setup(repo => repo.GetBuyOrdersAsync())
                       .ReturnsAsync(emptyEntities);
        // Act
        List<BuyOrderResponse> response = await _stocksService.GetBuyOrdersAsync();

        // Assert
        response.Should().NotBeNull().And.BeEmpty();

        _stocksRepoMock.Verify(repo => repo.GetBuyOrdersAsync(), Times.Once);
    }

    [Fact]
    public async Task GetAllBuyOrders_WhenCalled_ReturnsListOfBuyOrderResponses()
    {
        // Arrange
        var entities = _fixture.Build<BuyOrder>().CreateMany(3).ToList();

        var expectedResponses = _fixture.Build<BuyOrderResponse>().CreateMany(3).ToList();


        _mapperMock.Setup(m => m.Map<List<BuyOrderResponse>>(entities)).Returns(expectedResponses);

        _stocksRepoMock.Setup(r => r.GetBuyOrdersAsync()).ReturnsAsync(entities);

        // Act
        List<BuyOrderResponse> buyOrderResponses = await _stocksService.GetBuyOrdersAsync();

        // Assert

        buyOrderResponses.Should().NotBeNullOrEmpty()
            .And.HaveCount(entities.Count)
            .And.BeEquivalentTo(expectedResponses);


        _stocksRepoMock.Verify(r => r.GetBuyOrdersAsync(), Times.Once);
    }
    #endregion
}
