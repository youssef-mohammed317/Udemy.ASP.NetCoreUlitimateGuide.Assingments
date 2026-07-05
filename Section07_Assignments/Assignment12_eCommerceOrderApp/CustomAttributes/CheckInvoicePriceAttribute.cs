using Assignment12_eCommerceOrderApp.Models;
using System.ComponentModel.DataAnnotations;

namespace Assignment12_eCommerceOrderApp.CustomAttributes;

public class CheckInvoicePriceAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {

        if (value == null)
        {
            return new ValidationResult("price can not be null");
        }

        var order = validationContext.ObjectInstance as Order;

        if (order is null)
            return new ValidationResult("order can not be null");

        double totalPrice = order.Products?.Sum(product => product?.Price.Value ?? 0 * product?.Quantity.Value ?? 0) ?? 0;

        if (totalPrice == (double)value)
        {
            return ValidationResult.Success;
        }
        return new ValidationResult("InvoicePrice doesn't match with the total cost of the specified products in the order.");
    }
}
