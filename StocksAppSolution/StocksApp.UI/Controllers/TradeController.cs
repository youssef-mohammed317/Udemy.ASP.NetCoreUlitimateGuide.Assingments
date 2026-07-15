using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Rotativa.AspNetCore;
using StocksApp.BLL.DTOs;
using StocksApp.BLL.Services.Contracts;
using StocksApp.UI.Options;
using StocksApp.UI.ViewModels;

namespace StocksApp.UI.Controllers;

[Route("[controller]/[action]")]
public class TradeController(IFinnhubService finnhubService, IOptions<TradingOptions> tradingOptions, IStocksService stocksService) : Controller
{
    private readonly TradingOptions _tradingOptions = tradingOptions.Value;
    private readonly IFinnhubService _finnhubService = finnhubService;
    private readonly IStocksService _stocksService = stocksService;

    [HttpGet]
    [Route("/")]
    public async Task<IActionResult> Index()
    {
        StockTradeViewModel viewModel = new StockTradeViewModel();

        var companyProfile = await _finnhubService.GetCompanyProfileAsync(_tradingOptions.DefaultStockSymbol!);

        var stockPriceQuote = await _finnhubService.GetStockPriceQuoteAsync(_tradingOptions.DefaultStockSymbol!);

        if (stockPriceQuote == null || companyProfile == null)
            return View(viewModel);


        if (companyProfile.ContainsKey("name"))
        {
            viewModel.StockName = companyProfile["name"].ToString();
        }

        if (companyProfile.ContainsKey("ticker"))
        {
            viewModel.StockSymbol = companyProfile["ticker"].ToString();
        }
        if (stockPriceQuote.ContainsKey("c"))
        {
            viewModel.Price = Convert.ToDouble(stockPriceQuote["c"].ToString());
        }
        viewModel.Quantity = _tradingOptions.DefaultOrderQuantity;


        return View(viewModel);
    }
    [HttpPost]
    public async Task<IActionResult> BuyOrder([FromForm] BuyOrderRequest orderRequest)
    {
        orderRequest.DateAndTimeOfOrder = DateTime.Now;

        if (ModelState.IsValid)
        {
            var response = await _stocksService.CreateBuyOrderAsync(orderRequest);
            if (response == null)
            {
                // you can send a notification or any thing
            }
            return RedirectToAction(nameof(TradeController.Orders));
        }

        StockTradeViewModel viewModel = new StockTradeViewModel
        {
            StockSymbol = orderRequest.StockSymbol,
            StockName = orderRequest.StockName,
            Price = orderRequest.Price,
            Quantity = orderRequest.Quantity,
        };

        return View(nameof(TradeController.Index), viewModel);
    }
    [HttpPost]
    public async Task<IActionResult> SellOrder([FromForm] SellOrderRequest orderRequest)
    {
        orderRequest.DateAndTimeOfOrder = DateTime.Now;

        if (ModelState.IsValid)
        {
            var response = await _stocksService.CreateSellOrderAsync(orderRequest);
            if (response == null)
            {
                // you can send a notification or any thing
            }
            return RedirectToAction(nameof(TradeController.Orders));
        }

        StockTradeViewModel viewModel = new StockTradeViewModel
        {
            StockSymbol = orderRequest.StockSymbol,
            StockName = orderRequest.StockName,
            Price = orderRequest.Price,
            Quantity = orderRequest.Quantity,
        };

        return View(nameof(TradeController.Index), viewModel);
    }
    [HttpGet]
    public async Task<IActionResult> Orders()
    {
        var orderViewModel = new OrdersViewModel();

        orderViewModel.SellOrders = await _stocksService.GetSellOrdersAsync();
        orderViewModel.BuyOrders = await _stocksService.GetBuyOrdersAsync();

        return View(orderViewModel);
    }
    [HttpGet]
    public async Task<IActionResult> OrdersPDF()
    {
        var orderViewModel = new OrdersViewModel();

        orderViewModel.SellOrders = await _stocksService.GetSellOrdersAsync();
        orderViewModel.BuyOrders = await _stocksService.GetBuyOrdersAsync();

        return new ViewAsPdf("OrdersPDF", orderViewModel, ViewData)
        {
            PageMargins = new Rotativa.AspNetCore.Options.Margins()
            {
                Top = 20,
                Bottom = 20,
                Left = 20,
                Right = 20,
            },
            PageSize = Rotativa.AspNetCore.Options.Size.A4,
            PageOrientation = Rotativa.AspNetCore.Options.Orientation.Landscape
        };
    }
}
