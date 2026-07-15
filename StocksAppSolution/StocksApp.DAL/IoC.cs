using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StocksApp.DAL.DbContexts;

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

        return services;
    }
}
