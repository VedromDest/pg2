using WebShoppie.Api.Contracts;
using WebShoppie.Domain.Services.Interfaces;
using WebShoppie.Domain.Services.Mapping;
using WebShoppie.Persistence.Entities;
using WebShoppie.Persistence.Interfaces;

namespace WebShoppie.Domain.Services
{
    public class ProductService(IProductRepository repository) : IProductService
    {
        public ProductResponseContract CreateProduct(ProductRequestContract product)
        {
            var productModel = product.AsModel();

            var productEntity = productModel.AsEntity();
            var createdEntity = repository.CreateProduct(productEntity);

            return createdEntity.AsModel().AsContract();
        }

        public void DeleteProduct(int id)
        {
            repository.DeleteProduct(id);
        }

        public IEnumerable<ProductResponseContract> GetAllProducts()
        {
            return repository.GetAllProducts().Select(c => c.AsModel().AsContract());
        }

        public ProductResponseContract? GetProduct(int id)
        {
            var productEntity = repository.GetProduct(id);

            if (productEntity == null)
                return null;

            var productModel = productEntity.AsModel();
            // Verdere logica zouden we hier op het domeinmodel uitvoeren
            // Indien dat niet nodig is, kunnen we de mapping chainen zoals in
            // de ander methodes.

            return productModel.AsContract();
        }

        public ProductResponseContract UpdateProduct(ProductRequestContract product, int id)
        {
            var productModel = product.AsModel();
            productModel.Id = id;

            var updatedEntity = repository.UpdateProduct(productModel.AsEntity());

            return updatedEntity.AsModel().AsContract();
        }
    }
}
