namespace AsynchroneAmbtenaar;

public class Chef : Ambtenaar
{
    public void GeefToestemming(int taakId)
    {
        Thread.Sleep(125);
        Console.WriteLine($"{Naam} geeft toestemming voor taak {taakId}");
    }
    
    public async Task GeefToestemmingAsync(int id)
    {
        await Task.Delay(800);
        Console.WriteLine(
            $"Chef {Naam} geeft toestemming voor taak {id}");
    }
}

public class Ambtenaar
{
    public string Naam { get; set; }
    public Chef Chef { get; set; }

    public void VerrichtKleineTaak(int id)
    {
        Thread.Sleep(100);
        Console.WriteLine($"{Naam} verrichte kleine taak {id}");
    }

    public void VerrichtGroteTaak(int id)
    {
        Thread.Sleep(250);
        Console.WriteLine($"{Naam} verrichte grote taak {id}");
    }

    public void DrinkKoffie()
    {
        Thread.Sleep(50);
        Console.WriteLine($"{Naam} dronk een koffie");
    }
    
    public void VraagToestemming(int id)
    {
        Console.WriteLine($"{Naam} vraagt toestemming voor taak {id}");
        Chef.GeefToestemming(id);
    }
    
    public Task VraagToestemmingAsync(int id)
    {
        Console.WriteLine(
            $"{Naam} vraagt toestemming voor taak {id} aan {Chef.Naam}");
        return Chef.GeefToestemmingAsync(id);
    }
}