namespace WebShoppie.Persistence.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();
        Product? GetProduct(int id);
        IEnumerable<Product> GetProducts(IEnumerable<int> ids);
        void DeleteProduct(int id);
        Product CreateProduct(Product product);
        Product UpdateProduct(Product product);
    }
}
