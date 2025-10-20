using WebShoppie.Persistence.Entities;

namespace WebShoppie.Persistence.Interfaces
{
    public interface IOrderRepository
    {
        Order CreateOrder(Order order);
        Order? GetOrder(int id);
        IEnumerable<Order> GetAllOrders();

    }
}
