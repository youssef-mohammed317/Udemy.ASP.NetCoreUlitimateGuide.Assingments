using StocksApp.BLL;
using StocksApp.UI.CustomOptions;
using StocksApp.DAL;
using Rotativa.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddBusinessLogicLayer();

builder.Services.AddDataAccessLayer(builder.Configuration);

builder.Services.Configure<TradingOptions>(builder.Configuration.GetSection("TradingOptions"));

builder.Services.AddHttpClient();


var app = builder.Build();

RotativaConfiguration.Setup(app.Environment.WebRootPath, wkhtmltopdfRelativePath: "Rotativa");

app.UseStaticFiles();

app.MapControllers();

app.Run();

public partial class Program { }