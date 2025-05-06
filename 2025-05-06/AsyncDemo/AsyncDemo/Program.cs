using System.Collections.Concurrent;
using System.Diagnostics;
using AsyncDemo;
using SuperLibrary;


// Files zitten mee in git dus normaal niet nodig
// NOTE: Afhankelijk van hoe je project runt, kan het zijn dat je de paden moet aanpassen
// Util.GenerateData();

var timer = new Stopwatch();


// DEMO 1 - Sync VS Async
// 1. Lees Films
// 2. Bereken TheAnswer
Console.ForegroundColor = ConsoleColor.DarkRed;
Console.WriteLine("DEMO 1 - Sync VS Async");
Console.ResetColor();

Console.WriteLine();

Console.WriteLine("Sync:::");
timer.Start();
var films = SuperFileIO.GetFilms();
var resultaat = SuperCalculator.CalculateTheAnswer();
timer.Stop();
Console.WriteLine($"The answer is {resultaat}");
Console.WriteLine($"The film count is {films.Count}");
Console.WriteLine($"It took \x1b[34m{timer.ElapsedMilliseconds}\x1b[0m ms to do all this.");

Console.WriteLine();

Console.WriteLine("Async:::");
timer.Restart();
var filmsAsync = SuperFileIO.GetFilmsAsync();
var resultaatAsync = SuperCalculator.CalculateTheAnswerAsync();
Task.WaitAll(filmsAsync, resultaatAsync);
timer.Stop();
Console.WriteLine($"The answer is {resultaatAsync.Result}");
Console.WriteLine($"The film count is {filmsAsync.Result.Count}");
Console.WriteLine($"It took \x1b[34m{timer.ElapsedMilliseconds}\x1b[0m ms to do all this.");

Console.WriteLine();
Console.WriteLine();

// DEMO 2 - Async with dependant tasks
// 1. Lees Films
// 2. Bepaal de score van de films en bereken het gemiddelde
// 3. Bereken TheAnswer
Console.ForegroundColor = ConsoleColor.DarkRed;
Console.WriteLine("DEMO 2 - Sync vs Async vs Async + Parallel");
Console.ResetColor();

Console.WriteLine();

Console.WriteLine("Sync:::");
timer.Start();
var films2 = SuperFileIO.GetFilms();
var resultaat2 = SuperCalculator.CalculateTheAnswer();
var avg = films2.Select(film => SuperCalculator.CalcFilmScore(film)).Average();
timer.Stop();
Console.WriteLine($"The answer is {resultaat2}");
Console.WriteLine($"The film count is {films2.Count}");
Console.WriteLine($"The average score is {avg}");
Console.WriteLine($"It took \x1b[34m{timer.ElapsedMilliseconds}\x1b[0m ms to do all this.");

Console.WriteLine();

Console.WriteLine("Async:::");
timer.Start();
var films2Async = SuperFileIO.GetFilmsAsync();
var resultaat2Async = SuperCalculator.CalculateTheAnswerAsync();
// overhead groter dan winst dus niet nuttig
var avgAsync = films2Async.Result.Select(film => SuperCalculator.CalcFilmScoreAsync(film)).Average();
// expliciete await om zeker te zijn dat we timer pas stoppen als alles effectief klaar is
await resultaat2Async;
timer.Stop();
Console.WriteLine($"The answer is {resultaat2Async.Result}");
Console.WriteLine($"The film count is {films2Async.Result.Count}");
Console.WriteLine($"The average score is {avgAsync}");
Console.WriteLine($"It took \x1b[34m{timer.ElapsedMilliseconds}\x1b[0m ms to do all this.");

Console.WriteLine();

Console.WriteLine("Async + Parallel:::");
timer.Restart();
var films3Async = SuperFileIO.GetFilmsAsync();
var resultaat3Async = SuperCalculator.CalculateTheAnswerAsync();
await films3Async;
var bag = new ConcurrentBag<int>();
// onderlinge berekeningen zijn niet afhankelijk van elkaar dus kunnen parallel
Parallel.ForEach(films3Async.Result, film => bag.Add(SuperCalculator.CalcFilmScore(film)));
var avgParallel = bag.Average();
// expliciete await om zeker te zijn dat we timer pas stoppen als alles effectief klaar is
await resultaat3Async;
timer.Stop();
Console.WriteLine($"The answer is {resultaat3Async.Result}");
Console.WriteLine($"The film count is {films3Async.Result.Count}");
Console.WriteLine($"The average score is {avgParallel}");
Console.WriteLine($"It took \x1b[34m{timer.ElapsedMilliseconds}\x1b[0m ms to do all this.");