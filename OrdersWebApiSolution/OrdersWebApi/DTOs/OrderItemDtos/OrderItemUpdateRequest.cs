using System.ComponentModel.DataAnnotations;

namespace OrdersWebApi.DTOs.OrderItemDtos;

public class OrderItemUpdateRequest
{
    [Required]
    public Guid OrderItemId { get; set; }

    [Required]
    [MaxLength(50)]
    public string? ProductName { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Quantity must be a positive number.")]
    public int Quantity { get; set; }

    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "UnitPrice must be a positive number.")]
    public decimal UnitPrice { get; set; }
}