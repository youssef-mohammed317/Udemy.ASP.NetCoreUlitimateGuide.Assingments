using AutoMapper;
using StocksApp.Core.DTOs;
using StocksApp.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StocksApp.Core.Mappers;

public class BuyOrderMappingProfile : Profile
{
    public BuyOrderMappingProfile()
    {
        CreateMap<BuyOrderRequest, BuyOrder>()
            .ForMember(dest => dest.StockName, opt => opt.MapFrom(src => src.StockName))
            .ForMember(dest => dest.StockSymbol, opt => opt.MapFrom(src => src.StockSymbol))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.DateAndTimeOfOrder, opt => opt.MapFrom(src => src.DateAndTimeOfOrder));

        CreateMap<BuyOrder, BuyOrderResponse>()
            .ForMember(dest => dest.BuyOrderID, opt => opt.MapFrom(src => src.BuyOrderID))
            .ForMember(dest => dest.StockName, opt => opt.MapFrom(src => src.StockName))
            .ForMember(dest => dest.StockSymbol, opt => opt.MapFrom(src => src.StockSymbol))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.DateAndTimeOfOrder, opt => opt.MapFrom(src => src.DateAndTimeOfOrder))
            .ForMember(dest => dest.TradeAmount, opt => opt.MapFrom(src => src.Price * src.Quantity));

    }
}
