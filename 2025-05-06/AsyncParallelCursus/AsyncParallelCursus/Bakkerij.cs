using System.Diagnostics;

namespace AsyncParallelCursus;

public class Bakkerij
{
    public void RunSingle()
    {
        var pistolet = new Pistolet();
        var stopwatch = new Stopwatch();

        stopwatch.Start();
        pistolet.Bak();
        stopwatch.Stop();

        ConsoleUtil.PrintVerstrekenTijd(stopwatch);
    }
    
    public void RunSequential()
    {
        var stopwatch = new Stopwatch();
        const int aantalPistolets = 100;

        var pistolets = new List<Pistolet>();
        for (int i = 0; i < aantalPistolets; i++)
            pistolets.Add(new Pistolet());

        stopwatch.Start();
        foreach (var pistolet in pistolets)
            pistolet.Bak();
        stopwatch.Stop();

        ConsoleUtil.PrintVerstrekenTijd(stopwatch);
    }
    
    public void RunParallel()
    {
        var stopwatch = new Stopwatch();
        const int aantalPistolets = 100;

        var pistolets = new List<Pistolet>();
        for (int i = 0; i < aantalPistolets; i++)
            pistolets.Add(new Pistolet());

        stopwatch.Start();
        Parallel.ForEach(pistolets, pistolet =>
        {
            if(DateTime.UtcNow.DayOfWeek != DayOfWeek.Monday)
                pistolet.Bak();
        });
        
        stopwatch.Stop();

        ConsoleUtil.PrintVerstrekenTijd(stopwatch);
    }
    
}