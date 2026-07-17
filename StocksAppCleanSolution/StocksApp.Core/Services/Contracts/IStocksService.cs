using StocksApp.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StocksApp.Core.Services.Contracts;

public interface IStocksService
{
    Task<BuyOrderResponse?> CreateBuyOrderAsync(BuyOrderRequest? buyOrderRequest);

    Task<SellOrderResponse?> CreateSellOrderAsync(SellOrderRequest? sellOrderRequest);

    Task<List<BuyOrderResponse>> GetBuyOrdersAsync();

    Task<List<SellOrderResponse>> GetSellOrdersAsync();
}
