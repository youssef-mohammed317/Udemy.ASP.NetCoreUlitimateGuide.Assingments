using StocksApp.Core.Services.Contracts;
using StocksApp.Domain.RepositoryContracts;


namespace StocksApp.Core.Services.Implementations;

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
