using Storefront.Api.Contracts;

namespace Storefront.Api.Repositories;

public class ProductRepository : IProductRepository
{
    private Dictionary<int, ProductResponseContract> _products = new();

    public List<ProductResponseContract> GetAll()
    {
        return _products.Values.ToList();
    }

    public List<ProductResponseContract> GetMany(List<int> ids)
    {
        return _products
            .Where(kv => ids.Contains(kv.Key))
            .Select(kv => kv.Value)
            .ToList();
    }

    public ProductResponseContract Get(int id)
    {
        return _products[id];
    }

    public void Delete(int id)
    {
        _products.Remove(id);
    }

    public ProductResponseContract Create(ProductRequestContract product)
    {
        var newId = _products.Any() ? _products.Keys.Max() + 1 : 1;

        var newProduct = product.Map();
        newProduct.Id = newId;
        
        _products.Add(newProduct.Id, newProduct);

        return _products[newProduct.Id];
    }

    public void Update(ProductRequestContract product, int id)
    {
        var updatedProduct = product.Map();
        updatedProduct.Id = id;
        
        _products[id] = updatedProduct;
    }
}