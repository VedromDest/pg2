// See https://aka.ms/new-console-template for more information

using DapperDemoGent;
using DapperDemoGent.Repositories;

Console.WriteLine("Hello, World!");

var connectionstring = "server=127.0.0.1;port=3307;database=dappergent2;user=dappergent2;password=dappergent2";
var queryRepository = new QueryRepository();
IOwnerRepository ownerRepository = new OwnerRepository(connectionstring);
IPetRepository petRepository = new PetRepository(connectionstring, queryRepository);

/*
var owners = ownerRepository.GetAll();
foreach (var owner in owners)
{
    Console.WriteLine(owner);
}
*/
/*
var deEneOwner = ownerRepository.GetById(1);
Console.WriteLine(deEneOwner);

var deAndereOwner = ownerRepository.GetById(10000);
Console.WriteLine(deAndereOwner);
*/

/*
var pet = petRepository.GetPetByIdIncludeOwner(1);
Console.WriteLine(pet);
*/

/*
var owner = ownerRepository.GetByIdIncludePets(1);
Console.WriteLine(owner);
*/

var nieuweOwner = new Owner()
{
    FirstName = "Nieuw",
    LastName = "Gebruiker",
    Email = "nieuw@fmail.com"
};

var created = ownerRepository.Create(nieuweOwner);
Console.WriteLine(created);