using Microsoft.EntityFrameworkCore;
using WebShoppie.DataModel.Entities;

namespace WebShoppie.DataModel;

public partial class WebShoppieDbContext(DbContextOptions<WebShoppieDbContext> options) : DbContext(options)
{
    public virtual DbSet<Customer> Customers { get; set; }
    public virtual DbSet<Order> Orders { get; set; }
    public virtual DbSet<Orderproduct> Orderproducts { get; set; }
    public virtual DbSet<Product> Products { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("Shoppie");
        base.OnModelCreating(modelBuilder);
    }    
}
