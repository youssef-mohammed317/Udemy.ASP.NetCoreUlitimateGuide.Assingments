using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using StocksApp.BLL.Services.Contracts;
using StocksApp.UI.CustomOptions;
using StocksApp.UI.ViewModels;

namespace StocksApp.UI.Controllers;

[Route("[controller]/[action]")]
public class StocksController(IFinnhubService finnhubService, IStocksService stocksService, IOptions<TradingOptions> tradingOptions) : Controller
{
    private readonly IFinnhubService _finnhubService = finnhubService;
    private readonly IStocksService _stocksService = stocksService;
    private readonly TradingOptions _tradingOptions = tradingOptions.Value;

    [HttpGet("{stock?}")]
    public async Task<IActionResult> Explore(string? stock)
    {

        List<Dictionary<string, string>>? stocks = await _finnhubService.GetStocks();

        var top25 = _tradingOptions.Top25PopularStocks!.Split(",").ToList();
        var requiredStocks = stocks!.Where(s => top25.Contains(s["symbol"])).ToList();

        List<StockViewModel> viewModel = new List<StockViewModel>();

        foreach (var s in requiredStocks)
        {
            if (s.ContainsKey("displaySymbol") && s.ContainsKey("symbol"))
                viewModel.Add(new StockViewModel { StockName = s["displaySymbol"], StockSymbol = s["symbol"] });
        }

        ViewBag.StockSymbol = stock;

        return View(viewModel);
    }
}
