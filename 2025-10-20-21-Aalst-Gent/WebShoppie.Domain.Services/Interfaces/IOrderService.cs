using WebShoppie.Api.Contracts;

namespace WebShoppie.Domain.Services.Interfaces
{
    public interface IOrderService
    {
        OrderResponseContract CreateOrder(OrderRequestContract orderRequestContract);
        OrderResponseContract? GetOrder(int id);
        IEnumerable<OrderOverviewResponseContract> GetAllOrders();
    }
}
