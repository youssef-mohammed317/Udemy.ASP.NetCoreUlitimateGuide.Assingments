namespace OrdersWebApi.Models;

public class OrderItem
{
    public Guid OrderItemId { get; set; }
    public string? ProductName { get; set; }
    public int? Quantity { get; set; }
    public decimal? UnitPrice { get; set; }
    public decimal? TotalPrice { get; set; }
    public Guid OrderId { get; set; }
}