using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StocksApp.DAL.DbContexts;
using StocksApp.DAL.Repositories;
using StocksApp.DAL.Repositories.Contracts;
using StocksApp.DAL.Repositories.Implementations;

namespace StocksApp.DAL;

public static class IoC
{
    public static IServiceCollection AddDataAccessLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<StockMarketDbContext>(options =>
        {
            var connectionString = configuration.GetConnectionString(nameof(StockMarketDbContext));
            options.UseSqlServer(connectionString);
        });

        services.AddScoped<IFinnhubRepository, FinnhubRepository>();
        services.AddScoped<IStocksRepository, StocksRepository>();

        return services;
    }
}
