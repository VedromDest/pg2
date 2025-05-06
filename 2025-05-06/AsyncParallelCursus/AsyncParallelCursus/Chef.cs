namespace AsyncParallelCursus;

public class Chef : AmbtenaarAsync
{
    public void GeefToestemming(int taakId)
    {
        Thread.Sleep(125);
        Console.WriteLine($"{Naam} geeft toestemming voor taak {taakId}");
    }
    
    public async Task GeefToestemmingAsync(int taakId)
    {
        await Task.Delay(125);
        Console.WriteLine($"{Naam} geeft toestemming voor taak {taakId}");
    }
}