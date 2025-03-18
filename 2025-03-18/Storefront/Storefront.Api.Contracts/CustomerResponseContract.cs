namespace Storefront.Api.Contracts;

public class CustomerResponseContract
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public required string Email { get; set; }
    public string? TaxIdentificationNumber { get; set; }
    public required string Addressline1 { get; set; }
    public required string Addressline2 { get; set; }
    public string? Addressline3 { get; set; }
    public string? Country { get; set; }
}