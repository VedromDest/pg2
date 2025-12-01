using System.Diagnostics;

namespace AsynchroneAmbtenaar;

public class Ministerie
{
    public void RunRustigeDag()
    {
        var ambtenaar = new Ambtenaar() { Naam = "Karel" };
        var stopwatch = new Stopwatch();

        stopwatch.Start();
        ambtenaar.DrinkKoffie();
        ambtenaar.VerrichtKleineTaak(1);
        ambtenaar.DrinkKoffie();
        ambtenaar.VerrichtKleineTaak(2);
        ambtenaar.DrinkKoffie();
        stopwatch.Stop();

        Console.WriteLine($"Ambtenaar {ambtenaar.Naam}'s dag duurde {stopwatch.ElapsedMilliseconds}ms");
    }
    
    public void RunDrukkeDag()
    {
        var ambtenaar = new Ambtenaar() { Naam = "Karel" };
        var stopwatch = new Stopwatch();

        stopwatch.Start();
        ambtenaar.VerrichtKleineTaak(1);
        ambtenaar.VerrichtGroteTaak(2);
        ambtenaar.VerrichtKleineTaak(3);
        stopwatch.Stop();

        Console.WriteLine($"Ambtenaar {ambtenaar.Naam}'s dag duurde {stopwatch.ElapsedMilliseconds}ms");
    }
    
    public void RunDeChefIsTerug()
    {
        var chef = new Chef() {Naam = "Bernard"};
        var ambtenaar = new Ambtenaar() { Naam = "Karel", Chef = chef};
        var stopwatch = new Stopwatch();

        stopwatch.Start();
        ambtenaar.VerrichtKleineTaak(1);
        ambtenaar.VraagToestemming(2);
        ambtenaar.VerrichtGroteTaak(2);
        ambtenaar.VerrichtKleineTaak(3);
        stopwatch.Stop();

        Console.WriteLine($"Ambtenaar {ambtenaar.Naam}'s dag duurde {stopwatch.ElapsedMilliseconds}ms");
    }
    
    public async Task RunDeChefIsTerugAsync()
    {
        var chef = new Chef() {Naam = "Bernard"};
        var ambtenaar = new Ambtenaar() { Naam = "Karel", Chef = chef};
        var stopwatch = new Stopwatch();

        stopwatch.Start();
        var toestemmingTask = ambtenaar.VraagToestemmingAsync(2);
        ambtenaar.VerrichtKleineTaak(1);
        ambtenaar.VerrichtKleineTaak(3);
        await toestemmingTask;
        ambtenaar.VerrichtGroteTaak(2);
        stopwatch.Stop();

        Console.WriteLine($"Ambtenaar {ambtenaar.Naam}'s dag duurde {stopwatch.ElapsedMilliseconds}ms");
    }
}