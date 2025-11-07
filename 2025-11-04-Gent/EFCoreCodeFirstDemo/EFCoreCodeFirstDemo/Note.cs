using System.ComponentModel.DataAnnotations;

namespace EFCoreCodeFirstDemo;

public class Note
{
    public int Id { get; set; } 

    [MaxLength(5000)] 
    public string Content { get; set; }
    public DateTime CreationDate { get; set; }

    public Pet Pet { get; set; } 
}