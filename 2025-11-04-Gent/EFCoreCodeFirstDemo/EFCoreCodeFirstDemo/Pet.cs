using System.ComponentModel.DataAnnotations;

namespace EFCoreCodeFirstDemo;

public partial class Pet
{
    public int Id { get; set; } 

    [MaxLength(30)] 
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public DateTime? DateOfPassing { get; set; } 

    public Owner Owner { get; set; } 
    public List<Note> Notes { get ; set; }
    public List<Vet> Vets { get; set; }
}