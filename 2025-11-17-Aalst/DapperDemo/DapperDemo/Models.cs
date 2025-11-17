namespace DapperDemo;

public class Owner
{
    public int OwnerId { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }

    public List<Pet> Pets { get; set; } = [];
    
    public override string ToString() => $"{OwnerId} {FirstName} {LastName} {Email} Pets:{string.Join(',', Pets.Select(p => p.Name))}";
}

public record Pet
{
    public int PetId { get; set; }

    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public DateTime? DateOfDeath { get; set; }

    public Owner Owner { get; set; }
}