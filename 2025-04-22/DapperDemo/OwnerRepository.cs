using Dapper;
using DapperDemo.Queries;
using MySqlConnector;

namespace DapperDemo;

public interface IOwnerRepository
{
    void Create(Owner owner);
    Owner? GetById(int id);
    Owner GetByIdIncludePets(int id);
    List<Owner> GetAll();
}

public class OwnerRepository : IOwnerRepository
{
    private string ConnectionString { get; } = "server=127.0.0.1;port=3307;database=dapperpg2;user=dapperpg2;password=dapperpg2";
    private QueryRepository _queries = new QueryRepository();
    
    public void Create(Owner owner)
    {
        using var connection = new MySqlConnection(ConnectionString);
        connection.Execute(_queries.OwnerCreateQuery, owner);
    }

    public Owner? GetById(int id)
    {
        const string query = "SELECT * FROM Owners WHERE OwnerId = @Id";
        using var connection = new MySqlConnection(ConnectionString);
        var result = connection.QuerySingleOrDefault<Owner>(query, new { Id = id });
        return result;
    }

    public Owner GetByIdIncludePets(int id)
    {
        using var connection = new MySqlConnection(ConnectionString);
        var result = connection.Query<Owner, Pet, Owner>(
            sql: @"SELECT  o.OwnerId, o.FirstName, o.LastName, o.Email,
                            p.PetId, p.Name, p.DateOfBirth, p.DateOfDeath
                    FROM    Owners o
                                LEFT OUTER JOIN Pets p on p.OwnerId = o.OwnerId
                    WHERE   o.OwnerId = @OwnerId",
            map: (owner, pet) => 
            {
                owner.Pets.Add(pet);
                return owner;
            },
            param: new { OwnerId = id},
            splitOn: "PetId"); 

        return MapToManyPets(result); 
    }
    
    private Owner MapToManyPets(IEnumerable<Owner> ownerRecords)
    {
        var singleOwner = ownerRecords.First();

        singleOwner.Pets = ownerRecords.Select(or => 
        {
            var pet = or.Pets.First();
            pet.Owner = singleOwner;
            pet.OwnerId = singleOwner.OwnerId;
            return pet;
        }).ToList();

        return singleOwner; 
    }

    public List<Owner> GetAll()
    {
        const string query = "SELECT * FROM Owners";
        using var connection = new MySqlConnection(ConnectionString);
        var result = connection.Query<Owner>(query);
        return result.ToList();
    }
}