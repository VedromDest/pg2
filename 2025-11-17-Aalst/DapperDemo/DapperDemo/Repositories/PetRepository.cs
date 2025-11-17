using Dapper;
using DapperDemo.Repositories.Interfaces;
using MySqlConnector;

namespace DapperDemo.Repositories;

public class PetRepository : IPetRepository
{
    const string connectionString = "server=127.0.0.1;port=3307;database=DapperDemoAalst;user=dapperdemo;password=dapperdemo";

    public void Create(Pet pet)
    {
        throw new NotImplementedException();
    }

    public Pet GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Pet GetByIdIncludeOwner(int id)
    {
        const string sql = @"select p.PetId, p.Name, p.DateOfBirth, p.DateOfDeath,
                                    o.OwnerId, o.FirstName, o.LastName, o.Email
                             from DapperDemoAalst.Pets p 
                             inner join DapperDemoAalst.Owners o on p.OwnerId = o.OwnerId
                             where p.PetId = @PetId";
        using var connection = new MySqlConnection(connectionString);
        var result = connection.Query<Pet, Owner, Pet>(
            sql, 
            map: (pet, owner) =>
            {
                pet.Owner = owner;
                return pet;
            },
            param: new {PetId = id}, 
            splitOn: "OwnerId");
        return result.Single();
    }

    public List<Pet> GetAll()
    {
        throw new NotImplementedException();
    }

    public void Update(Pet pet)
    {
        throw new NotImplementedException();
    }

    public void Delete(Pet pet)
    {
        throw new NotImplementedException();
    }
}