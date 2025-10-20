using TreinAbonnementen.Api.Contracts;
using TreinAbonnementen.Persistence;

namespace TreinAbonnementen.Service;

public interface ICustomerService
{
    CustomerResponseContract Create(CustomerRequestContract contract);
    CustomerResponseContract? GetById(int id);
    IEnumerable<CustomerResponseContract> GetAll();
}

public class CustomerService(TrainSubsDbContext context) : ICustomerService
{
    public CustomerResponseContract Create(CustomerRequestContract contract)
    {
        var entity = contract.AsEntity();

        context.Customers.Add(entity);
        context.SaveChanges();

        return entity.AsContract();
    }

    public CustomerResponseContract? GetById(int id)
    {
        return context.Customers.Find(id)?.AsContract();
    }

    public IEnumerable<CustomerResponseContract> GetAll()
    {
        return context.Customers.Select(e => e.AsContract());
    }
}