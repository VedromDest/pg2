using WebShopGent.Contracts;

namespace WebShopGent.Repositories;

public interface IOrderRepository
{
    public OrderResponseContract SaveOrder(OrderResponseContract orderToSave);
}

public class OrderRepository : IOrderRepository
{
    private readonly Dictionary<Guid, OrderResponseContract> _orders = new();
    
    public OrderResponseContract SaveOrder(OrderResponseContract orderRequestContract)
    {
        return null;
    }
}