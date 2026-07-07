using Assignment24_SocialMediaLinks.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.Configure<SocialMediaLinksOptions>(builder.Configuration.GetSection(nameof(SocialMediaLinksOptions)));

var app = builder.Build();

app.UseStaticFiles();
app.MapControllers();
app.Run();
