using StocksApp.BLL;
using StocksApp.UI.CustomOptions;
using StocksApp.DAL;
using Rotativa.AspNetCore;
using Serilog;
using SerilogTimings;
using StocksApp.UI.Middlewares;


Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();
try
{

    Log.Information("Starting up the application...");
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog((context, services, configuration) => configuration
            .ReadFrom.Configuration(context.Configuration)
            .ReadFrom.Services(services)
            .Enrich.FromLogContext());

    builder.Services.AddControllersWithViews();

    builder.Services.AddBusinessLogicLayer();

    builder.Services.AddDataAccessLayer(builder.Configuration);

    builder.Services.Configure<TradingOptions>(builder.Configuration.GetSection("TradingOptions"));

    builder.Services.AddHttpClient();


    var app = builder.Build();


    app.UseExceptionHandlingMiddleware();

    app.UseSerilogRequestLogging();

    RotativaConfiguration.Setup(app.Environment.WebRootPath, wkhtmltopdfRelativePath: "Rotativa");

    app.UseStaticFiles();

    app.MapControllers();

    app.Run();

}
catch (Exception ex)
{
    Log.Fatal(ex, "Application start-up failed");
}
finally
{
    Log.CloseAndFlush();
}

public partial class Program { }