// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using Patisserie;

Console.WriteLine("Hello, World!");

var stopwatch = new Stopwatch();

// 1 pistolet bakken
stopwatch.Start();
var pistolet = new Pistolet();
pistolet.Bak();
stopwatch.Stop();
Console.WriteLine($"Tijd 1p: {stopwatch.ElapsedMilliseconds}ms");

// 100 pistolets bakken
stopwatch.Restart();
// Notitie Jippe span iteratie in foreach opzoeken
var pistolets = new Pistolet[100];
for (int i = 0; i < pistolets.Length; i++)
{
    pistolets[i] = new Pistolet();
}
foreach (var p in pistolets)
{
    p.Bak();
}

stopwatch.Stop();
Console.WriteLine($"Tijd 100p: {stopwatch.ElapsedMilliseconds}ms");

// 100 pistolets in parallel bakken
stopwatch.Restart();
var pistoletsParallel = new Pistolet[100];
for (int i = 0; i < pistoletsParallel.Length; i++)
{
    pistoletsParallel[i] = new Pistolet();
}
Parallel.ForEach(pistoletsParallel, p => p.Bak());
stopwatch.Stop();
Console.WriteLine($"Tijd 100p parallel: {stopwatch.ElapsedMilliseconds}ms");
