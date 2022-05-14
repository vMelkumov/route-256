using System.Diagnostics;

var watch = Stopwatch.StartNew();
Sandbox.ProblemC.MySolution(args);
watch.Stop();

Process currentProcess = System.Diagnostics.Process.GetCurrentProcess();
long totalBytesOfMemoryUsed = currentProcess.WorkingSet64;

Console.WriteLine($"Elapsed milliseconds: {watch.ElapsedMilliseconds}.");
Console.WriteLine($"Memory consumption is bytes: {totalBytesOfMemoryUsed}.");









