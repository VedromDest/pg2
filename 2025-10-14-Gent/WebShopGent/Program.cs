using Microsoft.EntityFrameworkCore;
using WebShoppie.Domain.Services;
using WebShoppie.Domain.Services.Interfaces;
using WebShoppie.Persistence;
using WebShoppie.Persistence.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//...
var connectionString = builder.Configuration.GetConnectionString("GentShoppie");
var serverVersion = new MySqlServerVersion(ServerVersion.AutoDetect(connectionString));

builder.Services.AddDbContext<ShopGentContext>(options =>
    options.UseMySql(connectionString, serverVersion));
//...

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.MapOpenApi();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
