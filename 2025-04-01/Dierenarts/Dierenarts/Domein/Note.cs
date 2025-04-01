using System.ComponentModel.DataAnnotations;

namespace Dierenarts.Domein;

public class Note
{
    public int Id { get; set; } 

    [MaxLength(5000)] 
    public string Content { get; set; }
    public DateTime CreationDate { get; set; }

    public Pet Pet { get; set; } 
}