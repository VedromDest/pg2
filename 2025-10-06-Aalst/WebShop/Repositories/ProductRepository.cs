namespace WebShop.Repositories;

using WebShop.Contracts;

public class ProductRepository
{
    private readonly Dictionary<Guid, ProductResponseContract> _products = new();

    public IEnumerable<ProductResponseContract> GetAll()
    {
        return _products.Values;
    }

    public ProductResponseContract? Get(Guid id)
    {
        return _products.GetValueOrDefault(id);
    }

    public void Delete(Guid id)
    {
        _products.Remove(id);
    }

    public ProductResponseContract Create(ProductRequestContract product)
    {
        var newProduct = product.Map();
        newProduct.Id = Guid.NewGuid();
        
        _products.Add(newProduct.Id, newProduct);

        return _products[newProduct.Id];
    }

    public void Update(ProductRequestContract product, Guid id)
    {
        var updatedProduct = product.Map();
        updatedProduct.Id = id;
        
        _products[id] = updatedProduct;
    }
}