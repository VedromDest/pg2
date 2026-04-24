using Microsoft.EntityFrameworkCore;
using WebShoppie.DataModel;
using WebShoppie.Domain.Model;
using WebShoppie.Persistence.Exceptions;
using WebShoppie.Persistence.Interfaces;
using WebShoppie.Persistence.Mapping;

namespace WebShoppie.Persistence.EfCore;

public class EfCoreProductRepository(WebShoppieDbContext dbContext) : IProductRepository
{
    public async Task<ProductModel> CreateProductAsync(ProductModel productModelToCreate)
    {
        var entity = productModelToCreate.AsEntity();
        dbContext.Products.Add(entity);
        await dbContext.SaveChangesAsync();
        return entity.AsModel();
    }

    public async Task<ProductModel?> GetProductByIdAsync(int id)
    {
        var entity = await dbContext.Products.FindAsync((long)id);
        return entity?.AsModel();
    }

    public async Task<List<ProductModel>> GetProductsByIdsAsync(int[] ids)
    {
        return await dbContext.Products.Where(p => ids.Contains((int)p.Productid)).Select(p => p.AsModel()).ToListAsync();
    }

    public async Task<IEnumerable<ProductModel>> GetAllProductsAsync()
    {
        return await dbContext.Products.Select(p => p.AsModel()).ToListAsync();
    }

    public async Task UpdateProductAsync(ProductModel productModelToUpdate)
    {
        var existingEntity = await dbContext.Products.FindAsync((long)productModelToUpdate.ProductId!);
        if (existingEntity is null)
            throw new OmgProductDoesNotExistInDbException($"Product with Id {productModelToUpdate.ProductId} does not exist!");
        
        existingEntity.Title = productModelToUpdate.Title;
        existingEntity.Description = productModelToUpdate.Description ?? string.Empty;
        
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteProductAsync(int id)
    {
        var entity = await dbContext.Products.FindAsync((long)id);
        if (entity != null)
        {
            dbContext.Products.Remove(entity);
            await dbContext.SaveChangesAsync();
        }
    }
}