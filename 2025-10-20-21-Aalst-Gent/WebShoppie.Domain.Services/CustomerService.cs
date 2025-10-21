using WebShoppie.Api.Contracts;
using WebShoppie.Domain.Services.Interfaces;
using WebShoppie.Domain.Services.Mapping;
using WebShoppie.Persistence.Exceptions;
using WebShoppie.Persistence.Interfaces;

namespace WebShoppie.Domain.Services
{
    public class CustomerService(ICustomerRepository repository) : ICustomerService
    {
        public CustomerResponseContract CreateCustomer(CustomerRequestContract customer)
        {
            var customerModel = customer.AsModel();

            var customerEntity = customerModel.AsEntity();
            var createdEntity = repository.CreateCustomer(customerEntity);

            return createdEntity.AsModel().AsContract();
        }

        public void DeleteCustomer(int id)
        {
            repository.Delete(id);
        }

        public IEnumerable<CustomerResponseContract> GetAllCustomers()
        {
            return repository.GetAllCustomers().Select(c => c.AsModel().AsContract());
        }

        public CustomerResponseContract? GetCustomer(int id)
        {
            var customerEntity = repository.GetCustomer(id);

            if (customerEntity == null)
                return null;

            var customerModel = customerEntity.AsModel();
            // Verdere logica zouden we hier op het domeinmodel uitvoeren
            // Indien dat niet nodig is, kunnen we de mapping chainen zoals in
            // de ander methodes.

            return customerModel.AsContract();
        }

        public CustomerResponseContract? UpdateCustomer(CustomerRequestContract customer, int id)
        {
            var customerModel = customer.AsModel();
            customerModel.Id = id;

            try
            {
                var updatedEntity = repository.UpdateCustomer(customerModel.AsEntity());
                return updatedEntity.AsModel().AsContract();
            }
            catch (EntityNotFoundException cne)
            {
                return null;
            }

        }
    }
}
