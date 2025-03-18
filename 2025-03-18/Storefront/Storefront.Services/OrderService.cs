using Microsoft.EntityFrameworkCore;
using Storefront.Api.Contracts;
using Storefront.Persistence;

namespace Storefront.Services;

public class OrderService(StorefrontContext storefrontContext) : IOrderService
{
    public List<OrderResponseContract> GetAll()
    {
        var entities = storefrontContext.Orders
            .Include(o => o.Customer)
            .Include(o => o.OrderProducts);

        return entities.Select(e => MapToContract(e)).ToList();
    }

    public OrderResponseContract? Get(int id)
    {
        var entity = storefrontContext.Orders
            .Include(o => o.Customer)
            .Include(o => o.OrderProducts)
            .SingleOrDefault(o => o.Id == id);

        return entity is null ? null : MapToContract(entity);
    }

    public OrderResponseContract Create(OrderRequestContract order)
    {
        // Alle product entities laden die (door id) verwezen worden in order ^.
        // Op deze manier moeten we straks niet voor elke entity apart naar de database.
        var products = storefrontContext.Products
            .Where(p => order.Products.Select(op => op.Id).Contains(p.Id));
        
        var orderEntity = new Order
        {
            CustomerId = order.CustomerId,
            OrderProducts = order.Products.Select(op =>
            {
                var relevantProduct = products.Single(p => p.Id == op.Id);
                return new OrderProduct()
                {
                    ProductId = op.Id,
                    Quantity = op.Quantity,
                    Name = relevantProduct.Name,
                    Price = relevantProduct.Price
                };
            }).ToList()
        };

        storefrontContext.Orders.Add(orderEntity);
        storefrontContext.SaveChanges();

        // snelste manier om entity incl alle joins te laden
        return Get(orderEntity.Id) ?? throw new Exception("Order creation failed");
    }

    private static OrderResponseContract MapToContract(Order entity)
    {
        return new OrderResponseContract()
        {
            Id = entity.Id,
            Customer = new OrderCustomerResponseContract()
            {
                FirstName = entity.Customer.FirstName,
                Email = entity.Customer.Email,
                Country = entity.Customer.Country,
                Id = entity.Customer.Id
            },
            Products = entity.OrderProducts.Select(op => 
                new OrderProductResponseContract()
                {
                    Id = op.ProductId,
                    NaamAtOrder = op.Name,
                    PriceAtOrder = (double)op.Price,
                    Quantity = op.Quantity
                }
            ).ToList()
        };        
    }
}











