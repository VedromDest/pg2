using WebShop.Contracts;

namespace WebShop.Repositories;

public class CustomerRepository
{
    private readonly Dictionary<Guid, CustomerResponseContract> _customerResponseContracts = new();

    public Guid Add(CustomerRequestContract customerToAdd)
    {
        var newCustomer = new CustomerResponseContract()
        {
            Id = Guid.NewGuid(),
            FirstName = customerToAdd.FirstName,
            Email = customerToAdd.Email,
            Country = customerToAdd.Country
            //etc...
        };
        _customerResponseContracts.Add(newCustomer.Id, newCustomer);
        return newCustomer.Id;
    }

    public CustomerResponseContract Read(Guid customerId)
    {
        return _customerResponseContracts[customerId];
    }
}