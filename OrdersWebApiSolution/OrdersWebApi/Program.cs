using Microsoft.AspNetCore.OpenApi;
using Microsoft.EntityFrameworkCore;
using OrdersWebApi.CustomMiddlewares;
using OrdersWebApi.Database.Contexts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefalutConnection"));
});

builder.Services.AddControllers();
builder.Services.AddOpenApi(); // replaces AddSwaggerGen

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi(); // serves the OpenAPI JSON at /openapi/v1.json
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "Orders Web API v1");
    });
}

app.UseExceptionHandlingMiddleware();
app.UseRouting();
app.MapControllers();

app.Run();