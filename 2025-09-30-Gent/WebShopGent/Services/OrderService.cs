using WebShopGent.Contracts;
using WebShopGent.Repositories;

namespace WebShopGent.Services;

public interface IOrderService
{
    void CreateOrder(OrderRequestContract orderRequestContract);
}

public class OrderService(ICustomerRepository customers, IProductRepository products, IOrderRepository orders) : IOrderService
{
    public void CreateOrder(OrderRequestContract orderRequestContract)
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
    }
}