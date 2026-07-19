using OrdersWebApi.Models;

namespace OrdersWebApi.DTOs.OrderDto;

public class FullOrderResponse : OrderResponse
{
    public List<OrderItem>? OrderItems { get; set; }

    public static FullOrderResponse CreateFullOrderResponse(Order order, List<OrderItem>? orderItems)
    {
        return new FullOrderResponse
        {
            OrderId = order.OrderId,
            OrderNumber = order.OrderNumber,
            CustomerName = order.CustomerName,
            OrderDate = order.OrderDate,
            TotalAmount = order.TotalAmount,
            OrderItems = orderItems

        };
    }
}