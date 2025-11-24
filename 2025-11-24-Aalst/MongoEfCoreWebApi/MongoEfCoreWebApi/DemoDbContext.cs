using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;

namespace MongoEfCoreWebApi;

public class DemoDbContext : DbContext
{
    public DbSet<DemoModel> DemoModels { get; init; }

    public DemoDbContext(DbContextOptions options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<DemoModel>().ToCollection("testcollection");
    }
}