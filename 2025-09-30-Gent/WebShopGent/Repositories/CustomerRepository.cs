using WebShopGent.Contracts;

namespace WebShopGent.Repositories;

public interface ICustomerRepository
{
    CustomerResponseContract SaveCustomer(CustomerRequestContract customerRequestContract);
    CustomerResponseContract? GetCustomer(Guid id);
    List<CustomerResponseContract> GetAllCustomers();

    CustomerResponseContract UpdateCustomer(CustomerRequestContract customerRequestContract,
        Guid customerId);

    void Delete(Guid id);
}

public class CustomerRepository : ICustomerRepository
{
    private readonly Dictionary<Guid, CustomerResponseContract> _customers = new();
    
    public CustomerResponseContract SaveCustomer(CustomerRequestContract customerRequestContract)
    {
        var newCustomer = Map(customerRequestContract);
        
        _customers.Add(newCustomer.Id, newCustomer);

        return newCustomer;
    }

    public CustomerResponseContract? GetCustomer(Guid id)
    {
        return _customers.GetValueOrDefault(id);
    }

    public List<CustomerResponseContract> GetAllCustomers()
    {
        return _customers.Values.ToList();
    }

    public CustomerResponseContract UpdateCustomer(
        CustomerRequestContract customerRequestContract,
        Guid customerId)
    {
        var customerToUpdate = Map(customerRequestContract, customerId);
        _customers[customerToUpdate.Id] = customerToUpdate;
        return _customers[customerToUpdate.Id];
    }

    public void Delete(Guid id)
    {
        _customers.Remove(id);
    }

    private CustomerResponseContract Map(CustomerRequestContract customerRequestContract, Guid? id = null)
    {
        return new CustomerResponseContract()
        {
            Id = id ?? Guid.NewGuid(),
            FirstName = customerRequestContract.FirstName,
            LastName = customerRequestContract.LastName,
            Email = customerRequestContract.Email
        };
    }
}