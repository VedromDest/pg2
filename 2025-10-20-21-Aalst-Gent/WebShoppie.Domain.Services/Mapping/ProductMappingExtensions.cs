using WebShoppie.Api.Contracts;
using WebShoppie.Domain.Model;
using WebShoppie.Domain.Services.Exceptions;
using WebShoppie.Persistence;

namespace WebShoppie.Domain.Services.Mapping
{
    internal static class ProductMappingExtensions
    {
        public static ProductModel AsModel(this Product entity)
        {
            return new ProductModel
            {
                Price = entity.Price,
                Description = entity.Description,
                Id = entity.Id,
                Name = entity.Name,
                StockCount = entity.StockCount
            };
        }

        public static ProductModel AsModel(this ProductRequestContract contract)
        {
            return new ProductModel
            {
                Price = contract.Price,
                Description = contract.Description,
                Name = contract.Name                
            };
        }

        public static Product AsEntity(this ProductModel model)
        {
            return new Product
            {
                Price = model.Price,
                Description = model.Description ?? throw new MappingException(),
                Id = model.Id ?? 0,
                Name = model.Name ?? throw new MappingException(),
            };
        }

        public static ProductResponseContract AsContract(this ProductModel model)
        {
            return new ProductResponseContract
            {
                Price = model.Price,
                Description = model.Description ?? throw new MappingException(),
                Name = model.Name ?? throw new MappingException(),
                Id = model.Id ?? throw new InvalidProductException()
            };
        }

        public static OrderProductResponseContract AsOrderProductContract(this OrderProductModel model)
        {
            return new OrderProductResponseContract
            {
                Id = model.ProductModel.Id ?? throw new MappingException(),
                Name = model.ProductModel.Name ?? throw new MappingException(),
                Quantity = model.Quantity,
                PriceAtPurchase = model.ProductModel.Price
            };
        }
    }
}
