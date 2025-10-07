using Storefront.Api.Contracts;

namespace Storefront.Api.Repositories;

public class OrderRepository: IOrderRepository
{
    
    private Dictionary<int, OrderResponseContract> _orders = new();

    public List<OrderResponseContract> GetAll()
    {
        return _orders.Values.ToList();
    }

    public OrderResponseContract Get(int id)
    {
        return _orders[id];
    }

    public OrderResponseContract Create(OrderResponseContract order)
    {
        var newId = _orders.Any() ? _orders.Keys.Max() + 1 : 1;
        order.Id = newId;
        
        _orders.Add(order.Id, order);

        return _orders[order.Id];    
    }
}