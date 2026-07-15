using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StocksApp.DAL.Repositories.Contracts;

public interface IFinnhubRepository
{
    Task<Dictionary<string, object>?> GetCompanyProfileAsync(string stockSymbol);

    Task<Dictionary<string, object>?> GetStockPriceQuoteAsync(string stockSymbol);

    Task<List<Dictionary<string, string>>?> GetStocksAsync();

    Task<Dictionary<string, object>?> SearchStocksAsync(string stockSymbolToSearch);
}
