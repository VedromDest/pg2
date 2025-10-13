namespace WebShop.Contracts;

public class CustomerResponseContract
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string Email { get; set; }
    public ECountries Country { get; set; } 
}