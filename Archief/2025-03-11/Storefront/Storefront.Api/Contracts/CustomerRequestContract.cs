using System.ComponentModel.DataAnnotations;

namespace Storefront.Api.Contracts;

public class CustomerRequestContract
{
    [MaxLength(30)]
    public string FirstName { get; set; }
    [MaxLength(30)]
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    [MaxLength(20)]
    public string? TaxIdentificationNumber { get; set; }
    [MaxLength(50)]
    public string Addressline1 { get; set; }
    [MaxLength(50)]
    public string Addressline2 { get; set; }
    [MaxLength(50)]
    public string? Addressline3 { get; set; }
    [MaxLength(20)]
    public string Country { get; set; }
}