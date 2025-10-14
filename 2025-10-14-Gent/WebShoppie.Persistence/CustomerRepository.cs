using WebShoppie.Persistence.Entities;
using WebShoppie.Persistence.Exceptions;

namespace WebShoppie.Persistence;

//TODO move interfaces to separate "Interfaces" folder
public interface ICustomerRepository
{
    Customer SaveCustomer(Customer customer);
    Customer? GetCustomer(int id);
    List<Customer> GetAllCustomers();
    Customer UpdateCustomer(Customer customer);
    void Delete(int id);
}

public class CustomerRepository(ShopGentContext dbContext) : ICustomerRepository
{
    
    public Customer SaveCustomer(Customer customer)
    {
        dbContext.Customers.Add(customer);
        dbContext.SaveChanges();
        return customer;
    }

    public Customer? GetCustomer(int id)
    {
        return dbContext.Customers.Find(id);
    }

    public List<Customer> GetAllCustomers()
    {
        return dbContext.Customers.ToList();
    }

    public Customer UpdateCustomer(Customer customer)
    {
        var existing = dbContext.Customers.Find(customer.Id);

        if (existing is null)
            throw new CustomerNotFoundException();

        existing.AddressLine1 = customer.AddressLine1;
        existing.AddressLine2 = customer.AddressLine2;
        // Al naargelang...

        dbContext.SaveChanges();

        return existing;
    }

    public void Delete(int id)
    {
        var existing = dbContext.Customers.Find(id);

        if (existing is null)
            throw new CustomerNotFoundException();

        dbContext.Customers.Remove(existing);
        dbContext.SaveChanges();
    }
}