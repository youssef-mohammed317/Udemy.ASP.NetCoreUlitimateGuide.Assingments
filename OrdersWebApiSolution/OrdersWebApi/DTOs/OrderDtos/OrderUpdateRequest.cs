using OrdersWebApi.CustomAttributes;
using OrdersWebApi.Models;
using System.ComponentModel.DataAnnotations;

namespace OrdersWebApi.DTOs.OrderDto;

public class OrderUpdateRequest
{
    [Required]
    public Guid OrderId { get; set; }

    [Required]
    [MaxLength(50)]
    public string? CustomerName { get; set; }
}

