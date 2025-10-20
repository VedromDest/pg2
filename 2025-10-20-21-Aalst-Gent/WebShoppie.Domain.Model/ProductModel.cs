namespace WebShoppie.Domain.Model
{
    public class ProductModel
    {
        public int? Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public required decimal Price { get; set; }

        public int? StockCount { get; set; }
    }
}
