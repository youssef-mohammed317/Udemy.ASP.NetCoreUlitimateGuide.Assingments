using AutoMapper;
using StocksApp.BLL.DTOs;
using StocksApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StocksApp.BLL.Mappers;

public class SellOrderMappingProfile : Profile
{
    public SellOrderMappingProfile()
    {
        CreateMap<SellOrderRequest, SellOrder>()
            .ForMember(dest => dest.StockName, opt => opt.MapFrom(src => src.StockName))
            .ForMember(dest => dest.StockSymbol, opt => opt.MapFrom(src => src.StockSymbol))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.DateAndTimeOfOrder, opt => opt.MapFrom(src => src.DateAndTimeOfOrder));

        CreateMap<SellOrder, SellOrderResponse>()
            .ForMember(dest => dest.SellOrderID, opt => opt.MapFrom(src => src.SellOrderID))
            .ForMember(dest => dest.StockName, opt => opt.MapFrom(src => src.StockName))
            .ForMember(dest => dest.StockSymbol, opt => opt.MapFrom(src => src.StockSymbol))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.DateAndTimeOfOrder, opt => opt.MapFrom(src => src.DateAndTimeOfOrder))
            .ForMember(dest => dest.TradeAmount, opt => opt.MapFrom(src => src.Price * src.Quantity));

    }
}
