using MongoDB.Driver;
using MongoEfCoreDemoGent;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMongoDB<GentMongoContext>(
    new MongoClient("mongodb://localhost:27017"), "pg2gent");

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/mongodemoapi/gentmodels", (GentMongoContext dbctx) => dbctx.GentModels.ToList());

app.Run();