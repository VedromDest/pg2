namespace DapperDemo.Repositories.Interfaces;

public interface IOwnerRepository
{
    void Create(Owner owner);
    Owner? GetById(int id);
    Owner GetByIdIncludePets(int id);
    List<Owner> GetAll();
}