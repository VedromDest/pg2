using Microsoft.EntityFrameworkCore;
using WebShoppie.DataModel;
using WebShoppie.Domain.Model;
using WebShoppie.Persistence.Exceptions;
using WebShoppie.Persistence.Interfaces;
using WebShoppie.Persistence.Mapping;

namespace WebShoppie.Persistence.EfCore;

public class EfCoreOrderRepository(WebShoppieDbContext dbContext) : IOrderRepository
{
    public async Task<OrderModel> CreateOrderAsync(OrderModel orderModelToCreate)
    {
        var entity = orderModelToCreate.AsEntity();
        dbContext.Orders.Add(entity);
        await dbContext.SaveChangesAsync();
        return await GetOrderAsync((int)entity.OrderId);
    }

    public async Task<OrderModel> GetOrderAsync(int id)
    {
        var entity = await dbContext.Orders
            .Include(o => o.Customer)
            .Include(o => o.OrderProducts)
            .ThenInclude(op => op.Product)
            .FirstOrDefaultAsync(o => o.OrderId == (long)id);
        return entity == null ? throw new OmgOrderDoesNotExistInDbException($"Order with Id {id} does not exist!") : entity.AsModel();
    }
}