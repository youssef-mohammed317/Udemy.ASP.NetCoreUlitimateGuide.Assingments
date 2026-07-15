using Microsoft.AspNetCore.Mvc;
using StocksApp.BLL.Services.Contracts;
using StocksApp.UI.ViewModels;

namespace StocksApp.UI.ViewComponents;

public class SelectedStockViewComponent(IFinnhubService finnhubService) : ViewComponent
{
    private readonly IFinnhubService _finnhubService = finnhubService;

    public async Task<IViewComponentResult> InvokeAsync(string? stockSymbol)
    {
        if (string.IsNullOrEmpty(stockSymbol))
        {
            return Content(string.Empty);
        }

        var companyProfile = await _finnhubService.GetCompanyProfileAsync(stockSymbol);
        var priceQuote = await _finnhubService.GetStockPriceQuoteAsync(stockSymbol);

        if (companyProfile == null || priceQuote == null)
        {
            return Content(string.Empty);
        }

        var model = new SelectedStockViewModel
        {
            Name = companyProfile.ContainsKey("name") ? companyProfile["name"]?.ToString() : null,
            Symbol = companyProfile.ContainsKey("ticker") ? companyProfile["ticker"]?.ToString() : null,
            Logo = companyProfile.ContainsKey("logo") ? companyProfile["logo"]?.ToString() : null,
            Industry = companyProfile.ContainsKey("finnhubIndustry") ? companyProfile["finnhubIndustry"]?.ToString() : null,
            Exchange = companyProfile.ContainsKey("exchange") ? companyProfile["exchange"]?.ToString() : null,
            Price = priceQuote.ContainsKey("c") ? Convert.ToDouble(priceQuote["c"].ToString()) : 0
        };

        return View(model);
    }
}
