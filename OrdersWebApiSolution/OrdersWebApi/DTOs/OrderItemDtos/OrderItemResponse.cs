using OrdersWebApi.Models;

namespace OrdersWebApi.DTOs.OrderItemDtos;

public class OrderItemResponse
{
    public Guid OrderItemId { get; set; }
    public Guid OrderId { get; set; }
    public string? ProductName { get; set; }
    public int? Quantity { get; set; }
    public decimal? UnitPrice { get; set; }
    public decimal? TotalPrice { get; set; }

    public static OrderItemResponse CreateFromOrderItem(OrderItem item)
    {
        return new OrderItemResponse
        {
            OrderItemId = item.OrderItemId,
            OrderId = item.OrderId,
            ProductName = item.ProductName,
            Quantity = item.Quantity,
            UnitPrice = item.UnitPrice,
            TotalPrice = item.TotalPrice
        };
    }
}