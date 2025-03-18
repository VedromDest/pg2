using Microsoft.EntityFrameworkCore;
using Storefront.Persistence;
using Storefront.Services;

namespace Storefront.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        var connectionString = builder.Configuration.GetConnectionString("LocalMySQL");
        var serverVersion = new MySqlServerVersion(ServerVersion.AutoDetect(connectionString));
        builder.Services.AddDbContext<StorefrontContext>(options =>
            options.UseMySql(connectionString, serverVersion));
        
        builder.Services.AddScoped<IProductService, ProductService>();
        builder.Services.AddScoped<IOrderService, OrderService>();
        builder.Services.AddScoped<ICustomerService, CustomerService>();        
        builder.Services.AddControllers();

        var app = builder.Build();

        // Configure the HTTP request pipeline.

        app.UseHttpsRedirection();

        app.MapControllers();

        app.Run();
    }
}