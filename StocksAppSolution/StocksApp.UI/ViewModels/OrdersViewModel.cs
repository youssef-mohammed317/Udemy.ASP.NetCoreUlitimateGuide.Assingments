using StocksApp.BLL.DTOs;

namespace StocksApp.UI.ViewModels;

public class OrdersViewModel
{
    public List<BuyOrderResponse>? BuyOrders { get; set; }

    public List<SellOrderResponse>? SellOrders { get; set; }
}
