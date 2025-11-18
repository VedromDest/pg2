using Dapper;
using MySqlConnector;

namespace DapperDemoGent.Repositories;

public interface IOwnerRepository
{
    Owner Create(Owner owner);
    Owner? GetById(int id);
    Owner GetByIdIncludePets(int id);
    List<Owner> GetAll();
}

public class OwnerRepository : IOwnerRepository
{
    private readonly string _connectionString;

    public OwnerRepository(string connectionString)
    {
        if (string.IsNullOrWhiteSpace(connectionString)) 
            throw new ArgumentNullException(nameof(connectionString));
        _connectionString = connectionString;
    }
    
    public Owner Create(Owner owner)
    {
        const string query =
            @"INSERT INTO dappergent2.Owners (FirstName, LastName, Email) 
              VALUES (@FirstName, @LastName, @Email);
              SELECT LAST_INSERT_ID()";
        using var connection = new MySqlConnection(_connectionString);
        var id = connection.ExecuteScalar<int>(query, owner);
        return GetById(id) ?? throw new Exception(
            $"Owner {owner.FirstName} {owner.LastName} could not be created"
        );
    }

    public Owner? GetById(int id)
    {
        var query = "SELECT * FROM dappergent2.Owners WHERE OwnerId = @OwnerId";
        using var connection = new MySqlConnection(_connectionString);
        return connection.QuerySingleOrDefault<Owner>(
            sql: query, 
            param: new {OwnerId = id});
    }

    public Owner GetByIdIncludePets(int id)
    {
        var query = @"SELECT o.OwnerId, o.FirstName, o.LastName, o.Email,
                             p.PetId, p.Name, p.DateOfBirth, p.DateOfDeath                             
                      FROM dappergent2.Owners o
                      LEFT JOIN dappergent2.Pets p ON p.OwnerId = o.OwnerId
                      WHERE o.OwnerId = @OwnerId";
        using var connection = new MySqlConnection(_connectionString);
        var result = connection.Query<Owner, Pet, Owner>(
            sql: query,
            param: new { OwnerId = id },
            splitOn: "PetId",
            map: (owner, pet) =>
            {
                owner.Pets.Add(pet);
                return owner;
            }
        );

        return new Owner
        {
            OwnerId = result.First().OwnerId,
            FirstName = result.First().FirstName,
            LastName = result.First().LastName,
            Email = result.First().Email,
            Pets = result.SelectMany(o => o.Pets).ToList()
        };
    }

    public List<Owner> GetAll()
    {
        var query = "SELECT * FROM dappergent2.Owners";
        using var connection = new MySqlConnection(_connectionString);
        return connection.Query<Owner>(query).ToList();
    }
}