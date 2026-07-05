using Assignment12_eCommerceOrderApp.Models;
using System.ComponentModel.DataAnnotations;

namespace Assignment12_eCommerceOrderApp.CustomAttributes;

public class CheckNumberOfProductsAttribute : ValidationAttribute
{
    private readonly int _min;

    public CheckNumberOfProductsAttribute(int min)
    {
        _min = min;
    }
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return new ValidationResult("list of products can not be null");
        }

        if (value is List<Product> products)
        {
            if (products.Count >= _min)
            {

                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult($"min number of product is {_min}");
            }
        }
        return new ValidationResult($"Invalid object type");
    }
}
