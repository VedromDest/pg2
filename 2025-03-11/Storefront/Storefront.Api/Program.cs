using Microsoft.EntityFrameworkCore;
using Storefront.Api.Repositories;
using Storefront.Api.Services;
using Storefront.Persistence;

namespace Storefront.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        string connectionString = "server=127.0.0.1;port=3307;database=storefront;user=pg2user;password=pg2user";
        var serverVersion = new MySqlServerVersion(ServerVersion.AutoDetect(connectionString));
        builder.Services.AddDbContext<StorefrontContext>(options =>
    options.UseMySql(connectionString, serverVersion));

        builder.Services.AddSingleton<IOrderRepository, OrderRepository>();
        builder.Services.AddSingleton<ICustomerRepository, CustomerRepository>();
        builder.Services.AddSingleton<IProductRepository, ProductRepository>();
        builder.Services.AddScoped<IProductService, ProductService>();
        builder.Services.AddScoped<IOrderService, OrderService>();
        builder.Services.AddControllers();

        var app = builder.Build();

        // Configure the HTTP request pipeline.

        app.UseHttpsRedirection();

        app.MapControllers();

        app.Run();
    }
}