using WebShoppie.Api.Contracts.Orders;
using WebShoppie.Domain.Model;

namespace WebShoppie.Domain.Services.Mapping;

public static class OrderMappingExtensions
{
    public static OrderModel AsModel(this OrderRequestContract contract)
    {
        return new OrderModel()
        {
            CustomerId = contract.CustomerId,
            OrderProducts = contract.OrderProducts.Select(op => new OrderProductModel()
            {
                ProductId = op.ProductId,
                Quantity = op.Quantity
            }).ToList()
        };
    }

    public static OrderResponseContract? AsContract(this OrderModel? model)
    {
        if(model is null)
            return null;

        if (model.Customer?.CustomerId is null || model.OrderId is null || model.OrderProducts is null)
            throw new IllegalMappingException();
        
        return new OrderResponseContract()
        {
            OrderId = model.OrderId.Value,
            CustomerId = model.Customer.CustomerId.Value,
            Email = model.Customer.Email,
            OrderDate = model.OrderDate,
            OrderItems = model.OrderProducts.Select(op => new OrderResponseProductContract()
            {
                ProductId = op.Product?.ProductId ?? throw new Exception("Product reference is required."),
                Quantity = op.Quantity,
                Title = op.Product?.Title ?? string.Empty,
                UnitPriceAtPurchase = op.Price
            }).ToList()
        };
    }
}

public class IllegalMappingException : Exception
{
}