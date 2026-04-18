using WebShoppie.Api.Contracts.Customers;
using WebShoppie.Domain.Model;

namespace WebShoppie.Domain.Services.Mapping;

public static class CustomerMappingExtensions
{
    public static CustomerModel AsModel(this CustomerRequestContract contract, int? id = null)
    {
        return new CustomerModel
        {
            CustomerId = id,
            FirstName = contract.FirstName,
            LastName = contract.LastName,
            DateOfBirth = contract.DateOfBirth,
            Email = contract.Email,
            AddressLine1 = contract.AddressLine1,
            AddressLine2 = contract.AddressLine2,
            AddressLine3 = contract.AddressLine3,
            Country = contract.Country
        };
    }

    public static CustomerResponseContract AsContract(this CustomerModel model)
    {
        if (model.CustomerId is null)
            throw new Exception("Cannot map model to contract without CustomerId");
        
        return new CustomerResponseContract
        {
            CustomerId = model.CustomerId.Value,
            FirstName = model.FirstName,
            LastName = model.LastName,
            DateOfBirth = model.DateOfBirth,
            Email = model.Email,
            AddressLine1 = model.AddressLine1,
            AddressLine2 = model.AddressLine2,
            AddressLine3 = model.AddressLine3,
            Country = model.Country
        };
    }
}