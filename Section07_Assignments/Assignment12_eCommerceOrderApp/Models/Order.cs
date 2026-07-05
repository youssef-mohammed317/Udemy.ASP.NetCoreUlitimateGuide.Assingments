using Assignment12_eCommerceOrderApp.CustomAttributes;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Assignment12_eCommerceOrderApp.Models;

public class Order
{

    [Required(ErrorMessage = "order no can't be blank")]
    [CheckDate]
    public DateTime? OrderDate { get; set; }
    [CheckInvoicePrice]
    [Required(ErrorMessage = "invoice price is required")]
    public double? InvoicePrice { get; set; }
    [Required(ErrorMessage = "products is required")]
    [CheckNumberOfProducts(1)]

    public List<Product>? Products { get; set; } = null;

    [ValidateNever]
    public int? OrderNo { get; set; }

}
