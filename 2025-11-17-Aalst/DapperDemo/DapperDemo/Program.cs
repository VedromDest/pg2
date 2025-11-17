// See https://aka.ms/new-console-template for more information

using DapperDemo;
using DapperDemo.Repositories;
using DapperDemo.Repositories.Interfaces;

Console.WriteLine("Hello, World!");

IOwnerRepository ownerRepository = new OwnerRepository();
/*
Console.WriteLine("------------------");
var owners = ownerRepository.GetAll();
foreach (var owner in owners)
{
    Console.WriteLine(owner);
}
Console.WriteLine("------------------");
var owner1 = ownerRepository.GetById(1);
Console.WriteLine(owner1);
Console.WriteLine("------------------");
var nieuweOwner = new Owner{FirstName = "Nieuwe", LastName = "Owner", Email = "abc123@fmail.com"};
ownerRepository.Create(nieuweOwner);
Console.WriteLine("------------------");
IPetRepository petRepository = new PetRepository();
var mijnPet = petRepository.GetByIdIncludeOwner(1);
Console.WriteLine(mijnPet);
*/
Console.WriteLine(ownerRepository.GetByIdIncludePets(1));