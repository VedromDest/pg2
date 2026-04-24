using WebShoppie.DataModel.Entities;
using WebShoppie.Domain.Model;

namespace WebShoppie.Persistence.Mapping;

public static class OrderMappingExtensions
{
    public static Order AsEntity(this OrderModel model)
    {
        return new Order
        {
            OrderId = model.OrderId ?? 0,
            OrderDate = model.OrderDate.ToUniversalTime(),
            CustomerId = model.CustomerId,
            TotalPrice = model.TotalPrice ?? 0,
            OrderProducts = model.OrderProducts?.Select(op => op.AsEntity()).ToList() ?? new List<Orderproduct>()
        };
    }
    
    public static OrderModel AsModel(this Order entity)
    {
        return new OrderModel
        {
            OrderId = (int)entity.OrderId,
            OrderDate = entity.OrderDate,
            CustomerId = (int)entity.CustomerId,
            Customer = entity.Customer?.AsModel(),
            OrderProducts = entity.OrderProducts.Select(op => op.AsModel()).ToList()
        };
    }
}