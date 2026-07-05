//It receives "firstNumber", "secondNumber" and "operation" as inputs as query as a part of the URL.
/*
 Instructions:
    Use app.Run() method to define code for calculation of result based on given numbers and operation

    The user can only supply two numbers as "firstNumber" and "secondNumber" parameters.

    The "firstNumber", "secondNumber" and "operation" values are mandatory

    Return appropriate HTTP status codes based on above examples.

    Do not create controllers or any other concept which is not yet covered, to avoid confusion.
 */
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

app.Run(async (HttpContext context) =>
{
    if (context.Request.Method == "GET" && context.Request.Path == "/")
    {
        var queries = context.Request.Query;

        int? firstNumber = null, secondNumber = null;
        string? operation = null;
        bool invalid = false;

        if (queries.ContainsKey("firstNumber"))
        {
            firstNumber = Convert.ToInt32(queries["firstNumber"][0]);

        }
        else
        {
            invalid = true;
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsJsonAsync("Invalid input for 'firstNumber'");
        }
        if (queries.ContainsKey("secondNumber"))
        {
            secondNumber = Convert.ToInt32(queries["secondNumber"][0]);
        }
        else
        {
            invalid = true;
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsJsonAsync("Invalid input for 'secondNumber'");
        }
        if (queries.ContainsKey("operation"))
        {
            operation = queries["operation"][0];
            string[]? operations = ["add", "sub", "mul", "div", "mod"];
            if (!operations.Contains(operation, StringComparer.OrdinalIgnoreCase))
            {
                invalid = true;
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsJsonAsync("Invalid input for 'operation'");
            }
        }
        else
        {
            invalid = true;
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsJsonAsync("Invalid input for 'operation'");
        }

        if (!invalid)
        {
            int? result = (operation) switch
            {
                "add" => firstNumber + secondNumber,
                "sub" => firstNumber - secondNumber,
                "mul" => firstNumber * secondNumber,
                "div" => firstNumber / secondNumber,
                "mod" => firstNumber % secondNumber,
                _ => 0,
            };

            context.Response.StatusCode = StatusCodes.Status200OK;
            await context.Response.WriteAsJsonAsync($"{firstNumber} {operation} {secondNumber} = {result}");
        }
    }
});

app.Run();