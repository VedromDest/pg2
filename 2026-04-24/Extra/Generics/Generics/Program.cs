Console.WriteLine("Hello, World!");

/*
var pCache = new PersonCache();
var person = new Person() { Id = 1, Email = "jefke@hotmail.com" };
pCache.Add(1, person);
Console.WriteLine(pCache.Get(1));

var petCache = new PetCache();
var pet = new Pet() { Id = 1, Name = "Misty",  VetNotes = "Some notes" };
petCache.Add(1, pet);
Console.WriteLine(petCache.Get(1));
*/
var pCache = new GenericCache<Person>();
var person = new Person() { Id = 1, Email = "jefke@hotmail.com" };
pCache.Add(1, person);
Console.WriteLine(pCache.Get(1));

var petCache = new GenericCache<Pet>();
var pet = new Pet() { Id = 1, Name = "Misty",  VetNotes = "Some notes" };
petCache.Add(1, pet);
Console.WriteLine(petCache.Get(1));

public class Person
{
    public int Id { get; set; }
    public string Email { get; set; }

    public override string ToString()
    {
        return $"Id: {Id}, Email: {Email}";
    }
}

public class Pet
{
    public int Id { get; set; }
    public string VetNotes { get; set; }
    public string Name { get; set; }
    public override string ToString(){
        return $"Id: {Id}, Name: {Name}, VetNotes: {VetNotes}";}
}

public class PersonCache
{
    private readonly Dictionary<int, Person> _dic = new();

    public void Add(int id, Person person)
    {
        _dic[id] = person;
    }

    public Person Get(int id)
    {
        return _dic[id];
    }
}

public class PetCache
{
    private readonly Dictionary<int, Pet> _dic = new();

    public void Add(int id, Pet pet)
    {
        _dic[id] = pet;
    }

    public Pet Get(int id)
    {
        return _dic[id];
    }
}

public class GenericCache<T>
{
    private readonly Dictionary<int, T> _dic = new();
    public void Add(int id, T pet)
    {
        _dic[id] = pet;
    }

    public T Get(int id)
    {
        return _dic[id];
    }
    
    public T[] ReverseArray(T[] arr)
    {
        var localArray = arr.ToArray();
        
        int leftIndex = 0;
        int rightIndex = localArray.Length - 1;
        T val;
        while (leftIndex < rightIndex)
        {
            val = localArray[leftIndex];
            localArray[leftIndex] = localArray[rightIndex];
            localArray[rightIndex] = val;
            leftIndex++;
            rightIndex--;
        }
        
        return localArray;
    }
}
