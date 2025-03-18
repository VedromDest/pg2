using Storefront.Api.Contracts;

namespace Storefront.Services;

public interface IOrderService
{
    List<OrderResponseContract> GetAll();
    OrderResponseContract? Get(int id);
    OrderResponseContract Create(OrderRequestContract order);
}