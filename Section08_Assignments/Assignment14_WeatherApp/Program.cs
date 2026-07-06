//Requirement:

//Imagine a weather application that shows weather details of the selected city. Create an Asp.Net Core Web Application that fulfils this requirement.
/*
Instructions:

    Create controller(s) with attribute routing.

    Initialize the hard-coded data as collection of model objects in the controller.

    Use strongly-typed views. Send model object(s) to view.

    If you supply an invalid city code as route parameter, it should show a page with proper error message, instead of throwing an exception.

    Use CSS styles, _ViewImports, Razor view engine as per the necessity.

    The UI should be consistent and modern. It should minimum look like as shown in the screenshot. Optionally, you can try enhancing it based on your thoughts.

    Apply background color for each box, based on the following categories of temperature value. Write local function in view, to determine the apppriate css class to apply background color.

      Fahrenheit is less than 44 = blue background color
      Fahrenheit is between 44 and 74 = blue background color
      Fahrenheit is greater than 74 = blue background color
    The CSS file is provided as downloadable resource for applying essential styles. You can download and use it.


 */
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();

app.MapControllers();

app.Run();
