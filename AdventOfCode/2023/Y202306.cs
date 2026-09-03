namespace AdventOfCode._2023;

public class Y202306 : AoCBase
{
    public override string PartOne(string input)
    {
        var lines = input.ToArrayInput().ToArray();
        var timeArray = lines.ElementAt(0).Split(':')[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var distanceArray = lines.ElementAt(1).Split(':')[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);

        return string.Empty;
    }

    public override string PartTwo(string input)
    {
        return base.PartTwo(input);
    }
}