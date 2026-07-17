using System.ComponentModel.DataAnnotations;

namespace StocksApp.UI.ViewModels;

public class StockTradeViewModel
{
    public string? StockSymbol { get; set; }

    public string? StockName { get; set; }

    public double? Price { get; set; }
    public uint? Quantity { get; set; }
}
