using WebShopGent.Contracts;

namespace WebShopGent.Repositories;

public class CustomerRepository
{
    private readonly Dictionary<Guid, CustomerResponseContract> _customers = new();
    
    public CustomerResponseContract SaveCustomer(CustomerRequestContract customerRequestContract)
    {
        var newCustomer = new CustomerResponseContract()
        {
            Id = Guid.NewGuid(),
            FirstName = customerRequestContract.FirstName,
            LastName = customerRequestContract.LastName,
            Email = customerRequestContract.Email
        };
        
        _customers.Add(newCustomer.Id, newCustomer);

        return newCustomer;
    }

    public CustomerResponseContract GetCustomer(Guid id)
    {
        return _customers[id];
    }
}