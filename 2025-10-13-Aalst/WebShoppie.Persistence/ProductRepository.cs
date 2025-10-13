namespace WebShop.Repositories;

using WebShoppie.Persistence;

public class ProductRepository(WebshopaalstContext dbContext)
{
    public IEnumerable<Product> GetAll()
    {
        return dbContext.Products;
    }

    public Product? Get(int id)
    {
        return dbContext.Products.Find(id);
    }

    public void Delete(int id)
    {
        var existing = dbContext.Products.Find(id);

        if (existing != null)
        {
            dbContext.Products.Remove(existing);
            dbContext.SaveChanges();
        }
    }

    public Product Create(Product product)
    {
        dbContext.Products.Add(product);
        dbContext.SaveChanges();
        return product;
    }

    public void Update(Product product)
    {
        var existing = dbContext.Products.Find(product.Id);
        
        if(existing != null)
            dbContext.Products.Update(product);
    }
}