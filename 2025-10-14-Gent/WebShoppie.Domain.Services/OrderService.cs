using WebShopGent.Contracts;
using WebShopGent.Repositories;

namespace WebShoppie.Domain.Services;

//TODO Klasse laten compileren - build action staat momenteel op 'None'
//TODO Klasse moet steunen op een enkel OrderRepo

public interface IOrderService
{
    OrderResponseContract CreateOrder(OrderRequestContract orderRequestContract);
    OrderResponseContract? GetOrder(Guid id);
    List<OrderOverviewResponseContract> GetAllOrders();
}

public class OrderService(ICustomerRepository customers, IProductRepository products, IOrderRepository orders) : IOrderService
{
    public OrderResponseContract CreateOrder(OrderRequestContract orderRequestContract)
    {
        var relatedCustomer = customers.GetCustomer(orderRequestContract.CustomerId) ??
                              throw new ArgumentException(nameof(orderRequestContract.CustomerId));
        
        var newOrder = new OrderResponseContract()
        {
            OrderId = Guid.NewGuid(),
            OrderDateUtc = DateTime.UtcNow,
            OrderCustomer = new OrderCustomerResponseContract()
            {
                Id = orderRequestContract.CustomerId,
                Email = relatedCustomer.Email,
                Name = relatedCustomer.FirstName + " " + relatedCustomer.LastName,// je weetwel
            },
            OrderProducts = orderRequestContract.Products
                .Select(rp =>
                {
                    var thisProduct = products.Get(rp.ProductId);

                    return new OrderProductResponseContract()
                    {
                        Id = rp.ProductId,
                        PriceAtPurchase = thisProduct.Price,
                        Name = thisProduct.Name,
                        Quantity = rp.Quantity,
                    };
                }).ToList()
        };

        orders.SaveOrder(newOrder);

        return newOrder;
    }

    public OrderResponseContract? GetOrder(Guid id)
    {
        return orders.GetOrder(id);
    }

    public List<OrderOverviewResponseContract> GetAllOrders()
    {
        return orders.GetAllOrders().Select(order => new OrderOverviewResponseContract()
        {
            OrderId = order.OrderId,
            CustomerId = order.OrderCustomer.Id,
            OrderDateTimeUtc = order.OrderDateUtc,
            TotalPrice = order.OrderProducts
                .Select(orderProduct => orderProduct.Quantity * orderProduct.PriceAtPurchase)
                .Sum()
        }).OrderByDescending(overview => overview.OrderDateTimeUtc).ToList();
    }
}