using Dapper;
using MySqlConnector;

namespace DapperDemo;

public interface IPetRepository
{
    void Create(Pet pet);
    Pet? GetById(int id);
    Pet GetByIdIncludeOwner(int id);
    List<Pet> GetAll();
    void Update(Pet pet);
    void Delete(Pet pet);
}

public class PetRepository : IPetRepository
{
    private string ConnectionString { get; } = "server=127.0.0.1;port=3307;database=dapperpg2;user=dapperpg2;password=dapperpg2";
    
    public void Create(Pet pet)
    {
        const string query = "INSERT INTO Pets (OwnerId, Name, DateOfBirth, DateOfDeath) VALUES (@OwnerId, @Name, @DateOfBirth, @DateOfDeath)";
        using var connection = new MySqlConnection(ConnectionString);
        connection.Execute(query, pet);    }

    public Pet? GetById(int id)
    {
        const string query = "SELECT * FROM Pets WHERE PetId = @Id";
        using var connection = new MySqlConnection(ConnectionString);
        var result = connection.QuerySingleOrDefault<Pet>(query, new { Id = id });
        return result;    
    }

    public Pet GetByIdIncludeOwner(int id)
    {
        const string query = @"SELECT  o.OwnerId, o.FirstName, o.LastName, o.Email,
        p.PetId, p.Name, p.DateOfBirth, p.DateOfDeath
        FROM    Pets p
        INNER JOIN Owners o on p.OwnerId = o.OwnerId
        WHERE   p.PetId = @PetId";

        using var connection = new MySqlConnection(ConnectionString);
        var result = connection.Query<Owner, Pet, Pet>(
            sql: query,
            map: (owner, pet) =>
            {
                pet.Owner = owner;
                pet.OwnerId = owner.OwnerId;
                return pet;
            },
            param: new { PetId = id},
            splitOn: "PetId");

        return result.First();
    }

    public List<Pet> GetAll()
    {
        const string query = "SELECT * FROM Pets";
        using var connection = new MySqlConnection(ConnectionString);
        var result = connection.Query<Pet>(query);
        return result.ToList();
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