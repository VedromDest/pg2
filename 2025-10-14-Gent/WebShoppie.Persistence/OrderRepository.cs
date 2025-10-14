using WebShopGent.Contracts;

namespace WebShoppie.Persistence;
//TODO move interfaces to separate "Interfaces" folder
//TODO dit moet werken met Entity klassen en dbcontext
//TODO let bij return of properties van reference types ingevuld zijn. (TIP Include(), ThenInclude() )

public interface IOrderRepository
{
    public OrderResponseContract SaveOrder(OrderResponseContract orderResponseContract);
    public OrderResponseContract? GetOrder(Guid id);
    public List<OrderResponseContract> GetAllOrders();

}

public class OrderRepository : IOrderRepository
{
    private readonly Dictionary<Guid, OrderResponseContract> _orders = new();
    
    public OrderResponseContract SaveOrder(OrderResponseContract orderResponseContract)
    {
        _orders[orderResponseContract.OrderId] = orderResponseContract;
        return _orders[orderResponseContract.OrderId];
    }
    
    public OrderResponseContract? GetOrder(Guid id)
    {
        return _orders.GetValueOrDefault(id);
    }

    public List<OrderResponseContract> GetAllOrders()
    {
        return _orders.Values.ToList();
    }
}