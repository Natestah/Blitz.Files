// See https://aka.ms/new-console-template for more information


using System.Diagnostics;
using Blitz.Files;
using Blitz.Interfacing;

string? directory = string.Empty;
while (true)
{
    Console.WriteLine("Input a valid directory to run Blitz Files Demo on:");
    directory = Console.ReadLine();
    if (string.IsNullOrEmpty(directory))
    {
        continue;
    }
    if (Directory.Exists(directory))
    {
        break;
    }
}

var timer = Stopwatch.StartNew();
var files = new List<string>();
Console.WriteLine("Enumerating files with 'Directory.Enumeratefiles");
files = Directory.EnumerateFiles(directory, "*.*", SearchOption.AllDirectories).ToList();
timer.Stop();
Console.WriteLine($"Elapsed time: {timer.ElapsedMilliseconds} MS");
Console.WriteLine($"Total files: {files.Count}");


Console.WriteLine("Cold Enumeration of files using FileDiscoverer");
timer = Stopwatch.StartNew();

var searchPath = new SearchPath{ Folder = directory };
var paths = new List<SearchPath>{searchPath};
var discoverer = new FileDiscovery(paths, useGitIgnore:false);
discoverer.WaitUntilFinished(new CancellationTokenSource());
files = [..discoverer.EnumerateAllFiles(new CancellationTokenSource())];
timer.Stop();

Console.WriteLine($"Elapsed time: {timer.ElapsedMilliseconds} MS");
Console.WriteLine($"Total files: {files.Count}");

Console.WriteLine("Cached Enumeration of files using FileDiscoverer");
timer = Stopwatch.StartNew();
files = [..discoverer.EnumerateAllFiles(new CancellationTokenSource())];
timer.Stop();
Console.WriteLine($"Elapsed time: {timer.ElapsedMilliseconds} MS");
Console.WriteLine($"Total files: {files.Count}");


