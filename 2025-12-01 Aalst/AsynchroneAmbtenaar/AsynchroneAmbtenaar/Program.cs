// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using AsynchroneAmbtenaar;

Console.WriteLine("Hello, World!");

var ministerie = new Ministerie();
ministerie.RunRustigeDag();
Console.WriteLine(new string('-', 80));
ministerie.RunDrukkeDag();
Console.WriteLine(new string('-', 80));
ministerie.RunDeChefIsTerug();
Console.WriteLine(new string('-', 80));
await ministerie.RunDeChefIsTerugAsync();