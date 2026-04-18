using WebShoppie.Domain.Model;

namespace WebShoppie.Persistence.Interfaces;

public interface ICustomerRepository
{
    Task<CustomerModel> CreateCustomerAsync(CustomerModel customerModelToCreate);
    Task<CustomerModel?> GetCustomerByIdAsync(int id);
    Task<List<CustomerModel>> GetAllCustomersAsync();
    Task UpdateCustomerAsync(CustomerModel customerModelToUpdate);
    Task DeleteCustomerAsync(int id);
}