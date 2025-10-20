using WebShoppie.Api.Contracts;
using WebShoppie.Domain.Model;
using WebShoppie.Domain.Services.Exceptions;
using WebShoppie.Domain.Services.Interfaces;
using WebShoppie.Domain.Services.Mapping;
using WebShoppie.Persistence.Interfaces;

namespace WebShoppie.Domain.Services;

// Deze service steunt op drie repositories. 
// We zouden ook kunnen steunen op 1 order repository en services voor customer
// en product. Dat is een andere ontwerpkeuze, die zeker niet verkeerd is.
public class OrderService(
    ICustomerRepository customerRepository, 
    IProductRepository productRepository, 
    IOrderRepository orderRepository) : IOrderService
{
    // We steunen sterk op de mappingExtensions, maar merk op dat we alle repo
    // access in de service houden. MappingExtensions zijn niet verbonden met 
    // repo's omdat we niet willen dat schijnbaar goedkope mapping operaties
    // impliciet verborgen dure operaties, zoals database calls, uitvoeren.
    public OrderResponseContract CreateOrder(OrderRequestContract orderRequestContract)
    {
        // Maak nieuwe bestelling
        var orderModel = new OrderModel { CreatedOnUtc = DateTime.UtcNow };

        // Haal relevante klant uit de database & map naar domein & assign
        orderModel.CustomerModel = customerRepository
            .GetCustomer(orderRequestContract.CustomerId)?
            .AsModel() ?? throw new InvalidOrderException("Invalid customerId");

        // Haal relevante producten uit de database & map naar domein & assign
        var dbProducts = productRepository
            .GetProducts(orderRequestContract.Products.Select(p => p.ProductId)).ToList();
        
        if(dbProducts.Count != orderRequestContract.Products.Count())
            throw new InvalidOrderException("Invalid products");

        orderModel.OrderProductModels = orderRequestContract.Products
            .Select(p => new OrderProductModel
            {
                Quantity = p.Quantity,
                ProductModel = dbProducts.SingleOrDefault(dbp => dbp.Id == p.ProductId)
                    ?.AsModel() ?? throw new InvalidOrderException("Invalid productId"),
            }).ToList();

        // Voor domeinlogica uit (indien nodig)
        if (!orderModel.IsValid())
            throw new InvalidOrderException();

        // Map domeinobjecten naar entiteiten en geef aan repo
        var orderToCreateEntity = orderModel.AsEntity();
        var createdOrder = orderRepository.CreateOrder(orderToCreateEntity);

        // Geef aangemaakte order terug als contract
        return createdOrder.AsModel().AsContract();
    }

    public OrderResponseContract? GetOrder(int id)
    {
        return orderRepository.GetOrder(id)?.AsModel().AsContract();
    }

    public IEnumerable<OrderOverviewResponseContract> GetAllOrders()
    {
        return orderRepository.GetAllOrders()
            .Select(order => order.AsModel().AsOverviewContract());
    }
}