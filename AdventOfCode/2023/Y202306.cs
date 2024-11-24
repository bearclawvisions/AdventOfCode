namespace AdventOfCode._2023;

public class Y202306 : AoCBase
{
    public override int PartOne(string input)
    {
        var lines = input.ToEnumerableString().ToArray();
        var timeArray = lines.ElementAt(0).Split(':')[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var distanceArray = lines.ElementAt(1).Split(':')[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);

        return 0;
    }

    public override int PartTwo(string input)
    {
        return base.PartTwo(input);
    }
}