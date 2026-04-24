using Microsoft.EntityFrameworkCore;
using WebShoppie.DataModel;
using WebShoppie.Domain.Services;
using WebShoppie.Domain.Services.Interfaces;
using WebShoppie.Persistence.EfCore;
using WebShoppie.Persistence.EFCore;
using WebShoppie.Persistence.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddDbContext<WebShoppieDbContext>(
    optionsBuilder => optionsBuilder.UseNpgsql(
        builder.Configuration.GetConnectionString(
            "Postgres"),
        contextOptionsBuilder => contextOptionsBuilder.MigrationsHistoryTable(
            "__EFMigrationsHistory","Shoppie")));

builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ICustomerRepository, EfCoreCustomerRepository>();

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, EfCoreProductRepository>();

builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderRepository, EfCoreOrderRepository>();

var app = builder.Build();

using var dbScope = app.Services.CreateScope();
var db = dbScope.ServiceProvider.GetRequiredService<WebShoppieDbContext>();
db.Database.Migrate();

app.MapControllers();
app.UseExceptionHandler(app.Environment.IsDevelopment() ? "/error-development" : "/error");

app.Run();