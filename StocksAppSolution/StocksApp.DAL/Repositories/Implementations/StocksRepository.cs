using Microsoft.EntityFrameworkCore;
using StocksApp.DAL.DbContexts;
using StocksApp.DAL.Entities;
using StocksApp.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StocksApp.DAL.Repositories.Implementations;

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
