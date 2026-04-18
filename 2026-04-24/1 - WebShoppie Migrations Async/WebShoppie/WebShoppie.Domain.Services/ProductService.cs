using WebShoppie.Api.Contracts.Products;
using WebShoppie.Domain.Services.Interfaces;
using WebShoppie.Domain.Services.Mapping;
using WebShoppie.Persistence.Interfaces;

namespace WebShoppie.Domain.Services;

public class ProductService(IProductRepository productRepository) : IProductService
{
    public async Task<ProductResponseContract> CreateProductAsync(ProductRequestContract productToCreate)
    {
        var model = productToCreate.AsModel();
        var created = await productRepository.CreateProductAsync(model);
        var contract = created.AsContract();
        return contract;
    }

    public async Task<ProductResponseContract?> GetProductByIdAsync(int id)
    {
        return (await productRepository.GetProductByIdAsync(id))?.AsContract();
    }

    public async Task<IEnumerable<ProductResponseContract>> GetAllProductsAsync()
    {
        return (await productRepository.GetAllProductsAsync()).Select(c => c.AsContract());
    }

    public async Task UpdateProductAsync(int productId, ProductRequestContract productToUpdate)
    {
        var model = productToUpdate.AsModel(productId);
        await productRepository.UpdateProductAsync(model);
    }

    public async Task DeleteProductAsync(int id)
    {
        await productRepository.DeleteProductAsync(id);
    }
}