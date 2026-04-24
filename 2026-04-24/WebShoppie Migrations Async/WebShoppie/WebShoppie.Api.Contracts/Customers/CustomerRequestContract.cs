using System.ComponentModel.DataAnnotations;

namespace WebShoppie.Api.Contracts.Customers;

public class CustomerRequestContract
{
    [MaxLength(50)]
    public required string FirstName { get; init; }
    [MaxLength(100)]
    public required string LastName { get; init; }
    public required DateTime DateOfBirth { get; init; }
    [EmailAddress]
    public required string Email { get; init; }
    public required string AddressLine1 { get; init; }
    public required string AddressLine2 { get; init; }
    public string? AddressLine3 { get; init; }
    public required string Country { get; init; }
}