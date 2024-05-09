namespace AdventOfCode;

public class AoCBase
{
    public void Run()
    {
        // Part One
        Console.WriteLine("Part One: " + PartOne());

        // Part Two
        Console.WriteLine("Part Two: " + PartTwo());
    }
    
    protected virtual int PartOne()
    {
        return 0;
    }

    protected virtual int PartTwo()
    {
        return 0;
    }
}