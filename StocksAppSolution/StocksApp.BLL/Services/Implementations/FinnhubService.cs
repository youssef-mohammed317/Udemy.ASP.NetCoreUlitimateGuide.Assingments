using Microsoft.Extensions.Options;
using StocksApp.BLL.Services.Contracts;
using StocksApp.DAL.Repositories.Contracts;
using StocksApp.UI.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace StocksApp.BLL.Services.Implementations;

public class FinnhubService(IFinnhubRepository finnhubRepository) : IFinnhubService
{
    private readonly IFinnhubRepository _finnhubRepository = finnhubRepository;

    public async Task<Dictionary<string, object>?> GetCompanyProfileAsync(string stockSymbol)
    {
        return await _finnhubRepository.GetCompanyProfileAsync(stockSymbol);

    }

    public async Task<Dictionary<string, object>?> GetStockPriceQuoteAsync(string stockSymbol)
    {
        return await _finnhubRepository.GetStockPriceQuoteAsync(stockSymbol);
    }

    public async Task<List<Dictionary<string, string>>?> GetStocks()
    {

        return await _finnhubRepository.GetStocksAsync();
    }

    public async Task<Dictionary<string, object>?> SearchStocks(string stockSymbolToSearch)
    {
        return await _finnhubRepository.SearchStocksAsync(stockSymbolToSearch);
    }
}
