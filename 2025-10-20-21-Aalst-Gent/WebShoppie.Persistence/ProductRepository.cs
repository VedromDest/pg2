using WebShoppie.Persistence.Entities;
using WebShoppie.Persistence.Exceptions;
using WebShoppie.Persistence.Interfaces;

namespace WebShoppie.Persistence;

public class ProductRepository(ShopGentContext dbContext) : IProductRepository
{
    public Product CreateProduct(Product product)
    {
        dbContext.Products.Add(product);
        dbContext.SaveChanges();
        return product;
    }

    public void DeleteProduct(int id)
    {
        var existing = dbContext.Products.Find(id);

        if (existing is null)
            throw new ProductNotFoundException(id, "FAFO");

        dbContext.Products.Remove(existing);
        dbContext.SaveChanges();
    }

    public Product? GetProduct(int id)
    {
        return dbContext.Products.Find(id);
    }

    public IEnumerable<Product> GetAllProducts()
    {
        return dbContext.Products;
    }

    public Product UpdateProduct(Product product)
    {
        var existing = dbContext.Products.Find(product.Id);

        if (existing is null)
            throw new ProductNotFoundException(product.Id);

        // Dwing af welke velden via deze methode geüpdatet mogen worden.
        existing.Price = product.Price;
        existing.Description = product.Description;
        // etc... of niet, al naargelang.

        dbContext.SaveChanges();

        return existing;
    }

    public IEnumerable<Product> GetProducts(IEnumerable<int> ids)
    {
        return dbContext.Products.Where(p => ids.Contains(p.Id));
    }
}