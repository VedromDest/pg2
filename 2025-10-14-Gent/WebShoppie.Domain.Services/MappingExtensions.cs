using WebShoppie.Api.Contracts;
using WebShoppie.Persistence.Entities;

namespace WebShoppie.Domain.Services
{
    internal static class MappingExtensions
    {
        public static CustomerResponseContract AsContract(this Customer entity)
        {
            return new CustomerResponseContract
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Email = entity.Email
            };
        }
    }
}
