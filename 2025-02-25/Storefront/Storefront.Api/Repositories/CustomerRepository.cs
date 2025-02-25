using Storefront.Api.Contracts;

namespace Storefront.Api.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private Dictionary<int, CustomerResponseContract> _customers = new();

    public List<CustomerResponseContract> GetAll()
    {
        return _customers.Values.ToList();
    }

    public CustomerResponseContract Get(int id)
    {
        return _customers[id];
    }

    public void Delete(int id)
    {
        _customers.Remove(id);
    }

    public CustomerResponseContract Create(CustomerRequestContract customer)
    {
        var newId = _customers.Any() ? _customers.Keys.Max() + 1 : 1;

        var newCustomer = customer.Map();
        newCustomer.Id = newId;
        
        _customers.Add(newCustomer.Id, newCustomer);

        return _customers[newCustomer.Id];
    }

    public void Update(CustomerRequestContract customer, int id)
    {
        var updatedCustomer = customer.Map();
        updatedCustomer.Id = id;
        
        _customers[id] = updatedCustomer;
    }
}










