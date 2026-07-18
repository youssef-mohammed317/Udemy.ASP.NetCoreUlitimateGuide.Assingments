using Microsoft.EntityFrameworkCore;
using OrdersWebApi.CustomMiddlewares;
using OrdersWebApi.Database.Contexts;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefalutConnection"));
});

var app = builder.Build();

app.UseExceptionHandlingMiddleware();

app.UseRouting();

app.MapControllers();

app.Run();
