namespace DapperDemoGent.Repositories;

public class QueryRepository
{
    private string? _getPetByIdIncludeOwner;
    
    public string GetPetByIdIncludeOwner => _getPetByIdIncludeOwner 
        ??= File.ReadAllText("Repositories/SQL/GetPetByIdIncludeOwner.sql");
}