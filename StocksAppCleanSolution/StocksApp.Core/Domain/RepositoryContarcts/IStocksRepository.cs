
using StocksApp.Domain.Entites;

namespace StocksApp.Domain.RepositoryContracts;

public interface IStocksRepository
{
    Task<BuyOrder?> CreateBuyOrderAsync(BuyOrder buyOrder);

    Task<SellOrder?> CreateSellOrderAsync(SellOrder sellOrder);

    Task<List<BuyOrder>> GetBuyOrdersAsync();

    Task<List<SellOrder>> GetSellOrdersAsync();
}
