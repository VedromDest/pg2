using WebShoppie.Api.Contracts;
using WebShoppie.Domain.Model;
using WebShoppie.Domain.Services.Interfaces;
using WebShoppie.Persistence;
using WebShoppie.Persistence.Entities;

namespace WebShoppie.Domain.Services
{
    public class CustomerService(ICustomerRepository repository) : ICustomerService
    {
        public CustomerResponseContract CreateCustomer(CustomerRequestContract customer)
        {
            /* Met domeinlogica */
            // request contract mappen naar domeinmodel
            // logica op domeinmodel uitvoeren (business stuff)
            // domeinmodel mappen naar entity
            // repository entity laten bewaren
            // entity die gemaakt is mappen naar domeinmodel
            // domeinmodel mappen naar response contract

            /* Zonder extra domeinlogica */
            var customerEntity = new Customer { 
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email
            };

            var createdEntity = repository.SaveCustomer(customerEntity);

            return createdEntity.AsContract();
        }

        public void DeleteCustomer(int id)
        {
            repository.Delete(id);
        }

        public IEnumerable<CustomerResponseContract> GetAllCustomers()
        {
            throw new NotImplementedException();
        }

        public CustomerResponseContract? GetCustomer(int id)
        {
            var customerEntity = repository.GetCustomer(id);

            if (customerEntity == null)
                return null;

            var customerModel = new CustomerModel()
            {
                Email = customerEntity.Email,
                FirstName = customerEntity.FirstName,
                LastName = customerEntity.LastName,
                Id = customerEntity.Id
            };

            // Stel u voor hier zit 345 lijnen business logica achter
            var fullContactInfo = customerModel.GetFullContactInfo();

            return new CustomerResponseContract
            {
                Id = customerEntity.Id,
                LastName = customerEntity.LastName,
                FirstName = customerEntity.FirstName,
                Email = customerEntity.Email,
                FullContactInfo = fullContactInfo
            };

        }

        public CustomerResponseContract UpdateCustomer(CustomerRequestContract customer, int id)
        {
            throw new NotImplementedException();
        }
    }
}
