// Ignore Spelling: Finnhub

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StocksApp.BLL.Services.Contracts;

public interface IFinnhubService
{
    Task<Dictionary<string, object>?> GetCompanyProfileAsync(string stockSymbol);
    Task<Dictionary<string, object>?> GetStockPriceQuoteAsync(string stockSymbol);
    Task<List<Dictionary<string, string>>?> GetStocks();

    Task<Dictionary<string, object>?> SearchStocks(string stockSymbolToSearch);

}
