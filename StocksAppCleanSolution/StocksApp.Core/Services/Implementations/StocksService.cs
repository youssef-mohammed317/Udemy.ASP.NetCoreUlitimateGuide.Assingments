using AutoMapper;
using StocksApp.Core.DTOs;
using StocksApp.Core.Exceptions;
using StocksApp.Core.Services.Contracts;
using StocksApp.Domain.Entites;
using StocksApp.Domain.RepositoryContracts;
using System.ComponentModel.DataAnnotations;

namespace StocksApp.Core.Services.Implementations;

public class StocksService(IMapper mapper, IStocksRepository stocksRepository) : IStocksService
{
    private readonly IMapper _mapper = mapper;
    private readonly IStocksRepository _stocksRepository = stocksRepository;

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
            var errorsDictionary = errors
            .GroupBy(e => e.MemberNames.FirstOrDefault() ?? "General")
            .ToDictionary(
                g => g.Key,
                g => g.Select(e => e.ErrorMessage ?? "Invalid value").ToArray()
            );

            throw new CustomValidationException(errorsDictionary);
        }

        var buyOrder = _mapper.Map<BuyOrder>(buyOrderRequest);

        var response = await _stocksRepository.CreateBuyOrderAsync(buyOrder);
        if (response == null) return null;
        return _mapper.Map<BuyOrderResponse>(response);
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
            var errorsDictionary = errors
                .GroupBy(e => e.MemberNames?.FirstOrDefault() ?? "General")
                .ToDictionary(g => g.Key, g => g.Select(e => e.ErrorMessage ?? "Invalid value").ToArray());

            throw new CustomValidationException(errorsDictionary);
        }

        var sellOrder = _mapper.Map<SellOrder>(sellOrderRequest);
        var response = await _stocksRepository.CreateSellOrderAsync(sellOrder);

        if (response == null) return null;

        return _mapper.Map<SellOrderResponse>(response);
    }
    public async Task<List<BuyOrderResponse>> GetBuyOrdersAsync()
    {
        //Returns the existing list of buy orders retrieved from database table called 'BuyOrders'.
        var orders = await _stocksRepository.GetBuyOrdersAsync();
        if (orders == null || !orders.Any())
        {
            return [];
        }

        return _mapper.Map<List<BuyOrderResponse>>(orders);
    }

    public async Task<List<SellOrderResponse>> GetSellOrdersAsync()
    {
        //Returns the existing list of sell orders retrieved from database table called 'SellOrders'.
        var orders = await _stocksRepository.GetSellOrdersAsync();

        if (orders == null || !orders.Any())
        {
            return [];
        }

        return _mapper.Map<List<SellOrderResponse>>(orders);
    }
}
