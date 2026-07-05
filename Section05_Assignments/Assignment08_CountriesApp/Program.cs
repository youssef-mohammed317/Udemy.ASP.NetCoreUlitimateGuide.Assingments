// Requirement: Create an Asp.Net Core Web Application that serves country details based on the request path.

/*
Route Constraints:

    The "countryID" parameter should be an int value.

    The value of "countryID" parameter should be between 1 and 100.



Instructions:

    Create routes with UseEndPoints() middleware.

    Use essential route parameters and route constraints.

    Use parameter validation when necessary.

    Use Map(), MapGet() or MapPost() methods to create endpoints, according to the requirement.

    Return the response with appropriate response status code based on above examples.
 
 */


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseRouting();

Dictionary<int, string> countries = new Dictionary<int, string>
{
    { 1, "United States" },
    { 2, "Canada" },
    { 3, "United Kingdom" },
    { 4, "India" },
    { 5, "Japan" }
};
app.UseEndpoints(config =>
{
    config.MapGet("/countries", async (HttpContext context) =>
    {
        context.Response.StatusCode = StatusCodes.Status200OK;
        context.Response.ContentType = "text/plain";
        await context.Response.WriteAsync(string.Join("\n", countries.Select(kv => $"{kv.Value}")));
        return;
    });
    config.MapGet("/countries/{countryID:int}", async (HttpContext context) =>
    {
        var routevalues = context.Request.RouteValues;
        int id = int.Parse(routevalues["countryID"].ToString());

        if (id >= 1 && id <= 100)
        {

            if (countries.ContainsKey(id))
            {
                context.Response.StatusCode = StatusCodes.Status200OK;
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync(countries[id]);
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync("No Country");
            }
        }
        else
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Response.ContentType = "text/plain";
            await context.Response.WriteAsync("The CountryID should be between 1 and 100\r\n\r\n");
        }
        return;
    });

});

app.Run();
