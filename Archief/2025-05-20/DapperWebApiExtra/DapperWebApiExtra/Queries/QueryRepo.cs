namespace DapperWebApiExtra.Queries;

public class QueryRepo
{
    private string? _demoTypeCreate;
    private string? _demoTypeGetById;
    private string? _demoTypeGetAll;

    private const string QueryRoot = "Queries/";

    public string DemoTypeCreateQuery => _demoTypeCreate ??= GetQuery(nameof(DemoTypeCreateQuery));
    public string DemoTypeGetByIdQuery => _demoTypeGetById ??= GetQuery(nameof(DemoTypeGetByIdQuery));
    public string DemoTypeGetAllQuery => _demoTypeGetAll ??= GetQuery(nameof(DemoTypeGetAllQuery));

    private static string GetQuery(string queryName) =>
        File.ReadAllText(QueryRoot + queryName + ".sql");
}