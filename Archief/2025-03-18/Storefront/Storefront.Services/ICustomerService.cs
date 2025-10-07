using Storefront.Api.Contracts;

namespace Storefront.Services;

public interface ICustomerService
{
    CustomerResponseContract? GetById(int id);
    void Delete(int id);
    List<CustomerResponseContract> GetAll();
    CustomerResponseContract Create(CustomerRequestContract request);
    void Update(int id, CustomerRequestContract contract);
}