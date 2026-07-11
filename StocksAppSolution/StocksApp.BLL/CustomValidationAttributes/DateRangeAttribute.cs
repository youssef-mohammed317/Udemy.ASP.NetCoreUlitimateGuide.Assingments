using System;
using System.ComponentModel.DataAnnotations;

namespace StocksApp.BLL.CustomValidationAttributes
{
    public class DateRangeAttribute : ValidationAttribute
    {
        public DateTime? StartDate { get; }
        public DateTime? EndDate { get; }

        public DateRangeAttribute(string? startDate = null, string? endDate = null)
        {
            if (!string.IsNullOrEmpty(startDate))
                StartDate = Convert.ToDateTime(startDate);

            if (!string.IsNullOrEmpty(endDate))
                EndDate = Convert.ToDateTime(endDate);
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
                return null;

            var date = Convert.ToDateTime(value);

            if (StartDate.HasValue && !EndDate.HasValue)
            {
                if (date >= StartDate.Value)
                    return ValidationResult.Success;

                return new ValidationResult($"Should not be older than {StartDate.Value.ToString("MMM dd, yyyy")}");
            }
            else if (!StartDate.HasValue && EndDate.HasValue)
            {
                if (date <= EndDate.Value)
                    return ValidationResult.Success;

                return new ValidationResult($"Date should be less than or equal to {EndDate.Value.ToString("MMM dd, yyyy")}");
            }
            else if (StartDate.HasValue && EndDate.HasValue)
            {
                if (date >= StartDate.Value && date <= EndDate.Value)
                    return ValidationResult.Success;

                return new ValidationResult($"Date should be between {StartDate.Value.ToString("MMM dd, yyyy")} and {EndDate.Value.ToString("MMM dd, yyyy")}");
            }

            return ValidationResult.Success;
        }
    }
}