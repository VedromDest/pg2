using Microsoft.EntityFrameworkCore;

namespace EFCoreCodeFirstDemo;

public class PetContext : DbContext
{
    public DbSet<Owner> Owners { get; set; }
    public DbSet<Pet> Pets { get; set; }
    public DbSet<Note> Notes { get; set; }
    public DbSet<Vet> Vets { get; set; }
    
    // use settings/secrets to store connection string
    private string connectionString = "server=127.0.0.1;port=3307;database=efcoregent;user=efcoregent;password=efcoregent"; 

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseMySql(
            connectionString,
            new MySqlServerVersion(ServerVersion.AutoDetect(connectionString))
        );
    }
}