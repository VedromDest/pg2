using System.ComponentModel.DataAnnotations;

namespace WebShoppie.Api.Contracts;

public class CustomerRequestContract
{
    [MaxLength(30)]
    public string FirstName { get; set; }
    [MaxLength(30)]
    public string LastName { get; set; }
    [EmailAddress]
    public string  Email { get; set; }
    //...
}