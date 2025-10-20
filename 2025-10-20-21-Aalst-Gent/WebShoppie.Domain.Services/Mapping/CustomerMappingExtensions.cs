using WebShoppie.Api.Contracts;
using WebShoppie.Domain.Model;
using WebShoppie.Domain.Services.Exceptions;
using WebShoppie.Persistence.Entities;

namespace WebShoppie.Domain.Services.Mapping
{
    internal static class CustomerMappingExtensions
    {
        public static CustomerModel AsModel(this CustomerRequestContract contract)
        {
            return new CustomerModel
            {
                Email = contract.Email,
                FirstName = contract.FirstName,
                LastName = contract.LastName
            };
        }

        public static CustomerResponseContract AsContract(this CustomerModel model)
        {
            return new CustomerResponseContract
            {
                Id = model.Id ?? throw new MappingException(),
                FirstName = model.FirstName ?? throw new MappingException(),
                LastName = model.LastName ?? throw new MappingException(),
                Email = model.Email ?? throw new MappingException(),
                FullContactInfo = model.GetFullContactInfo()
            };
        }

        public static OrderCustomerResponseContract AsOrderCustomerContract(this CustomerModel model)
        {
            return new OrderCustomerResponseContract
            {
                Id = model.Id ?? throw new MappingException(),
                Email = model.Email ?? throw new MappingException(),
                Name = model.GetFullName()
            };
        }

        public static CustomerModel AsModel(this Customer entity)
        {
            return new CustomerModel
            {
                Email = entity.Email,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Id = entity.Id,
            };
        }

        public static Customer AsEntity(this CustomerModel model)
        {
            return new Customer
            {
                Email = model.Email ?? throw new MappingException(),
                FirstName = model.FirstName ?? throw new MappingException(),
                LastName = model.LastName ?? throw new MappingException(),
                Id = model.Id ?? 0,
            };
        }
    }
}
