using OrdersWebApi.CustomAttributes;
using OrdersWebApi.Models;
using System.ComponentModel.DataAnnotations;

namespace OrdersWebApi.DTOs;

public class CreateOrderRequest
{
    [Required]
    [MaxLength(50)]
    public string? CustomerName { get; set; }

    [Required]
    [CheckMinCount(1)]
    public ICollection<OrderItem>? Items { get; set; }
}
