using System.ComponentModel.DataAnnotations;

namespace Dierenarts.Domein;

public class Vet
{
    public int Id { get; set; }
    [MaxLength(45)] 
    public string Name { get; set; }
    public List<Pet> Pets { get; set; }
}