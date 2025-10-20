using WebShoppie.Domain.Model;
using WebShoppie.Domain.Services.Exceptions;
using WebShoppie.Persistence.Entities;

namespace WebShoppie.Domain.Services.Mapping
{
    public static class OrderProductMappingExtensions
    {
        public static OrderProduct AsEntity(this OrderProductModel model)
        {
            return new OrderProduct
            {
                ProductId = model.ProductModel.Id ?? 0,
                Quantity = model.Quantity,
                Name = model.ProductModel.Name ?? throw new MappingException(),
                Price = model.ProductModel.Price
            };
        }

        public static OrderProductModel AsModel(this OrderProduct entity)
        {
            return new OrderProductModel
            {
                ProductModel = new ProductModel 
                { 
                    Price = entity.Price,
                    Id = entity.ProductId,
                    Name = entity.Name,
                    Description = entity.Product.Description,
                    StockCount = entity.Product.StockCount,                 
                },
                Quantity = entity.Quantity,
            };
        }
    }
}
