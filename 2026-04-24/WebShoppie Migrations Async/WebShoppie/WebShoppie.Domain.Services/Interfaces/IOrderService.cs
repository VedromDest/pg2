using WebShoppie.Api.Contracts.Orders;

namespace WebShoppie.Domain.Services.Interfaces;

public interface IOrderService
{
    Task<OrderResponseContract> CreateOrderAsync(OrderRequestContract orderToCreate);
    Task<OrderResponseContract?> GetOrderByIdAsync(int id);
}