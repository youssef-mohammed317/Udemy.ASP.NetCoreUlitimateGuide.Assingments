using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StocksApp.BLL.DTOs;
using StocksApp.BLL.Services.Contracts;
using StocksApp.DAL.DbContexts;
using StocksApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StocksApp.BLL.Services.Implementations;

public class StocksService(StockMarketDbContext context, IMapper mapper) : IStocksService
{
    private readonly StockMarketDbContext _context = context;
    private readonly IMapper _mapper = mapper;
    //TradeAmount = Price* Quantity // done in mapping
    public async Task<BuyOrderResponse?> CreateBuyOrderAsync(BuyOrderRequest? buyOrderRequest)
    {
        //Inserts a new buy order into the database table called 'BuyOrders'.

        if (buyOrderRequest == null)
            throw new ArgumentNullException(nameof(buyOrderRequest));


        var validationContext = new ValidationContext(buyOrderRequest);
        var errors = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(buyOrderRequest, validationContext, errors, true);
        if (!isValid)
        {
            throw new ArgumentException(string.Join(", ", errors.Select(e => e.ErrorMessage)));
        }

        var request = _mapper.Map<BuyOrder>(buyOrderRequest);
        await _context.BuyOrders.AddAsync(request);
        var rowAffected = await _context.SaveChangesAsync();
        if (rowAffected > 0)
            return _mapper.Map<BuyOrderResponse>(request);
        return null;
    }

    public async Task<SellOrderResponse?> CreateSellOrderAsync(SellOrderRequest? sellOrderRequest)
    {
        // Inserts a new sell order into the database table called 'SellOrders'.

        if (sellOrderRequest == null)
            throw new ArgumentNullException(nameof(sellOrderRequest));

        var validationContext = new ValidationContext(sellOrderRequest);
        var errors = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(sellOrderRequest, validationContext, errors, true);
        if (!isValid)
        {
            throw new ArgumentException(string.Join(", ", errors.Select(e => e.ErrorMessage)));
        }

        var request = _mapper.Map<SellOrder>(sellOrderRequest);
        await _context.SellOrders.AddAsync(request);
        var rowAffected = await _context.SaveChangesAsync();
        if (rowAffected > 0)
            return _mapper.Map<SellOrderResponse>(request);
        return null;
    }

    public async Task<List<BuyOrderResponse>> GetBuyOrdersAsync()
    {
        //Returns the existing list of buy orders retrieved from database table called 'BuyOrders'.
        var orders = await _context.BuyOrders.ToListAsync();
        return _mapper.Map<List<BuyOrderResponse>>(orders);
    }

    public async Task<List<SellOrderResponse>> GetSellOrdersAsync()
    {
        //Returns the existing list of sell orders retrieved from database table called 'SellOrders'.
        var orders = await _context.SellOrders.ToListAsync();
        return _mapper.Map<List<SellOrderResponse>>(orders);
    }
}
