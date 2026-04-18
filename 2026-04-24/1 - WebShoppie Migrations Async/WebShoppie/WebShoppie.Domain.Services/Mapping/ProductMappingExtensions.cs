using WebShoppie.Api.Contracts.Products;
using WebShoppie.Domain.Model;

namespace WebShoppie.Domain.Services.Mapping;

public static class ProductMappingExtensions
{
    public static ProductModel AsModel(this ProductRequestContract contract, int? id = null)
    {
        return new ProductModel
        {
            ProductId = id,
            Title = contract.Title,
            Description = contract.Description,
            Price = contract.Price,
            StockCount = contract.StockCount,
        };
    }

    public static ProductResponseContract AsContract(this ProductModel model)
    {
        if (model.ProductId is null)
            throw new Exception("Cannot map model to contract without ProductId");
        
        return new ProductResponseContract
        {
            ProductId = model.ProductId.Value,
            Title = model.Title,
            Description = model.Description ?? string.Empty,
            Price = model.Price,
            StockCount = model.StockCount,
        };
    }
}