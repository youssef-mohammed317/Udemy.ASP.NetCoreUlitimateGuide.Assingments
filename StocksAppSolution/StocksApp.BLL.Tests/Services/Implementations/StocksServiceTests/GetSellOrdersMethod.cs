using AutoFixture;
using AutoFixture.AutoMoq;
using AutoMapper;
using FluentAssertions;
using Moq;
using StocksApp.BLL.DTOs;
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

public class GetSellOrdersMethod
{
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IStocksRepository> _stocksRepoMock;
    private readonly IStocksService _stocksService;
    private readonly IFixture _fixture;

    public GetSellOrdersMethod()
    {
        _mapperMock = new Mock<IMapper>();
        _stocksRepoMock = new Mock<IStocksRepository>();
        _stocksService = new StocksService(_mapperMock.Object, _stocksRepoMock.Object);
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
    }
    #region GetAllSellOrders

    [Fact]
    public async Task GetAllSellOrders_TestEmptyListResult_EmptyResponse()
    {
        // Arrange
        var emptyEntities = new List<SellOrder>();

        _stocksRepoMock.Setup(repo => repo.GetSellOrdersAsync())
                       .ReturnsAsync(emptyEntities);

        // Act
        List<SellOrderResponse> response = await _stocksService.GetSellOrdersAsync();

        // Assert
        response.Should().NotBeNull().And.BeEmpty();

        _stocksRepoMock.Verify(repo => repo.GetSellOrdersAsync(), Times.Once);
    }

    [Fact]
    public async Task GetAllSellOrders_WhenCalled_ReturnsListOfSellOrderResponses()
    {
        // Arrange
        var entities = _fixture.Build<SellOrder>().CreateMany(3).ToList();
        var expectedResponses = _fixture.Build<SellOrderResponse>().CreateMany(3).ToList();

        _mapperMock.Setup(m => m.Map<List<SellOrderResponse>>(entities)).Returns(expectedResponses);

        _stocksRepoMock.Setup(r => r.GetSellOrdersAsync()).ReturnsAsync(entities);

        // Act
        List<SellOrderResponse> SellOrderResponses = await _stocksService.GetSellOrdersAsync();

        // Assert

        SellOrderResponses.Should().NotBeNullOrEmpty()
            .And.HaveCount(entities.Count)
            .And.BeEquivalentTo(expectedResponses);


        _stocksRepoMock.Verify(r => r.GetSellOrdersAsync(), Times.Once);
    }
    #endregion
}
