// See https://aka.ms/new-console-template for more information

using DapperDemo;

Console.WriteLine("Hello, World!");

IOwnerRepository ownerRepo = new OwnerRepository();
var owners = ownerRepo.GetAll();

foreach (var owner in owners)
{
    Console.WriteLine(owner.Email);
}

Console.WriteLine(new string('-', 50));

var found = ownerRepo.GetById(1);
Console.WriteLine($"'{found?.Email}'");
var notFound = ownerRepo.GetById(100);
Console.WriteLine($"'{notFound?.Email}'");

Console.WriteLine(new string('-', 50));

var newOwner = new Owner
{
    FirstName = "John",
    LastName = "OutOfLine",
    Email = "johnny@net.com"
};
ownerRepo.Create(newOwner);


IPetRepository petRepository = new PetRepository();
var pets = petRepository.GetAll();

foreach (var pet in pets)
{
    Console.WriteLine(pet.Name);
}

Console.WriteLine(new string('-', 50));

var foundPet = petRepository.GetById(2);
Console.WriteLine($"'{foundPet?.Name}'");
var notFoundPet = petRepository.GetById(200);
Console.WriteLine($"'{notFoundPet?.Name}'");

Console.WriteLine(new string('-', 50));
/*
var newPet = new Pet
{
    Name = "Fluffy",
    DateOfBirth = DateTime.Now,
    OwnerId = 1
};
petRepository.Create(newPet);
*/
Console.WriteLine(new string('-', 50));

var foundPet2 = petRepository.GetByIdIncludeOwner(2);
Console.WriteLine($"'{foundPet2?.Name}' van '{foundPet2?.Owner?.Email}'");

Console.WriteLine(new string('-', 50));

var foundOwner = ownerRepo.GetByIdIncludePets(1);
Console.WriteLine($"'{foundOwner?.Email}' ({foundOwner.Pets.Count} pets)");

