using System.ComponentModel.DataAnnotations;

namespace OrdersWebApi.Models;

public class Order
{
    public Order()
    {
        OrderNumber = $"ORD-{DateTime.UtcNow.Year}-{Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper()}";
        OrderDate = DateTime.UtcNow;
    }
    public Guid OrderId { get; set; }
    public string? OrderNumber { get; set; }
    public string? CustomerName { get; set; }
    public DateTime? OrderDate { get; set; }
    public decimal? TotalAmount { get; set; }

    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
