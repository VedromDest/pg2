using System.ComponentModel.DataAnnotations;

namespace WebShoppie.Api.Contracts;

public class CustomerRequestContract
{
    [MaxLength(30)]
    public required string FirstName { get; set; }
    [MaxLength(30)]
    public required string LastName { get; set; }
    [EmailAddress]
    public required string  Email { get; set; }
    //...
}