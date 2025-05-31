using DapperWebApiExtra;
using DapperWebApiExtra.Queries;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton(new QueryRepo());
builder.Services.AddScoped<IDemoTypeRepo, DemoTypeRepo>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapPost("/demotypes", (IDemoTypeRepo repo, [FromBody] DemoType demoType) => repo.Add(demoType));
app.MapGet("/demotypes", (IDemoTypeRepo repo) => repo.GetAll());
app.MapGet("/demotypes/{id}", (IDemoTypeRepo repo, [FromRoute] int id) => repo.GetById(id));

app.Run();