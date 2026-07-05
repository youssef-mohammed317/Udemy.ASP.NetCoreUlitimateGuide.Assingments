// Requirement: Imagine a banking application. Create an Asp.Net Core Web Application
// that serves bank account details based on the request path.
// Consider the following hard-coded bank account details:
// accountNumber = 1001, accountHolderName = "Example Name", currentBalance = 5000
// You can store these details as an anonymous object. Eg: new { property1 = value, property2 = value }


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();
