using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;
using StocksApp.BLL.Services.Contracts;
using StocksApp.UI.Controllers;
using StocksApp.UI.CustomOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StocksApp.IntegrationTests.Contollers.Trade;

public class IndexMethod : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public IndexMethod(WebApplicationFactory<Program> factory)
    {
        _client = factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureTestServices(services =>
            {
                var finnhubServiceMock = new Mock<IFinnhubService>();

                // fake data
                var fakeProfile = new Dictionary<string, object> { { "name", "Apple" }, { "ticker", "AAPL" } };
                var fakeQuote = new Dictionary<string, object> { { "c", 150.5 } };

                finnhubServiceMock.Setup(s => s.GetCompanyProfileAsync(It.IsAny<string>())).ReturnsAsync(fakeProfile);
                finnhubServiceMock.Setup(s => s.GetStockPriceQuoteAsync(It.IsAny<string>())).ReturnsAsync(fakeQuote);

                services.AddScoped<IFinnhubService>(_ => finnhubServiceMock.Object);

            });
        }).CreateClient();
    }
    [Fact]
    public async Task Index_GetRequest_ReturnsViewWithHtmlHasClassPrice()
    {
        //Act
        var response = await _client.GetAsync("/Trade/Index");

        //Assert
        response.EnsureSuccessStatusCode();

        var htmlResponse = await response.Content.ReadAsStringAsync();

        htmlResponse.Should().NotBeNullOrEmpty();

        htmlResponse.Should().Contain("price");
    }
}
