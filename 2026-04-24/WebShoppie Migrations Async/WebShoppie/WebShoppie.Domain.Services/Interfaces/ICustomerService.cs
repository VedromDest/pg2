using WebShoppie.Api.Contracts.Customers;

namespace WebShoppie.Domain.Services.Interfaces;

public interface ICustomerService
{
    Task<CustomerResponseContract> CreateCustomerAsync(CustomerRequestContract customerToCreate);
    Task<CustomerResponseContract?> GetCustomerByIdAsync(int id);
    Task<List<CustomerResponseContract>> GetAllAsync();
    Task<bool> UpdateAsync(int id, CustomerRequestContract customerToUpdate);
    Task DeleteAsync(int id);
}