namespace WebShoppie.Persistence.Interfaces
{
    public interface ICustomerRepository
    {
        int Add(Customer customerToAdd);
        Customer? Read(int customerId);
        IEnumerable<Customer> ReadAll();
        Customer Update(Customer customerToUpdate);
        void Delete(int id);
    }
}
