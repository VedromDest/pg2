using WebShoppie.Persistence;
using WebShoppie.Persistence.Exceptions;
using WebShoppie.Persistence.Interfaces;

namespace WebShop.Repositories;

public class CustomerRepository(WebshopaalstContext dbContext) : ICustomerRepository
{
    public int Add(Customer customerToAdd)
    {
        dbContext.Customers.Add(customerToAdd);
        dbContext.SaveChanges();
        return customerToAdd.Id;
    }

    public Customer? Read(int customerId)
    {
        return dbContext.Customers.Find(customerId);
    }

    public IEnumerable<Customer> ReadAll()
    {
        return dbContext.Customers;
    }

    public Customer Update(Customer customerToUpdate)
    {
        var existing = dbContext.Customers.Find(customerToUpdate.Id);

        existing.AddressLine1 = customerToUpdate.AddressLine1;

        dbContext.SaveChanges();

        return existing;
    }

    public void Delete(int id)
    {
        var customer = dbContext.Customers.Find(id);

        if (customer != null)
        {
            dbContext.Customers.Remove(customer);
        }

        throw new CustomerNotFoundException();
    }
}