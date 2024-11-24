using System.Diagnostics;

namespace AdventOfCode;

public class AoCBase
{
    public void Run()
    {
        var input = GetInputFromFile();
        
        var stopwatch = Stopwatch.StartNew();
        Console.Write("Part One: " + PartOne(input));
        stopwatch.Stop();
        Console.WriteLine($" in {stopwatch.ElapsedMilliseconds} ms");
        
        var stopwatch2 = Stopwatch.StartNew();
        Console.Write("Part Two: " + PartTwo(input));
        stopwatch2.Stop();
        Console.WriteLine($" in {stopwatch2.ElapsedMilliseconds} ms");
    }

    protected virtual object GetInputFromFile() { return new object(); }
    
    public virtual int PartOne(object input) { return 0; }

    public virtual int PartTwo(object input) { return 0; }
}