namespace WebShoppie.Api.Contracts.Customers;

public class CustomerResponseContract
{
    public int CustomerId { get; init; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required DateTime DateOfBirth { get; set; }
    public required string Email { get; set; }
    public required string AddressLine1 { get; set; }
    public required string AddressLine2 { get; set; }
    public string? AddressLine3 { get; set; }
    public required string Country { get; set; }
}