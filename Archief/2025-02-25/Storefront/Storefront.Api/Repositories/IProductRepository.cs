using Storefront.Api.Contracts;

namespace Storefront.Api.Repositories;

public interface IProductRepository
{
    List<ProductResponseContract> GetAll();
    List<ProductResponseContract> GetMany(List<int> ids);
    ProductResponseContract Get(int id);
    void Delete(int id);
    ProductResponseContract Create(ProductRequestContract product);
    void Update(ProductRequestContract product, int id);
}