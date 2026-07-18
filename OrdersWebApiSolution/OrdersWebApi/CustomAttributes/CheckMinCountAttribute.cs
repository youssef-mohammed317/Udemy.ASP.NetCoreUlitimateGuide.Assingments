using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace OrdersWebApi.CustomAttributes;

public class CheckMinCountAttribute : ValidationAttribute
{
    private readonly int _minCount;

    public CheckMinCountAttribute(int minCount = 1)
    {
        _minCount = minCount;
    }
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {

        if (value is null)
        {
            return new ValidationResult($"{validationContext.MemberName} can not be blank");
        }

        if (value is ICollection collection)
        {
            if (collection.Count < _minCount)
            {
                var errorMsg = ErrorMessage ?? $"{validationContext.MemberName} must contain at least {_minCount} items.";
                return new ValidationResult(errorMsg);
            }
        }
        return ValidationResult.Success;

    }
}
