using Storefront.Api.Contracts;
using Storefront.Persistence;

namespace Storefront.Services;

public class CustomerService(StorefrontContext storefrontContext) : ICustomerService
{
    public CustomerResponseContract? GetById(int id)
    {
        var entity = storefrontContext.Customers.Find(id);
        return entity is null ? null : MapToContract(entity);
    }

    public void Delete(int id)
    {
        var entity = storefrontContext.Customers.Find(id);
        if (entity is null) return;
        storefrontContext.Customers.Remove(entity);
        storefrontContext.SaveChanges();
    }

    public List<CustomerResponseContract> GetAll()
    {
        return storefrontContext.Customers.Select(c => MapToContract(c)).ToList();
    }

    public CustomerResponseContract Create(CustomerRequestContract request)
    {
        var entity = new Customer()
        {
            Country = request.Country,
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName,
            DateOfBirth = request.DateOfBirth,
            TaxIdentificationNumber = request.TaxIdentificationNumber,
            AddressLine1 = request.Addressline1,
            AddressLine2 = request.Addressline2,
            AddressLine3 = request.Addressline3
        };

        storefrontContext.Customers.Add(entity);
        storefrontContext.SaveChanges();

        return MapToContract(entity);
    }

    public void Update(int id, CustomerRequestContract contract)
    {
        var entity = storefrontContext.Customers.Find(id);

        if (entity is null)
            throw new Exception("Customer bestaat niet.");

        entity.FirstName = contract.FirstName;
        //...

        storefrontContext.Customers.Update(entity);
        storefrontContext.SaveChanges();
    }

    private static CustomerResponseContract MapToContract(Customer entity)
    {
        return new CustomerResponseContract()
        {
            Id = entity.Id,
            Addressline1 = entity.AddressLine1,
            Addressline2 = entity.AddressLine2,
            Addressline3 = entity.AddressLine3,
            Country = entity.Country,
            Email = entity.Email,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            DateOfBirth = entity.DateOfBirth,
            TaxIdentificationNumber = entity.TaxIdentificationNumber
        };
    }
}