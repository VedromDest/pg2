using WebShop.Contracts;
using WebShop.Repositories;

namespace WebShop.Services;

public interface ICustomerService
{
    Guid CreateCustomer(CustomerRequestContract requestContract);
    IEnumerable<CustomerResponseContract> GetAll();
    CustomerResponseContract? GetById(Guid id);
    CustomerResponseContract Update(CustomerRequestContract customer, Guid customerId);
    void Delete(Guid id);
}

public class CustomerService(CustomerRepository repository) : ICustomerService
{
    public Guid CreateCustomer(CustomerRequestContract requestContract)
    {
        return repository.Add(requestContract);
    }

    public IEnumerable<CustomerResponseContract> GetAll()
    {
        return repository.ReadAll();
    }

    public CustomerResponseContract? GetById(Guid id)
    {
        return repository.Read(id);
    }

    public CustomerResponseContract Update(CustomerRequestContract customer, Guid customerId) => customer.Country == ECountries.FR
        ? throw new Exception("Dat mag niet van de de business logica hier")
        : repository.Update(customer, customerId);

    public void Delete(Guid id) => repository.Delete(id);
}