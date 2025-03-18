using Storefront.Api.Contracts;

namespace Storefront.Services
{
    public interface IProductService
    {
        ProductResponseContract? GetById(int id);
        void Delete(int id);
        List<ProductResponseContract> GetAll();
        ProductResponseContract Create(ProductRequestContract request);
        void Update(int id, ProductRequestContract contract);
    }
}
