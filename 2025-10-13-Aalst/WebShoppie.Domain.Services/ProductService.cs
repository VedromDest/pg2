using WebShop.Contracts;
using WebShop.Repositories;

namespace WebShop.Services;

public interface IProductService
{
    Guid CreateProduct(ProductRequestContract requestContract);
    /*
    IEnumerable<ProductResponseContract> GetAll();
    ProductResponseContract? GetById(Guid id);
    void Update(ProductRequestContract product, Guid productId);
    void Delete(Guid id);
    */
}

public class ProductService(ProductRepository repository) : IProductService
{
    public Guid CreateProduct(ProductRequestContract requestContract)
    {
        return Guid.NewGuid();
    }

    /*
    public IEnumerable<ProductResponseContract> GetAll()
    {
        return repository.GetAll();
    }

    public ProductResponseContract? GetById(Guid id)
    {
        return repository.Get(id);
    }

    public void Update(ProductRequestContract product, Guid productId) => repository.Update(product, productId);

    public void Delete(Guid id) => repository.Delete(id);
    */
}