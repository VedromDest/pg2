using FotoToestellenApp.Modellen;
using Microsoft.EntityFrameworkCore;

namespace FotoToestellenApp.Persistence;

public class FotoToestellenDbContext(DbContextOptions<FotoToestellenDbContext> options) : DbContext(options)
{
    public DbSet<Merk> Merken { get; set; }
    public DbSet<FotoToestel> FotoToestellen { get; set; }
    public DbSet<Lens> Lenzen { get; set; }
}