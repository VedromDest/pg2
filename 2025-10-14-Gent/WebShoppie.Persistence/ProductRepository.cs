namespace WebShoppie.Persistence;

using WebShopGent.Contracts;
//TODO move interfaces to separate "Interfaces" folder
//TODO dit moet werken met Entity klassen en dbcontext
//TODO let bij return of properties van reference types ingevuld zijn. (TIP Include(), ThenInclude() )

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