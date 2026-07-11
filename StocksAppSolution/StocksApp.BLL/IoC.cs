using Microsoft.Extensions.DependencyInjection;
using StocksApp.BLL.Services.Contracts;
using StocksApp.BLL.Services.Implementations;

namespace StocksApp.BLL;

public static class IoC
{
    public static IServiceCollection AddBusinessLogicLayer(this IServiceCollection services)
    {
        services.AddScoped<IFinnhubService, FinnhubService>();
        services.AddScoped<IStocksService, StocksService>();

        return services;
    }
}
