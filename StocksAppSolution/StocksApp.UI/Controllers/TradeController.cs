using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
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
    public async Task<IActionResult> Index()
    {
        StockTradeViewModel viewModel = new StockTradeViewModel();

        var companyProfile = await _finnhubService.GetCompanyProfile(_tradingOptions.DefaultStockSymbol!);

        var stockPriceQuote = await _finnhubService.GetStockPriceQuote(_tradingOptions.DefaultStockSymbol!);

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
        //viewModel.Quantity = 0;

        return View(viewModel);
    }
}
