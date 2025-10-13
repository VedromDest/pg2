using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using WebShop.Repositories;
using WebShop.Services;
using WebShoppie.Persistence;
using WebShoppie.Persistence.Interfaces;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("StoreFrontMySQL");
var serverVersion = new MySqlServerVersion(ServerVersion.AutoDetect(connectionString));

builder.Services.AddDbContext<WebshopaalstContext>(options =>
    options.UseMySql(connectionString, serverVersion));

// Add services to the container.
//TODO all injected services should derive from an interface - best practice
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<OrderRepository>();
//builder.Services.AddSingleton<IOrderService, OrderService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddControllers().AddJsonOptions(opt => {
    opt.JsonSerializerOptions.Converters.Add(
        new JsonStringEnumConverter());
});
;
builder.Services.AddProblemDetails();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.MapOpenApi();
//}

app.UseHttpsRedirection();

app.MapControllers();


app.Run();
