using WebShop.Contracts;
using WebShop.Repositories;

namespace WebShop.Services;

public interface IOrderService
{
    OrderResponseContract CreateSingleOrder(OrderRequestContract orderToCreate);
}

public class OrderService(CustomerRepository customers, ProductRepository products, OrderRepository orders): IOrderService
{
    public OrderResponseContract CreateSingleOrder(OrderRequestContract orderToCreate)
    {
        // create order object
        var newOrder = new OrderResponseContract()
        {
            Id = Guid.NewGuid(),
            CreatedOnUtc = DateTime.UtcNow,
            Customer = new OrderCustomerResponseContract()
            {
                Id = orderToCreate.CustomerId,
                Country = customers.Read(orderToCreate.CustomerId)
                    .Country //TODO denken over wat te doen wanneer klant niet bestaaat
            },
            Products = orderToCreate.Products.Select(p => new OrderProductResponseContract
            {
                Price = products.Get(p.ProductId).Price, //TODO wat als product niet bestaat
                ProductId = p.ProductId,
                Quantity = p.Quantity
            }).ToList()
        };

        // save order object
        var created = orders.Add(newOrder);

        return created;
    }
}