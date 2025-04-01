using Dierenarts.Domein;
using Microsoft.EntityFrameworkCore;

namespace Dierenarts;

public class VetDbContext : DbContext 
{
    public DbSet<Pet> Pets { get; set; } 
    public DbSet<Owner> Owners { get; set; }
    public DbSet<Note> Notes { get; set; }
    public DbSet<Vet> Vets { get ; set; } 

    // Uiteraard gaan we in een echte applicatie de connectionstring uit config lezen en de DbContext injecteren.
    private string connectionString = "server=127.0.0.1;port=3307;database=dierenarts;user=root;password=WachtW00rd"; 

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseMySql(
            connectionString,
            new MySqlServerVersion(ServerVersion.AutoDetect(connectionString))
        );
    }
}