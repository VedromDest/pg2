using System.ComponentModel.DataAnnotations;

namespace WebShoppie.Api.Contracts;

public class CustomerResponseContract
{
    public int Id { get; set; }
    [MaxLength(30)]
    public string FirstName { get; set; }
    [MaxLength(30)]
    public string LastName { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    public string FullContactInfo { get; set; }
    //...
}