namespace AdventOfCode;

public class AoCBase(IHelper helper)
{
    public void Run()
    {
        var input = UseRealInput(0, 0);
        Console.WriteLine("Part One: " + PartOne(input));
        Console.WriteLine("Part Two: " + PartTwo(input));
    }

    protected virtual IEnumerable<string> UseRealInput(int year, int day)
    {
        return helper.GetInput(year, day);
    } 
    
    protected virtual int PartOne(IEnumerable<string> input) { return 0; }

    protected virtual int PartTwo(IEnumerable<string> input) { return 0; }
}