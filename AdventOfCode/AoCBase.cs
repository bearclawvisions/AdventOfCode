using System.Diagnostics;

namespace AdventOfCode;

public class AoCBase()
{
    public void Run()
    {
        var input = Helper.GetInput();
        
        var stopwatch = Stopwatch.StartNew();
        Console.Write("Part One: " + PartOne(input));
        stopwatch.Stop();
        Console.WriteLine($" in {stopwatch.ElapsedMilliseconds} ms");
        
        var stopwatch2 = Stopwatch.StartNew();
        Console.Write("Part Two: " + PartTwo(input));
        stopwatch2.Stop();
        Console.WriteLine($" in {stopwatch2.ElapsedMilliseconds} ms");
    }

    public virtual int PartOne(string input) => 0;

    public virtual int PartTwo(string input) => 0;
}