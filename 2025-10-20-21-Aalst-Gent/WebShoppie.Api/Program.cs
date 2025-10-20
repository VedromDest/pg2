using Microsoft.EntityFrameworkCore;
using WebShoppie.Domain.Services;
using WebShoppie.Domain.Services.Interfaces;
using WebShoppie.Persistence;
using WebShoppie.Persistence.Entities;
using WebShoppie.Persistence.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("GentShoppie");
var serverVersion = new MySqlServerVersion(ServerVersion.AutoDetect(connectionString));

builder.Services.AddDbContext<ShopGentContext>(options =>
    options.UseMySql(connectionString, serverVersion));

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddControllers();

// Build app
var app = builder.Build();

// Verken apiController klassen en bind routes op methodes
app.MapControllers(); 

app.Run();
