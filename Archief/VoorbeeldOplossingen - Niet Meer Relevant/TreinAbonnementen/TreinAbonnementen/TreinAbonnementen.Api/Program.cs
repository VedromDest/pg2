using Microsoft.EntityFrameworkCore;
using TreinAbonnementen.Persistence;
using TreinAbonnementen.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("LocalMySQL");
var serverVersion = new MySqlServerVersion(ServerVersion.AutoDetect(connectionString));
builder.Services.AddDbContext<TrainSubsDbContext>(options =>
    options.UseMySql(connectionString, serverVersion));
        
builder.Services.AddScoped<IStationService, StationService>();
builder.Services.AddScoped<ISubscriptionService, SubscriptionService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();        
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.MapControllers();
app.Run();