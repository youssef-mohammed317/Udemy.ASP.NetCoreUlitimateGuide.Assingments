//Requirement: Create an Asp.Net Core Web Application that receives username and password via POST request (from Postman).

//It receives "email" and "password" as query string from request body.
/*
 Instructions:

    Use custom conventional middleware (with middleware extensions) to handle the post request at path "/"

    The "email" and "password" values are mandatory

    Return appropriate HTTP status codes based on above examples.

    Do not create controllers or any other concept which is not yet covered, to avoid confusion.

 */
using Assignment06_LoginApp.Middlewares;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseLoginMiddleware();

app.Run();
