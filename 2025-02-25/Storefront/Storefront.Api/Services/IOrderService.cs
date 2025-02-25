using Storefront.Api.Contracts;

namespace Storefront.Api.Services;

public interface IOrderService
{
    List<OrderResponseContract> GetAll();
    OrderResponseContract Get(int id);
    OrderResponseContract Create(OrderRequestContract order);
}