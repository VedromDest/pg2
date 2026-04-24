using WebShoppie.Api.Contracts.Products;

namespace WebShoppie.Domain.Services.Interfaces;

public interface IProductService
{
    Task<ProductResponseContract> CreateProductAsync(ProductRequestContract productToCreate);
    Task<ProductResponseContract?> GetProductByIdAsync(int id);
    Task<IEnumerable<ProductResponseContract>> GetAllProductsAsync();
    Task UpdateProductAsync(int productId, ProductRequestContract productToUpdate);
    Task DeleteProductAsync(int id);
}