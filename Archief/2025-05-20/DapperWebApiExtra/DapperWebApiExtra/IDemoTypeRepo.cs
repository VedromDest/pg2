using Dapper;
using DapperWebApiExtra.Queries;
using MySqlConnector;

namespace DapperWebApiExtra;

public interface IDemoTypeRepo
{
    DemoType Add(DemoType demoType);
    DemoType? GetById(int id);
    IEnumerable<DemoType> GetAll();
}

public class DemoTypeRepo(IConfiguration configuration, QueryRepo queries) : IDemoTypeRepo
{
    private readonly string _connectionString = configuration.GetConnectionString("MySQL") ?? throw new ArgumentNullException();
    
    public DemoType Add(DemoType demoType)
    {
        using var connection = new MySqlConnection(_connectionString);
        // MS SQL Server kan een rij integraal teruggeven na INSERT dmv OUTPUT INSERTED.*
        // MySQL kan dit (voor zover ik weet) niet. We kunnen wel generated Id opvragen en record SELECTen
        // Dit is geen Dapper feature - de instructie staat in .sql file
        var generatedId = connection.QuerySingle<int>(queries.DemoTypeCreateQuery, demoType);
        return GetById(generatedId) ?? throw new Exception("Oeioei");
    }

    public DemoType? GetById(int id)
    {
        using var connection = new MySqlConnection(_connectionString);
        var result = connection.QuerySingleOrDefault<DemoType>(queries.DemoTypeGetByIdQuery, new { Id = id });
        return result;
    }

    public IEnumerable<DemoType> GetAll()
    {
        using var connection = new MySqlConnection(_connectionString);
        var result = connection.Query<DemoType>(queries.DemoTypeGetAllQuery);
        return result;
    }
}