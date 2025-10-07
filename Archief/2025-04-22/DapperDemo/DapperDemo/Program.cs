// See https://aka.ms/new-console-template for more information
using DapperDemo.Repositories;

Console.WriteLine("Hello, World!");

var ownerRepo = new OwnerRepository();
var owners = ownerRepo.GetAll();

foreach (var item in owners)
{
    Console.WriteLine(item.FirstName);
}