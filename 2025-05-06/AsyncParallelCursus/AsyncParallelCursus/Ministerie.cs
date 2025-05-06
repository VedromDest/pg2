using System.Diagnostics;

namespace AsyncParallelCursus;

public class Ministerie
{
    public void Run()
    {
        var ambtenaar = new AmbtenaarAsync() { Naam = "Karel" };
        var stopwatch = new Stopwatch();

        stopwatch.Start();
        ambtenaar.DrinkKoffie();
        ambtenaar.VerrichtKleineTaak(1);
        ambtenaar.DrinkKoffie();
        ambtenaar.VerrichtKleineTaak(2);
        ambtenaar.DrinkKoffie();
        stopwatch.Stop();

        ConsoleUtil.PrintVerstrekenTijd(stopwatch);
    }
    
    public void RunDrukkeDag()
    {
        var ambtenaar = new AmbtenaarAsync() { Naam = "Karel" };
        var stopwatch = new Stopwatch();

        stopwatch.Start();
        ambtenaar.VerrichtKleineTaak(1);
        ambtenaar.VerrichtGroteTaak(2);
        ambtenaar.VerrichtKleineTaak(3);
        stopwatch.Stop();

        ConsoleUtil.PrintVerstrekenTijd(stopwatch);
    }
    
    public void RunChefIsterug()
    {
        var chef = new Chef() {Naam = "Bernard"};
        var ambtenaar = new AmbtenaarAsync() { Naam = "Karel", Chef = chef};
        var stopwatch = new Stopwatch();

        stopwatch.Start();
        ambtenaar.VerrichtKleineTaak(1);
        ambtenaar.VraagToestemming(2);
        ambtenaar.VerrichtGroteTaak(2);
        ambtenaar.VerrichtKleineTaak(3);
        stopwatch.Stop();

        ConsoleUtil.PrintVerstrekenTijd(stopwatch);
    }
    
    public async Task RunAsync()
    {
        var chef = new Chef() {Naam = "Bernard"};
        var ambtenaar = new AmbtenaarAsync() { Naam = "Karel", Chef = chef};
        var stopwatch = new Stopwatch();

        stopwatch.Start();
        ambtenaar.VerrichtKleineTaak(1);
        var wachtendeToestemming = ambtenaar.VraagToestemmingAsync(2); 
        ambtenaar.VerrichtKleineTaak(3);
        await wachtendeToestemming; 
        ambtenaar.VerrichtGroteTaak(2);
        stopwatch.Stop();

        ConsoleUtil.PrintVerstrekenTijd(stopwatch);
    }
}