namespace DapperDemo;

public class Pet
{
    public int PetId { get; set; }

    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public DateTime? DateOfDeath { get; set; }

    public Owner Owner { get; set; }
    public int OwnerId { get; set; }
}