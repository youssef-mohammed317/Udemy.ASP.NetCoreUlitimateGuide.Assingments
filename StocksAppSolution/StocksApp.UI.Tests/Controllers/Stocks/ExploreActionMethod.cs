using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Moq;
using StocksApp.BLL.Services.Contracts;
using StocksApp.UI.Controllers;
using StocksApp.UI.CustomOptions;
using StocksApp.UI.ViewModels;
namespace StocksApp.UI.Tests.Controllers.Stocks;

public class ExploreActionMethod
{
    private readonly Mock<IFinnhubService> _finnhubServiceMock;
    private readonly Mock<IStocksService> _stocksServiceMock;
    private readonly StocksController _controller;
    public ExploreActionMethod()
    {
        _finnhubServiceMock = new Mock<IFinnhubService>();
        _stocksServiceMock = new Mock<IStocksService>();
        var myOptions = new TradingOptions
        {
            DefaultOrderQuantity = 100,
            DefaultStockSymbol = "MSFT",
            Top25PopularStocks = "AAPL,MSFT,GOOGL",
            SecretToken = "Secret"
        };
        _controller = new StocksController(_finnhubServiceMock.Object,
            _stocksServiceMock.Object, Options.Create(myOptions));
    }

    [Fact]
    public async Task Explore_StockParamAsNull_ReturnsViewAlongWithListOfStockModel()
    {
        // Arrange
        string? stockParam = null;

        var stocksFromService = new List<Dictionary<string, string>>
        {
            new Dictionary<string, string> { { "symbol", "MSFT" }, { "displaySymbol", "Microsoft Corp" } },
            new Dictionary<string, string> { { "symbol", "AAPL" }, { "displaySymbol", "Apple Inc" } },
            new Dictionary<string, string> { { "symbol", "TSLA" }, { "displaySymbol", "Tesla Inc" } }
        };

        _finnhubServiceMock.Setup(s => s.GetStocks())
            .ReturnsAsync(stocksFromService);

        // Act
        var response = await _controller.Explore(stockParam);

        // Assert
        var viewResult = response.Should().BeOfType<ViewResult>().Subject;
        var model = viewResult.Model.Should().BeAssignableTo<List<StockViewModel>>().Subject;

        model.Should().NotBeNull().And.HaveCount(2);
        model.Should().Contain(m => m.StockSymbol == "MSFT");
        model.Should().Contain(m => m.StockSymbol == "AAPL");

        var viewBagStockSymbol = _controller.ViewBag.StockSymbol as string;

        viewBagStockSymbol.Should().BeNull();

        _finnhubServiceMock.Verify(s => s.GetStocks(), Times.Once);
    }
}
