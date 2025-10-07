namespace DapperDemo.Queries;

public class QueryRepository
{
    private string? _ownerCreateQuery;

    private const string QueryRoot = "Queries/";

    public string OwnerCreateQuery =>
        _ownerCreateQuery ??=
            GetQuery(nameof(OwnerCreateQuery));

    private static string GetQuery(string queryName) =>
        File.ReadAllText(QueryRoot + queryName + ".sql");
}