using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoWebApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMongoDB<LesDemoDbContext>(
    new MongoClient("mongodb://localhost:27017"), "pg2les");

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/demomodellen", (
        LesDemoDbContext ctx,
        [FromQuery] int? greaterThanNumber,
        [FromQuery] string? containsText) => 
    ctx.DemoModels.Where(m => 
        (greaterThanNumber == null || m.MijnVeldNumber > greaterThanNumber) 
        && (containsText == null || m.MijnVeldText.Contains(containsText)))
    );

app.Run();