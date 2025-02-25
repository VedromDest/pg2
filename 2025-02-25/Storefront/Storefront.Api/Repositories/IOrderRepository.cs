using Storefront.Api.Contracts;

namespace Storefront.Api.Repositories;

public interface IOrderRepository
{
    List<OrderResponseContract> GetAll();
    OrderResponseContract Get(int id);
    OrderResponseContract Create(OrderResponseContract order);
}