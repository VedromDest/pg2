namespace WebShop.Contracts;

public class ProductResponseContract
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int AgeRating { get; set; }
    public int StockCount { get; set; }
}