using WebShop.Contracts;
using WebShop.Factories;

namespace WebShop.Repositories;

public class CustomerRepository
{
    private readonly Dictionary<Guid, CustomerResponseContract> _customerResponseContracts = new();

    public Guid Add(CustomerRequestContract customerToAdd)
    {
        var newCustomer = CustomerRequestToResponseFactory.ConvertTo(customerToAdd);
        _customerResponseContracts.Add(newCustomer.Id, newCustomer);
        return newCustomer.Id;
    }

    public CustomerResponseContract? Read(Guid customerId)
    {
        return _customerResponseContracts.GetValueOrDefault(customerId);
    }

    public IEnumerable<CustomerResponseContract> ReadAll()
    {
        return _customerResponseContracts.Values;
    }

    public CustomerResponseContract Update(CustomerRequestContract customerToUpdate, Guid id)
    {
        var updatedCustomer = CustomerRequestToResponseFactory.ConvertTo(customerToUpdate, id);
        _customerResponseContracts[id] = updatedCustomer;

        return updatedCustomer;
    }

    public void Delete(Guid id)
    {
        _customerResponseContracts.Remove(id);
    }
}