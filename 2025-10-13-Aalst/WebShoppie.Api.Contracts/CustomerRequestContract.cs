using System.ComponentModel.DataAnnotations;

namespace WebShop.Contracts;

public class CustomerRequestContract
{
    [MaxLength(30)] 
    public string FirstName { get; set; }
    [MaxLength(30)]
    public string LastName { get; set; }

    [EmailAddress] 
    public string Email { get; set; }
    public required ECountries Country { get; set; }
}