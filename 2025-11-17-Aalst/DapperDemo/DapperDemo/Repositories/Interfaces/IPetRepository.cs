namespace DapperDemo.Repositories.Interfaces;

public interface IPetRepository
{
    void Create(Pet pet);
    Pet GetById(int id);
    Pet GetByIdIncludeOwner(int id);
    List<Pet> GetAll();
    void Update(Pet pet);
    void Delete(Pet pet);
}