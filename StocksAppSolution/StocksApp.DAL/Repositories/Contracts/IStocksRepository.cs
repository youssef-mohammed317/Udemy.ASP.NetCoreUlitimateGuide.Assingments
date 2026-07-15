using StocksApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StocksApp.DAL.Repositories.Contracts;

public interface IStocksRepository
{
    Task<BuyOrder?> CreateBuyOrderAsync(BuyOrder buyOrder);

    Task<SellOrder?> CreateSellOrderAsync(SellOrder sellOrder);

    Task<List<BuyOrder>> GetBuyOrdersAsync();

    Task<List<SellOrder>> GetSellOrdersAsync();
}
