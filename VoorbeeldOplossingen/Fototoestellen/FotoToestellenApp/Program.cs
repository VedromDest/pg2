using FotoToestellenApp.CUI;
using FotoToestellenApp.Persistence;
using FotoToestellenApp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("FotoToestellenMySQL");
var serverVersion = new MySqlServerVersion(ServerVersion.AutoDetect(connectionString));

builder.Services.AddDbContext<FotoToestellenDbContext>(options =>
    options.UseMySql(connectionString, serverVersion), contextLifetime: ServiceLifetime.Singleton);

builder.Services.AddSingleton<IFotoToestellenService, FotoToestellenService>();
builder.Services.AddSingleton<AppActies, AppActies>();

builder.Services.AddHostedService<App>();

var host = builder.Build();
await host.RunAsync();