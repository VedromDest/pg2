using WebShoppie.Api.Contracts;

namespace WebShoppie.Domain.Services.Interfaces
{
    public interface IProductService
    {
        ProductResponseContract? GetProduct(int id);
        IEnumerable<ProductResponseContract> GetAllProducts();
        ProductResponseContract CreateProduct(ProductRequestContract product);
        ProductResponseContract UpdateProduct(ProductRequestContract product, int id);
        void DeleteProduct(int id);
    }
}
