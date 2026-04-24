using WebShoppie.Domain.Model;

namespace WebShoppie.Persistence.Interfaces;

public interface IOrderRepository
{
    Task<OrderModel> CreateOrderAsync(OrderModel orderModelToCreate);
    Task<OrderModel> GetOrderAsync(int id);
}