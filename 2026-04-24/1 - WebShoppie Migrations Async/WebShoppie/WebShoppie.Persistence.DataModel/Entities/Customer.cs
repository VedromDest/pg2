using System.ComponentModel.DataAnnotations;

namespace WebShoppie.DataModel.Entities;

public class Customer
{
    public long CustomerId { get; set; }

    [MaxLength(50)]
    public required string FirstName { get; set; }

    [MaxLength(50)]
    public required string LastName { get; set; }

    public required DateTime DateOfBirth { get; set; }

    [MaxLength(100)] [EmailAddress]
    public required string Email { get; set; }

    [MaxLength(50)]
    public required string Addressline1 { get; set; }

    [MaxLength(50)]
    public required string Addressline2 { get; set; }

    [MaxLength(50)]
    public string? Addressline3 { get; set; }

    [MaxLength(2)]
    public required string Country { get; set; }

    public  ICollection<Order> Orders { get; set; } = new List<Order>();
    
    public int Age => DateTime.Today.Year - DateOfBirth.Year - DateTime.Today.DayOfYear < DateOfBirth.DayOfYear ? 1 : 0;
}
