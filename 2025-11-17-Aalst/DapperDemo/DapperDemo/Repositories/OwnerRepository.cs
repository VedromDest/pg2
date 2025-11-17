using Dapper;
using DapperDemo.Repositories.Interfaces;
using DapperDemo.Repositories.Queries;
using MySqlConnector;

namespace DapperDemo.Repositories;

public class OwnerRepository : IOwnerRepository
{
    const string connectionString = "server=127.0.0.1;port=3307;database=DapperDemoAalst;user=dapperdemo;password=dapperdemo";
    private readonly QueryRepository _queryRepository = new QueryRepository();
    public void Create(Owner owner)
    {
        const string sql = @"INSERT INTO DapperDemoAalst.Owners (FirstName, LastName, Email) 
                                VALUES (@FirstName, @LastName, @Email)";
        using var connection = new MySqlConnection(connectionString);
        connection.Execute(sql, owner);
    }

    public Owner? GetById(int id)
    {
        const string sql = "SELECT * FROM DapperDemoAalst.Owners WHERE OwnerId = @OwnerId";
        using var connection = new MySqlConnection(connectionString);
        var result = connection.QuerySingleOrDefault<Owner>(sql, new {OwnerId = id});
        return result;
    }

    public Owner GetByIdIncludePets(int id)
    {
        var sql = _queryRepository.GetOwnerByIdIncludePets;
        using var connection = new MySqlConnection(connectionString);
        var result = connection.Query<Owner, Pet, Owner>(
            sql, 
            map: (owner, pet) =>
            {
                owner.Pets.Add(pet);
                return owner;
            },
            param: new {OwnerId = id}, 
            splitOn: "PetId");

        return new Owner()
        {
            OwnerId = result.First().OwnerId,
            FirstName = result.First().FirstName,
            LastName = result.First().LastName,
            Email = result.First().Email,
            Pets = result.SelectMany(x => x.Pets).ToList()
        };
    }

    public List<Owner> GetAll()
    {
        const string sql = "SELECT * FROM DapperDemoAalst.Owners";
        using var connection = new MySqlConnection(connectionString);
        var result = connection.Query<Owner>(sql);
        return result.ToList();
    }
}