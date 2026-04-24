using WebShoppie.Domain.Model;

namespace WebShoppie.Persistence.Interfaces;

public interface IProductRepository
{
    Task<ProductModel> CreateProductAsync(ProductModel productModelToCreate);
    Task<ProductModel?> GetProductByIdAsync(int id);
    Task<List<ProductModel>> GetProductsByIdsAsync(int[] ids);
    Task<IEnumerable<ProductModel>> GetAllProductsAsync();
    Task UpdateProductAsync(ProductModel productModelToUpdate);
    Task DeleteProductAsync(int id);
}