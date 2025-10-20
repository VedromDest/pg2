namespace WebShoppie.Api.Contracts;

public class ProductResponseContract
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required decimal Price { get; set; }
}