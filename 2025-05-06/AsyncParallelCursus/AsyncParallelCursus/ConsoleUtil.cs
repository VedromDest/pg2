using System.Diagnostics;

namespace AsyncParallelCursus;

public static class ConsoleUtil
{
    public static void PrintVerstrekenTijd(Stopwatch stopwatch)
    {
        Console.WriteLine($"Het duurde in totaal {stopwatch.ElapsedMilliseconds}ms (of minuten in het echt).");
    }
}