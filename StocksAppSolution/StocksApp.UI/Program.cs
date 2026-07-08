using StocksApp.BLL;
using StocksApp.UI.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddBusinessLogicLayer();

builder.Services.Configure<TradingOptions>(builder.Configuration.GetSection("TradingOptions"));

builder.Services.AddHttpClient();

var app = builder.Build();

app.UseStaticFiles();

app.MapControllers();

app.Run();
