using System.ComponentModel.DataAnnotations;

namespace Assignment12_eCommerceOrderApp.CustomAttributes;

public class CheckDateAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return new ValidationResult("date can not be null");
        }
        var datetime = Convert.ToDateTime(value);

        if (datetime.AddMinutes(5) < DateTime.Now)
        {
            return new ValidationResult("Invalid date input");
        }

        return ValidationResult.Success;
    }
}
