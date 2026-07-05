using System.ComponentModel.DataAnnotations;

namespace Assignment12_eCommerceOrderApp.Models;

public class Product
{
    [Required(ErrorMessage = "ProductCode is required")]
    public int? ProductCode { get; set; }
    [Required(ErrorMessage = "Price is required")]
    [Range(0, double.MaxValue)]
    public double? Price { get; set; }
    [Required(ErrorMessage = "Quantity is required")]
    [Range(0, int.MaxValue)]
    public int? Quantity { get; set; }
}
