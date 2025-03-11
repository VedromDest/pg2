using Storefront.Api.Contracts;
using Storefront.Api.Repositories;

namespace Storefront.Api.Services;

public class OrderService(
    IOrderRepository orderRepository, 
    ICustomerRepository customerRepository,
    IProductRepository productRepository
    ) : IOrderService
{
    public List<OrderResponseContract> GetAll()
    {
        return orderRepository.GetAll();
    }

    public OrderResponseContract Get(int id)
    {
        return orderRepository.Get(id);
    }

    public OrderResponseContract Create(OrderRequestContract order)
    {
        var customer = customerRepository.Get(order.CustomerId);
        var products = productRepository
            .GetMany(order.Products.Select(product => product.Id).ToList());
        
        var newOrder = new OrderResponseContract()
        {
            Customer = new OrderCustomerResponseContract()
            {
                Id = customer.Id,
                Country = customer.Country,
                Email = customer.Email,
                FirstName = customer.FirstName
            },
            Products = order.Products
                .Select(pr =>
                {
                    var relevantProduct = products.Single(p => p.Id == pr.Id);
                    return new OrderProductResponseContract()
                    {
                        Id = pr.Id,
                        Quantity = pr.Quantity,
                        NaamAtOrder = relevantProduct.Name,
                        PriceAtOrder = relevantProduct.Price,
                    };
                }).ToList()
        };

        var createdOrder = orderRepository.Create(newOrder);

        return createdOrder;
    }
}











