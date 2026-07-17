using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using Rotativa.AspNetCore;
using SerilogTimings;
using StocksApp.BLL.DTOs;
using StocksApp.BLL.Services.Contracts;
using StocksApp.UI.CustomOptions;
using StocksApp.UI.Filters;
using StocksApp.UI.ViewModels;

namespace StocksApp.UI.Controllers;

[Route("[controller]/[action]")]
public class TradeController(IFinnhubService finnhubService, IOptions<TradingOptions> tradingOptions, IStocksService stocksService, ILogger<TradeController> logger) : Controller
{
    private readonly TradingOptions _tradingOptions = tradingOptions.Value;
    private readonly IFinnhubService _finnhubService = finnhubService;
    private readonly IStocksService _stocksService = stocksService;
    private readonly ILogger<TradeController> _logger = logger;

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        StockTradeViewModel viewModel = new StockTradeViewModel();
        using (Operation.Time("Start execution of index action", _tradingOptions.DefaultStockSymbol!.ToString()))
        {

            _logger.LogInformation("Start {@ContollerName} - {@MethodName}", nameof(TradeController), nameof(Index));


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

            _logger.LogInformation("End {@ContollerName} - {@MethodName} : ViewModel : {@viewModel}", nameof(TradeController), nameof(Index), viewModel);
        }
        return View(viewModel);
    }
    [HttpPost]
    [TypeFilter(typeof(ModelStateValidationFilterAttribute))]
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
    [TypeFilter(typeof(ModelStateValidationFilterAttribute))]
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
