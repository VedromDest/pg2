using WebShop.Contracts;
using WebShoppie.Domain.Services;
using WebShoppie.Persistence;
using WebShoppie.Persistence.Interfaces;

namespace WebShop.Services;

public interface ICustomerService
{
    int CreateCustomer(CustomerRequestContract requestContract);
    IEnumerable<CustomerResponseContract> GetAll();
    CustomerResponseContract? GetById(int id);
    CustomerResponseContract Update(CustomerRequestContract customer, int customerId);
    void Delete(int id);
}

public class CustomerService(ICustomerRepository repository ) : ICustomerService
{
    public int CreateCustomer(CustomerRequestContract requestContract)
    {
        /*** Volledige Versie ***/
        // Map contract to domain object
        // run logic
        // Map domain object to Entity
        // Execute repository call
        // return

        /*** Korte Versie ***/
        var customerToCreate = requestContract.Map();
        var idNewCustomer = repository.Add(customerToCreate);
        return idNewCustomer;
    }

    public IEnumerable<CustomerResponseContract> GetAll()
    {
        return repository.ReadAll().Select(dbc => dbc.Map());
    }

    public CustomerResponseContract? GetById(int id)
    {
        var customerEntity = repository.Read(id);

        return customerEntity.Map();
    }

    public CustomerResponseContract Update(CustomerRequestContract customer, int customerId)
    {
        var customerEntityToUpdate = customer.Map();
        customerEntityToUpdate.Id = customerId;

        return customer.Country == ECountries.FR
        ? throw new Exception("Dat mag niet van de de business logica hier")
        : repository.Update(customerEntityToUpdate).Map();
    }

    public void Delete(int id) => repository.Delete(id);
}