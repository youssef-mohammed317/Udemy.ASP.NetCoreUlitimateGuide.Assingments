using StocksApp.BLL.DTOs;
using StocksApp.BLL.Services.Implementations;
using System;
using System.Collections.Generic;
using System.IO.Pipelines;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StocksApp.BLL.Tests.Services.Implementations;

public class StocksServiceTests
{
    private StocksService _stockService;

    public StocksServiceTests()
    {
        _stockService = new StocksService();
    }

    #region CreateBuyOrder
    [Fact]
    public async Task CreateBuyOrder_TestNullRequest()
    {
        // Arrange
        BuyOrderRequest request = null!;

        // Act
        Func<Task> action = async () => await _stockService.CreateBuyOrderAsync(request);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(action);
    }

    [Fact]
    public async Task CreateBuyOrder_TestQuantity0Request()
    {
        // Arrange
        BuyOrderRequest request = new BuyOrderRequest
        {
            Quantity = 0
        };

        // Act
        Func<Task> action = async () => await _stockService.CreateBuyOrderAsync(request);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(action);
    }

    [Fact]
    public async Task CreateBuyOrder_TestQuantity100001Request()
    {
        // Arrange
        BuyOrderRequest request = new BuyOrderRequest
        {
            Quantity = 100001
        };

        // Act
        Func<Task> action = async () => await _stockService.CreateBuyOrderAsync(request);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(action);
    }

    [Fact]
    public async Task CreateBuyOrder_TestPrice0Request()
    {
        // Arrange
        BuyOrderRequest request = new BuyOrderRequest
        {
            Price = 0
        };

        // Act
        Func<Task> action = async () => await _stockService.CreateBuyOrderAsync(request);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(action);
    }

    [Fact]
    public async Task CreateBuyOrder_TestPrice10001Request()
    {
        // Arrange
        BuyOrderRequest request = new BuyOrderRequest
        {
            Price = 10001
        };

        // Act
        Func<Task> action = async () => await _stockService.CreateBuyOrderAsync(request);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(action);
    }

    [Fact]
    public async Task CreateBuyOrder_TestStockSymbolNotNullRequest()
    {
        // Arrange
        BuyOrderRequest request = new BuyOrderRequest
        {
            StockSymbol = null
        };

        // Act
        Func<Task> action = async () => await _stockService.CreateBuyOrderAsync(request);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(action);
    }

    [Fact]
    public async Task CreateBuyOrder_TestDateAndTimeOfOrderRequest()
    {
        // Arrange
        BuyOrderRequest request = new BuyOrderRequest
        {
            DateAndTimeOfOrder = Convert.ToDateTime("1999-12-31")
        };

        // Act
        Func<Task> action = async () => await _stockService.CreateBuyOrderAsync(request);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(action);
    }

    [Fact]
    public async Task CreateBuyOrder_TestValidRequest()
    {
        // Arrange
        BuyOrderRequest request = new BuyOrderRequest
        {
            StockSymbol = "MSFT",
            Price = 10,
            StockName = "Test name",
            Quantity = 100,
            DateAndTimeOfOrder = Convert.ToDateTime("2004-12-28")
        };

        // Act
        var response = await _stockService.CreateBuyOrderAsync(request);

        // Assert
        Assert.NotNull(response);
        Assert.IsType<BuyOrderResponse>(response);
        Assert.NotNull(response.BuyOrderID.ToString());
    }
    #endregion


    #region CreateSellOrder 

    [Fact]
    public async Task CreateSellOrder_TestNullRequest()
    {
        // Arrange
        SellOrderRequest request = null!;

        // Act
        Func<Task> action = async () => await _stockService.CreateSellOrderAsync(request);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(action);
    }

    [Fact]
    public async Task CreateSellOrder_TestQuantity0Request()
    {
        // Arrange
        SellOrderRequest request = new SellOrderRequest
        {
            Quantity = 0
        };

        // Act
        Func<Task> action = async () => await _stockService.CreateSellOrderAsync(request);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(action);
    }

    [Fact]
    public async Task CreateSellOrder_TestQuantity100001Request()
    {
        // Arrange
        SellOrderRequest request = new SellOrderRequest
        {
            Quantity = 100001
        };

        // Act
        Func<Task> action = async () => await _stockService.CreateSellOrderAsync(request);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(action);
    }

    [Fact]
    public async Task CreateSellOrder_TestPrice0Request()
    {
        // Arrange
        SellOrderRequest request = new SellOrderRequest
        {
            Price = 0
        };

        // Act
        Func<Task> action = async () => await _stockService.CreateSellOrderAsync(request);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(action);
    }

    [Fact]
    public async Task CreateSellOrder_TestPrice10001Request()
    {
        // Arrange
        SellOrderRequest request = new SellOrderRequest
        {
            Price = 10001
        };

        // Act
        Func<Task> action = async () => await _stockService.CreateSellOrderAsync(request);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(action);
    }

    [Fact]
    public async Task CreateSellOrder_TestStockSymbolNotNullRequest()
    {
        // Arrange
        SellOrderRequest request = new SellOrderRequest
        {
            StockSymbol = null
        };

        // Act
        Func<Task> action = async () => await _stockService.CreateSellOrderAsync(request);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(action);
    }

    [Fact]
    public async Task CreateSellOrder_TestDateAndTimeOfOrderRequest()
    {
        // Arrange
        SellOrderRequest request = new SellOrderRequest
        {
            DateAndTimeOfOrder = Convert.ToDateTime("1999-12-31")
        };

        // Act
        Func<Task> action = async () => await _stockService.CreateSellOrderAsync(request);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(action);
    }

    [Fact]
    public async Task CreateSellOrder_TestValidRequest()
    {
        // Arrange
        SellOrderRequest request = new SellOrderRequest
        {
            StockSymbol = "MSFT",
            Price = 10,
            StockName = "Test name",
            Quantity = 100,
            DateAndTimeOfOrder = Convert.ToDateTime("2004-12-28")
        };

        // Act
        var response = await _stockService.CreateSellOrderAsync(request);

        // Assert
        Assert.NotNull(response);
        Assert.IsType<BuyOrderResponse>(response);
        Assert.NotNull(response.SellOrderID.ToString());
    }
    #endregion

    #region GetAllBuyOrders

    [Fact]
    public async Task GetAllBuyOrders_TestEmptyListResult()
    {
        // Act
        List<BuyOrderResponse> response = await _stockService.GetBuyOrdersAsync();

        // Assert
        Assert.Empty(response);
    }

    [Fact]
    public async Task GetAllBuyOrders_TestListResult()
    {
        // Arrange
        List<BuyOrderRequest> buyOrderRequests = new List<BuyOrderRequest>
        {
            // 1. Typical valid request
            new BuyOrderRequest
            {
                StockSymbol = "MSFT",
                StockName = "Microsoft Corp",
                DateAndTimeOfOrder = new DateTime(2023, 5, 20),
                Quantity = 150,
                Price = 250.50
            },

            // 2. Minimum valid boundary values
            new BuyOrderRequest
            {
                StockSymbol = "AAPL",
                StockName = "Apple Inc",
                DateAndTimeOfOrder = new DateTime(2000, 1, 1), // Minimum allowed date
                Quantity = 1, // Minimum allowed quantity
                Price = 1.0 // Minimum allowed price
            },

            // 3. Maximum valid boundary values
            new BuyOrderRequest
            {
                StockSymbol = "GOOGL",
                StockName = "Alphabet Inc",
                DateAndTimeOfOrder = DateTime.Now,
                Quantity = 100000, // Maximum allowed quantity
                Price = 10000.0 // Maximum allowed price
            }
        };
        foreach (var request in buyOrderRequests)
        {
            await _stockService.CreateBuyOrderAsync(request);
        }

        // Act
        List<BuyOrderResponse> buyOrderResponses = await _stockService.GetBuyOrdersAsync();

        // Assert
        Assert.NotNull(buyOrderResponses);
        Assert.NotEmpty(buyOrderResponses);
        Assert.Equal(buyOrderRequests.Count, buyOrderResponses.Count);

        foreach (var request in buyOrderRequests)
        {
            Assert.Contains(buyOrderResponses, response =>
                response.StockName == request.StockName &&
                response.StockSymbol == request.StockSymbol &&
                response.Quantity == request.Quantity &&
                response.Price == request.Price &&
                response.DateAndTimeOfOrder == request.DateAndTimeOfOrder);
        }
    }
    #endregion

    #region GetAllSellOrders

    [Fact]
    public async Task GetAllSellOrders_TestEmptyListResult()
    {
        // Act
        List<SellOrderResponse> response = await _stockService.GetSellOrdersAsync();

        // Assert
        Assert.Empty(response);
    }

    [Fact]
    public async Task GetAllSellOrders_TestListResult()
    {
        // Arrange
        List<SellOrderRequest> sellOrderRequests = new List<SellOrderRequest>
        {
            // 1. Typical valid request
            new SellOrderRequest
            {
                StockSymbol = "MSFT",
                StockName = "Microsoft Corp",
                DateAndTimeOfOrder = new DateTime(2023, 5, 20),
                Quantity = 150,
                Price = 250.50
            },

            // 2. Minimum valid boundary values
            new SellOrderRequest
            {
                StockSymbol = "AAPL",
                StockName = "Apple Inc",
                DateAndTimeOfOrder = new DateTime(2000, 1, 1), // Minimum allowed date
                Quantity = 1, // Minimum allowed quantity
                Price = 1.0 // Minimum allowed price
            },

            // 3. Maximum valid boundary values
            new SellOrderRequest
            {
                StockSymbol = "GOOGL",
                StockName = "Alphabet Inc",
                DateAndTimeOfOrder = DateTime.Now, // Maximum allowed date (or recent)
                Quantity = 100000, // Maximum allowed quantity
                Price = 10000.0 // Maximum allowed price
            }
        };
        foreach (var request in sellOrderRequests)
        {
            await _stockService.CreateSellOrderAsync(request);
        }

        // Act
        List<SellOrderResponse> sellOrderResponses = await _stockService.GetSellOrdersAsync();

        // Assert
        Assert.NotNull(sellOrderResponses);
        Assert.NotEmpty(sellOrderResponses);
        Assert.Equal(sellOrderRequests.Count, sellOrderResponses.Count);

        foreach (var request in sellOrderRequests)
        {
            Assert.Contains(sellOrderResponses, response =>
                response.StockName == request.StockName &&
                response.StockSymbol == request.StockSymbol &&
                response.Quantity == request.Quantity &&
                response.Price == request.Price &&
                response.DateAndTimeOfOrder == request.DateAndTimeOfOrder);
        }
    }
    #endregion
}



