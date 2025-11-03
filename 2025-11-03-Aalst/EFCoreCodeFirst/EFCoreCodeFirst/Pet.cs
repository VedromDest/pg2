using System.ComponentModel.DataAnnotations;

namespace EFCoreCodeFirst;

public class Pet
{
    public int Id { get; set; } 

    [MaxLength(30)] 
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public DateTime? DateOfDeath { get; set; } 

    public Owner Owner { get; set; } 
    public List<Note> Notes { get ; set; }
    public List<Vet> Vets { get; set; }
}