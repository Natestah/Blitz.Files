# Blitz.Files

C# Parallel Persistent File Discovery for Blitz Search

This helps serve slow enumeration of files by keeping track of the results, It also helps to have a Cancellation source to be able to cancel the requests at any time.

It also has a .gitIgnore parser, to help alleviate the results of undesired files when searching for code things.

```cs
var searchPath = new SearchPath{ Folder = directory };
var paths = new List<SearchPath>{searchPath};
var discoverer = new FileDiscovery(paths, useGitIgnore:false);
var cancelSource = new CancellationTokenSource();
discoverer.WaitUntilFinished(cancelSource);
files = [..discoverer.EnumerateAllFiles(cancelSource)];
timer.Stop();
```

# Example output ( BlitzFilesConsoleDemo ) on my 14GB collection of repositories (without .gitignore parsing)

```
Enumerating files with 'Directory.Enumeratefiles
Elapsed time: 455 MS
Total files: 71649
Cold Enumeration of files using FileDiscoverer
Elapsed time: 421 MS
Total files: 71649
Cached Enumeration of files using FileDiscoverer
Elapsed time: 10 MS
Total files: 71649
```