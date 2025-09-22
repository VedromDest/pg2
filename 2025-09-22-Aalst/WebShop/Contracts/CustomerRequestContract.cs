using System.ComponentModel.DataAnnotations;

namespace WebShop.Contracts;

public class CustomerRequestContract
{
    [MaxLength(30)] 
    public string FirstName { get; set; }

    [EmailAddress] 
    public string Email { get; set; }
    public string Country { get; set; }
}