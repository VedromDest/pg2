using WebShoppie.DataModel.Entities;
using WebShoppie.Domain.Model;

namespace WebShoppie.Persistence.Mapping;

public static class OrderProductMappingExtensions
{
    public static Orderproduct AsEntity(this OrderProductModel model)
    {
        return new Orderproduct
        {
            OrderProductId = model.OrderProductId ?? 0,
            OrderId = model.OrderId ?? 0,
            Productid = model.ProductId,
            Quantity = model.Quantity,
            Price = model.Price
        };
    }
    
    public static OrderProductModel AsModel(this Orderproduct entity)
    {
        return new OrderProductModel
        {
            OrderProductId = (int)entity.OrderProductId,
            OrderId = (int)entity.OrderId,
            ProductId = (int)entity.Productid,
            Quantity = entity.Quantity,
            Price = entity.Price,
            Product = entity.Product?.AsModel()
        };
    }
}