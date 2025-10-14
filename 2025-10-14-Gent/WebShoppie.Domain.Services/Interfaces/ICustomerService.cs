using WebShoppie.Api.Contracts;

namespace WebShoppie.Domain.Services.Interfaces
{
    public interface ICustomerService
    {
        CustomerResponseContract? GetCustomer(int id);
        IEnumerable<CustomerResponseContract> GetAllCustomers();
        CustomerResponseContract CreateCustomer(CustomerRequestContract customer);
        CustomerResponseContract UpdateCustomer(CustomerRequestContract customer, int id);
        void DeleteCustomer(int id);
    }
}
