namespace Storefront.Api.Contracts;

public class ProductResponseContract
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public double Price { get; set; }
    public int AgeRating { get; set; }
    public int StockCount { get; set; }
}