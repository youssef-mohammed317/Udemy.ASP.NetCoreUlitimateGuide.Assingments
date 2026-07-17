using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StocksApp.Domain.RepositoryContracts;
using StocksApp.Infrastructure.DbContexts;
using StocksApp.Infrastructure.Repositories;

namespace StocksApp.Infrastructure;

public static class IoC
{
    public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
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
