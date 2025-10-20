using WebShoppie.Persistence.Entities;
using WebShoppie.Persistence.Exceptions;
using WebShoppie.Persistence.Interfaces;

namespace WebShoppie.Persistence;

public class CustomerRepository(ShopGentContext dbContext) : ICustomerRepository
{
    
    public Customer CreateCustomer(Customer customer)
    {
        dbContext.Customers.Add(customer);
        dbContext.SaveChanges();
        return customer;
    }

    public Customer? GetCustomer(int id)
    {
        return dbContext.Customers.Find(id);
    }

    public IEnumerable<Customer> GetAllCustomers()
    {
        return dbContext.Customers;
    }

    public Customer UpdateCustomer(Customer customer)
    {
        var existing = dbContext.Customers.Find(customer.Id);

        if (existing is null)
            throw new CustomerNotFoundException(customer.Id);

        // Dwing af welke velden via deze methode geüpdatet mogen worden.
        existing.Email = customer.Email;
        // etc... of niet, al naargelang.

        dbContext.SaveChanges();

        return existing;
    }

    public void Delete(int id)
    {
        var existing = dbContext.Customers.Find(id);

        if (existing is null)
            throw new CustomerNotFoundException(id, "FAFO");

        dbContext.Customers.Remove(existing);
        dbContext.SaveChanges();
    }
}