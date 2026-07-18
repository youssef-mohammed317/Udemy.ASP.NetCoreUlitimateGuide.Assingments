using OrdersWebApi.CustomAttributes;
using OrdersWebApi.Models;
using System.ComponentModel.DataAnnotations;

namespace OrdersWebApi.DTOs;

public class EditOrderRequest
{
    [Required]
    public Guid OrderId { get; set; }

    [Required]
    [CheckMinCount(1)]
    public ICollection<OrderItem>? Items { get; set; }
}
