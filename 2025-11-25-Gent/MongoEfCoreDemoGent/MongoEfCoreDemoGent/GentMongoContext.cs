using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;

namespace MongoEfCoreDemoGent;

public class GentMongoContext : DbContext
{
    public DbSet<GentModel> GentModels { get; set; }
    
    public GentMongoContext(DbContextOptions<GentMongoContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<GentModel>().ToCollection("voorbeeldcollection"); 
    }
}