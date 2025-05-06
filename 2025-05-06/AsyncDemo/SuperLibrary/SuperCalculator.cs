using System;
using SuperModel;

namespace SuperLibrary;

public static class SuperCalculator
{
    public static int CalculateTheAnswer()
    {
        Thread.Sleep(1000); // Simulate a long calculation
        return 42;
    }

    public static Task<int> CalculateTheAnswerAsync()
    {
        Task.Delay(1000).Wait(); // Simulate a long async calculation
        return Task.FromResult(42);
    }

    public static int CalcFilmScore(Film film)
    {
        Thread.Sleep(10); // Simulate a long calculation
        return new Random().Next(1, 101);
    }

    public static int CalcFilmScoreAsync(Film film)
    {
        Task.Delay(10); // Simulate a long async calculation
        return new Random().Next(1, 101);
    }
}
