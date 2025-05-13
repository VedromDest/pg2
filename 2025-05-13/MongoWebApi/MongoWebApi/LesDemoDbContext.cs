using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;

namespace MongoWebApi;

public class LesDemoDbContext : DbContext
{
    public DbSet<DemoModel> DemoModels { get; init; }

    public LesDemoDbContext(DbContextOptions options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<DemoModel>().ToCollection("voorbeeldles");
    }
}    