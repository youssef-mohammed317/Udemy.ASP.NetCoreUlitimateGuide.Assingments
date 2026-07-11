using StocksApp.BLL.DTOs;
using StocksApp.BLL.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StocksApp.BLL.Services.Implementations;

public class StocksService : IStocksService
{
    //TradeAmount = Price* Quantity

    public Task<BuyOrderResponse> CreateBuyOrderAsync(BuyOrderRequest? buyOrderRequest)
    {
        //Inserts a new buy order into the database table called 'BuyOrders'.
        throw new NotImplementedException();
    }

    public Task<SellOrderResponse> CreateSellOrderAsync(SellOrderRequest? sellOrderRequest)
    {
        // Inserts a new sell order into the database table called 'SellOrders'.
        throw new NotImplementedException();
    }

    public Task<List<BuyOrderResponse>> GetBuyOrdersAsync()
    {
        //Returns the existing list of buy orders retrieved from database table called 'BuyOrders'.
        throw new NotImplementedException();
    }

    public Task<List<SellOrderResponse>> GetSellOrdersAsync()
    {
        //Returns the existing list of sell orders retrieved from database table called 'SellOrders'.
        throw new NotImplementedException();
    }
}
