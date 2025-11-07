using Microsoft.EntityFrameworkCore;

namespace EFCoreCodeFirst;

public class VetDbContext : DbContext
{
    public DbSet<Owner> Owners { get; set; }
    public DbSet<Pet> Pets { get; set; }
    public DbSet<Note> Notes { get; set; }
    public DbSet<Vet> Vets { get; set; }
    public DbSet<OptionalToSql> OptionalToSqls { get; set; }
    
    // Doe dit niet in serieuze code. Zet de cs in settings/secrets/...
    private const string ConnectionString = "server=127.0.0.1;port=3307;database=efcoreaalst;user=efcoreaalst;password=efcoreaalst";

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseMySql(
            ConnectionString,
            new MySqlServerVersion(ServerVersion.AutoDetect(ConnectionString))
        );
    }
}