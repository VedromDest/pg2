using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace EFCoreCodeFirst;

[Index(nameof(Email), IsUnique = true)]
public class Owner 
{
    public int Id { get; set; }

    [MaxLength(30)] 
    public string FirstName { get; set; }
    [MaxLength(30)]
    public string LastName { get; set; }
    [MaxLength(50)]
    public string Email { get; set; }
    [MaxLength(16)]
    public string PhoneNumber { get; set; }

    public List<Pet> Pets { get; set; } 
}