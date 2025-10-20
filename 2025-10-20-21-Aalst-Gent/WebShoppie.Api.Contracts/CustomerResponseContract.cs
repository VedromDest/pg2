using System.ComponentModel.DataAnnotations;

namespace WebShoppie.Api.Contracts;

public class CustomerResponseContract
{
    public required int Id { get; set; }
    [MaxLength(30)]
    public required string FirstName { get; set; }
    [MaxLength(30)]
    public required string LastName { get; set; }
    [EmailAddress]
    public required string Email { get; set; }
    public required string FullContactInfo { get; set; }
    //...
}