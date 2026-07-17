using Microsoft.EntityFrameworkCore;
using StocksApp.Domain.Entites;
using StocksApp.Domain.RepositoryContracts;
using StocksApp.Infrastructure.DbContexts;

namespace StocksApp.Infrastructure.Repositories;

public class StocksRepository(StockMarketDbContext context) : IStocksRepository
{
    private readonly StockMarketDbContext _context = context;

    public async Task<BuyOrder?> CreateBuyOrderAsync(BuyOrder buyOrder)
    {
        await _context.BuyOrders.AddAsync(buyOrder);
        var rowAffected = await _context.SaveChangesAsync();
        if (rowAffected > 0)
            return buyOrder;
        return null;
    }

    public async Task<SellOrder?> CreateSellOrderAsync(SellOrder sellOrder)
    {
        await _context.SellOrders.AddAsync(sellOrder);
        var rowAffected = await _context.SaveChangesAsync();
        if (rowAffected > 0)
            return sellOrder;
        return null;
    }

    public async Task<List<BuyOrder>> GetBuyOrdersAsync()
    {
        return await _context.BuyOrders.ToListAsync();
    }

    public async Task<List<SellOrder>> GetSellOrdersAsync()
    {
        return await _context.SellOrders.ToListAsync();
    }
}
