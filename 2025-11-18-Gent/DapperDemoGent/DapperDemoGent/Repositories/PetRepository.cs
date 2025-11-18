using Dapper;
using MySqlConnector;

namespace DapperDemoGent.Repositories;

public interface IPetRepository
{
    Pet GetPetByIdIncludeOwner(int id);
}

public class PetRepository : IPetRepository
{
    private readonly string _connectionString;
    private readonly QueryRepository _queryRepository;
    
    public PetRepository(string connectionString, QueryRepository queryRepository)
    {
        if (string.IsNullOrWhiteSpace(connectionString)) 
            throw new ArgumentNullException(nameof(connectionString));
        _connectionString = connectionString;
        _queryRepository = queryRepository;
    }
    
    public Pet GetPetByIdIncludeOwner(int id)
    {
        var query = _queryRepository.GetPetByIdIncludeOwner;
        using var connection = new MySqlConnection(_connectionString);
        return connection.Query<Pet, Owner, Pet>(
            sql: query,
            param: new {PetId = id},
            splitOn: "OwnerId",
             map: (pet, owner) =>
             {
                 pet.Owner = owner;
                 return pet;
             }
            ).Single();
    }
}