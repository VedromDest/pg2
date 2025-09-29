using WebShop.Contracts;

namespace WebShop.Factories;

public static class CustomerRequestToResponseFactory
{
    public static CustomerResponseContract ConvertTo(CustomerRequestContract from, Guid? id = null)
    {
        return new CustomerResponseContract()
        {
            Id = id ?? Guid.NewGuid(),
            FirstName = from.FirstName,
            Email = from.Email,
            Country = from.Country
            //etc...
        };
    }    
}