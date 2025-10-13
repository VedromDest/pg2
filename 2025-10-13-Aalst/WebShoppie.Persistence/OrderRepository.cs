using WebShoppie.Persistence;

namespace WebShop.Repositories;

public class OrderRepository(WebshopaalstContext dbContext)
{
    public Order Add(Order orderToAdd)
    {
        dbContext.Orders.Add(orderToAdd);
        dbContext.SaveChanges();
        return orderToAdd;
    }

    public Order? Read(int orderId)
    {
        return dbContext.Orders.Find(orderId);
    }

    public IEnumerable<Order> ReadAll()
    {
        return dbContext.Orders;
    }    
}