using System.ComponentModel.DataAnnotations;

namespace EFCoreCodeFirstDemo;

public class Vet
{
    public int Id { get; set; }
    [MaxLength(30)]
    public string Name { get; set; }

    public List<Pet> Pets { get; set; }
}