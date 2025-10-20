using Microsoft.EntityFrameworkCore;
using WebShoppie.Persistence.Entities;
using WebShoppie.Persistence.Interfaces;

namespace WebShoppie.Persistence;

public class OrderRepository(ShopGentContext dbContext) : IOrderRepository
{

    public Order CreateOrder(Order order)
    {
        dbContext.Orders.Add(order);
        dbContext.SaveChanges();

        return GetOrder(order.Id)!;
    }

    public Order? GetOrder(int id)
    {
        return dbContext.Orders
            .Include(o => o.Customer)
            .Include(o => o.OrderProducts)
            .ThenInclude(op => op.Product)
            .SingleOrDefault(o => o.Id == id);
    }

    public IEnumerable<Order> GetAllOrders()
    {
        return dbContext.Orders
            .Include(o => o.Customer)
            .Include(o => o.OrderProducts)
            .ThenInclude(op => op.Product)
            .OrderByDescending(o => o.CreatedOnUtc);
    }
}