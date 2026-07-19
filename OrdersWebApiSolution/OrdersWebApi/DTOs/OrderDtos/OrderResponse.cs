using OrdersWebApi.Models;

namespace OrdersWebApi.DTOs.OrderDto;

public class OrderResponse
{
    public Guid OrderId { get; set; }
    public string? OrderNumber { get; set; }
    public string? CustomerName { get; set; }
    public DateTime? OrderDate { get; set; }
    public decimal? TotalAmount { get; set; }

    public static OrderResponse CreateFromOrder(Order order)
    {
        return new OrderResponse
        {
            OrderId = order.OrderId,
            OrderNumber = order.OrderNumber,
            CustomerName = order.CustomerName,
            OrderDate = order.OrderDate,
            TotalAmount = order.TotalAmount,
        };
    }
}
