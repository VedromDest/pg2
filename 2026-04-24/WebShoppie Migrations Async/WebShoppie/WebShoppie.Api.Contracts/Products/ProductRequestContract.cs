using WebShoppie.Api.Contracts.CustomValidationAttributes;

namespace WebShoppie.Api.Contracts.Products;

public class ProductRequestContract
{
    public required string Title { get; set; }

    public required string Description { get; set; }
    
    [DecimalPrecision(2)]
    public required decimal Price { get; set; }

    public required int StockCount { get; set; }
}