using OrdersWebApi.CustomAttributes;
using OrdersWebApi.DTOs.OrderItemDtos;
using OrdersWebApi.Models;
using System.ComponentModel.DataAnnotations;

namespace OrdersWebApi.DTOs.OrderDtos;

public class CreateOrderRequest
{
    [Required]
    [MaxLength(50)]
    public string? CustomerName { get; set; }

    [Required]
    [CheckMinCount(1)]
    public ICollection<OrderItemAddRequest>? Items { get; set; }
}