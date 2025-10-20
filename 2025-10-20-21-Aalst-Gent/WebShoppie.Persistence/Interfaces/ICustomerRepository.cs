using WebShoppie.Persistence.Entities;

namespace WebShoppie.Persistence.Interfaces
{
    public interface ICustomerRepository
    {
        Customer CreateCustomer(Customer customer);
        Customer? GetCustomer(int id);
        IEnumerable<Customer> GetAllCustomers();
        Customer UpdateCustomer(Customer customer);
        void Delete(int id);
    }
}
