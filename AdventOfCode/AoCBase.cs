namespace AdventOfCode;

public class AoCBase
{
    public void Run()
    {
        var input = GetInputFromFile();
        Console.WriteLine("Part One: " + PartOne(input));
        Console.WriteLine("Part Two: " + PartTwo(input));
    }

    protected virtual object GetInputFromFile() { return new object(); }
    
    public virtual int PartOne(object input) { return 0; }

    public virtual int PartTwo(object input) { return 0; }
}