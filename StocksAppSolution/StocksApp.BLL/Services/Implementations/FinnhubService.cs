using Microsoft.Extensions.Options;
using StocksApp.BLL.Services.Contracts;
using StocksApp.UI.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace StocksApp.BLL.Services.Implementations;

public class FinnhubService(IHttpClientFactory httpClientFactory, IOptions<TradingOptions> tradingOptions) : IFinnhubService
{
    private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
    private readonly TradingOptions _tradingOptions = tradingOptions.Value;

    public async Task<Dictionary<string, object>?> GetCompanyProfile(string stockSymbol)
    {
        //https://finnhub.io/api/v1/stock/profile2?symbol={symbol}&token={token}

        string link = $"https://finnhub.io/api/v1/stock/profile2?symbol={stockSymbol}&token={_tradingOptions.SecretToken}";

        var client = _httpClientFactory.CreateClient();

        HttpResponseMessage response = await client.GetAsync(link);

        if (response.IsSuccessStatusCode)
        {
            var stringResponse = await response.Content.ReadAsStringAsync();

            var dataToReturn = JsonSerializer.Deserialize<Dictionary<string, object>>(stringResponse);

            return dataToReturn;
        }
        return null;
        //return
        //{"country":"US","currency":"USD","exchange":"NASDAQ NMS - GLOBAL MARKET","finnhubIndustry":"Technology","ipo":"1986-03-13","logo":"https://static2.finnhub.io/file/publicdatany/finnhubimage/stock_logo/MSFT.svg","marketCapitalization":1758286.5806001066,"name":"Microsoft Corp","phone":"14258828080.0","shareOutstanding":7454.47,"ticker":"MSFT","weburl":"https://www.microsoft.com/en-us"}
    }

    public async Task<Dictionary<string, object>?> GetStockPriceQuote(string stockSymbol)
    {
        //https://finnhub.io/api/v1/quote?symbol={symbol}&token={token}

        var link = $"https://finnhub.io/api/v1/quote?symbol={stockSymbol}&token={_tradingOptions.SecretToken}";
        var client = _httpClientFactory.CreateClient();

        var response = await client.GetAsync(link);

        if (response.IsSuccessStatusCode)
        {
            var stringResponse = await response.Content.ReadAsStringAsync();
            var dataToReturn = JsonSerializer.Deserialize<Dictionary<string, object>>(stringResponse);
            return dataToReturn;
        }
        return null;
        //return
        //{"c":235.87,"d":9.12,"dp":4.0221,"h":236.6,"l":226.06,"o":226.24,"pc":226.75,"t":1666987204}
    }
}
