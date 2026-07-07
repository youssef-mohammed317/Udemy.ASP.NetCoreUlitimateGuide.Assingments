using Assignment22_WeatherApp.Services.Implementations;
using Assignment22_WeatherApp.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IWeatherService, WeatherService>();
var app = builder.Build();
app.UseStaticFiles();
app.MapControllers();

app.Run();
