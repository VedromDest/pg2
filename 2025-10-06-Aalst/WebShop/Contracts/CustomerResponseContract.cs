namespace WebShop.Contracts;

public class CustomerResponseContract
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string Email { get; set; }
    public ECountries Country { get; set; } 
}