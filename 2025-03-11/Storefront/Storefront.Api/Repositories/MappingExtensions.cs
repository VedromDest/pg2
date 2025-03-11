using Storefront.Api.Contracts;

namespace Storefront.Api.Repositories;

public static class MappingExtensions
{
    public static CustomerResponseContract Map(this CustomerRequestContract customer)
    {
        return new CustomerResponseContract()
        {
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            DateOfBirth = customer.DateOfBirth,
            Email = customer.Email,
            TaxIdentificationNumber = customer.TaxIdentificationNumber,
            Addressline1 = customer.Addressline1,
            Addressline2 = customer.Addressline2,
            Addressline3 = customer.Addressline3,
            Country = customer.Country
        };
    }
    
    public static ProductResponseContract Map(this ProductRequestContract product)
    {
        return new ProductResponseContract()
        {
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            AgeRating = product.AgeRating,
            StockCount = product.StockCount
        };
    }
}