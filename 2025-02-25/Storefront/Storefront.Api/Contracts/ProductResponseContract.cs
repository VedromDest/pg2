namespace Storefront.Api.Contracts;

public class ProductResponseContract
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public int AgeRating { get; set; }
    public int StockCount { get; set; }
}