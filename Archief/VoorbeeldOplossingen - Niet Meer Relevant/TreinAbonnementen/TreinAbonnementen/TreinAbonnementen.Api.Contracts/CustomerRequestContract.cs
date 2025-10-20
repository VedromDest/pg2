namespace TreinAbonnementen.Api.Contracts;

public class CustomerRequestContract
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
}