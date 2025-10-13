using WebShop.Contracts;
using WebShoppie.Persistence;

namespace WebShoppie.Domain.Services
{
    internal static class MappingExtenions
    {
        public static CustomerResponseContract Map(this Customer customerEntity)
        {
            return new CustomerResponseContract
            {
                Id = customerEntity.Id,
                FirstName = customerEntity.FirstName,
                Country = Enum.Parse<ECountries>(customerEntity.Country),
                Email = customerEntity.Email
            };
        }

        public static Customer Map(this CustomerRequestContract requestContract)
        {
            return new Customer
            {
                Email = requestContract.Email,
                FirstName = requestContract.FirstName,
                LastName = requestContract.LastName,
                Country = requestContract.Country.ToString(),
            };
        }
    }
}
