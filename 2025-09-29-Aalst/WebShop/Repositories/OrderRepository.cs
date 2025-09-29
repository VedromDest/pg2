using WebShop.Contracts;

namespace WebShop.Repositories;

public class OrderRepository
{
    private readonly Dictionary<Guid, OrderResponseContract> _orderResponseContracts = new();

    public OrderResponseContract Add(OrderResponseContract orderToAdd)
    {
        _orderResponseContracts.Add(orderToAdd.Id, orderToAdd);
        return orderToAdd;
    }

    public OrderResponseContract? Read(Guid orderId)
    {
        return _orderResponseContracts.GetValueOrDefault(orderId);
    }

    public IEnumerable<OrderResponseContract> ReadAll()
    {
        return _orderResponseContracts.Values;
    }    
}