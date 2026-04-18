using WebShoppie.Api.Contracts.Customers;
using WebShoppie.Domain.Services.Interfaces;
using WebShoppie.Domain.Services.Mapping;
using WebShoppie.Persistence.Exceptions;
using WebShoppie.Persistence.Interfaces;

namespace WebShoppie.Domain.Services;

public class CustomerService(ICustomerRepository customerRepository) : ICustomerService
{
    public async Task<CustomerResponseContract> CreateCustomerAsync(CustomerRequestContract customerToCreate)
    {
        var model = customerToCreate.AsModel();
        var created = await customerRepository.CreateCustomerAsync(model);
        var contract = created.AsContract();
        return contract;
    }

    public async Task<CustomerResponseContract?> GetCustomerByIdAsync(int id)
    {
        return (await customerRepository.GetCustomerByIdAsync(id))?.AsContract();
    }

    public async Task<List<CustomerResponseContract>> GetAllAsync()
    {
        return (await customerRepository.GetAllCustomersAsync())
            .Select(c => c.AsContract())
            .ToList();
    }

    public async Task<bool> UpdateAsync(int id, CustomerRequestContract customerToUpdate)
    {
        var model = customerToUpdate.AsModel(id);
        try
        {
            await customerRepository.UpdateCustomerAsync(model);
            return true;
        }
        catch (OmgCustomerDoesNotExistInDbException)
        {
            return false;
        }
    }

    public async Task DeleteAsync(int id)
    {
        await customerRepository.DeleteCustomerAsync(id);
    }
}