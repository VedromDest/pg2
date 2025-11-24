using MongoDB.Driver;
using MongoEfCoreWebApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMongoDB<DemoDbContext>(
    new MongoClient("mongodb://localhost:27017"),
    "pg2aalst"
);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/demomodels", (DemoDbContext dbContext) => dbContext.DemoModels);

app.Run();