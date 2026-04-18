using System.ComponentModel.DataAnnotations;
using WebShoppie.Api.Contracts.Products;

namespace WebShoppie.Api.Contracts.CustomValidationAttributes;

public class DecimalPrecisionAttribute(int precision) : ValidationAttribute
{
    protected override ValidationResult? IsValid(
        object? value, ValidationContext validationContext)
    {
        var product = (ProductRequestContract)validationContext.ObjectInstance;
            
        return decimal.Round(product.Price,precision) != product.Price ? 
            new ValidationResult($"Decimal precision must not be greater than {precision}.") : ValidationResult.Success;
    }
}