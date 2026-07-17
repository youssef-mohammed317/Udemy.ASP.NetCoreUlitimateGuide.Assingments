using Microsoft.Extensions.DependencyInjection;
using StocksApp.Core.Mappers;
using StocksApp.Core.Services.Contracts;
using StocksApp.Core.Services.Implementations;

namespace StocksApp.Core;

public static class IoC
{
    public static IServiceCollection AddCoreLayer(this IServiceCollection services)
    {
        services.AddScoped<IFinnhubService, FinnhubService>();
        services.AddScoped<IStocksService, StocksService>();

        services.AddAutoMapper(typeof(BuyOrderMappingProfile).Assembly);

        return services;
    }
}
