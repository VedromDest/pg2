// See https://aka.ms/new-console-template for more information

using AsyncParallelCursus;

Console.WriteLine("Hello, World!");

//var bakkerij = new Bakkerij();
//bakkerij.RunSingle();
//bakkerij.RunSequential();
// bakkerij.RunParallel();

var ministerie = new Ministerie();
// ministerie.Run();
// ministerie.RunDrukkeDag();
// ministerie.RunChefIsterug();
await ministerie.RunAsync();