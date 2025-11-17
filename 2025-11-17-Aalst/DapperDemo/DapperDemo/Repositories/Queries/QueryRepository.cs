namespace DapperDemo.Repositories.Queries;

public class QueryRepository
{
    private string? _getOwnerByIdIncludePetsQuery;

    private const string QueryRoot = "Repositories/Queries/SQL/";

    public string GetOwnerByIdIncludePets =>
        _getOwnerByIdIncludePetsQuery ??=
            GetQuery(nameof(GetOwnerByIdIncludePets));

    private static string GetQuery(string queryName) =>
        File.ReadAllText(QueryRoot + queryName + ".sql");
}