using WebShoppie.DataModel.Entities;
using WebShoppie.Domain.Model;

namespace WebShoppie.Persistence.Mapping;

public static class ProductMappingExtensions
{
    public static Product AsEntity(this ProductModel model)
    {
        return new Product
        {
            Productid = model.ProductId ?? 0,
            Title = model.Title,
            Description = model.Description ?? string.Empty,
            Price = model.Price,
            StockCount = model.StockCount
        };
    }
    
    public static ProductModel AsModel(this Product entity)
    {
        return new ProductModel
        {
            ProductId = (int)entity.Productid,
            Title = entity.Title,
            Description = entity.Description,
            Price = entity.Price,
            StockCount = entity.StockCount
        };
    }
}