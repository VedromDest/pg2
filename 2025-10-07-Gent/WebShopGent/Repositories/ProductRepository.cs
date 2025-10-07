namespace WebShopGent.Repositories;

using WebShopGent.Contracts;

// Variant met externe mapping (extensions) en interne Id logica.
// Dit is niet inherent beter of slechter, gewoon een alternatief.
// In de praktijk kies je voor een uniforme aanpak per solution.

public interface IProductRepository
{
    IEnumerable<ProductResponseContract> GetAll();
    ProductResponseContract? Get(Guid id);
    void Delete(Guid id);
    ProductResponseContract Create(ProductRequestContract product);
    void Update(ProductRequestContract product, Guid id);

}

public class ProductRepository : IProductRepository
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