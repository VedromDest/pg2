using WebShoppie.Api.Contracts.Orders;
using WebShoppie.Domain.Services.Interfaces;
using WebShoppie.Domain.Services.Mapping;
using WebShoppie.Persistence.Interfaces;

namespace WebShoppie.Domain.Services;

public class OrderService(IOrderRepository orderRepo, IProductRepository productRepo) : IOrderService
{
    // Is it ok to use 2 repo's in one service?
    // Indien niet, roep je andere services aan ipv de repo's.
    // It's a design decision, maak een keuze en probeer consequent te zijn.
    public async Task<OrderResponseContract> CreateOrderAsync(OrderRequestContract orderToCreate)
    {
        var model = orderToCreate.AsModel();
        model.OrderDate = DateTime.Now;

        // Better dan "coded join", but dictionary would improve performance further
        var relevantProducts = await productRepo.GetProductsByIdsAsync(orderToCreate.OrderProducts.Select((op => op.ProductId)).ToArray());
        model.OrderProducts?.ForEach(op => op.Price = relevantProducts.Single(p => p.ProductId == op.ProductId).Price);
        
        var createdOrder = await orderRepo.CreateOrderAsync(model);
        return createdOrder.AsContract() ?? throw new Exception("Failed to create order");
    }

    public async Task<OrderResponseContract?> GetOrderByIdAsync(int id)
    {
        var order = await orderRepo.GetOrderAsync(id);
        return order.AsContract();
    }
}