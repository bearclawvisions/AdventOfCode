namespace AdventOfCode._2023;

public class Y202305(IHelper helper) : AoCBase
{
    protected override int PartOne()
    {
        var inputPath = helper.GetInputFilePath(2023, 5);
        var seedsAndMaps = File.ReadAllText(inputPath).Split(Environment.NewLine + Environment.NewLine);
        var seedList = seedsAndMaps[0].Split(":")[1].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

        return 0;
    }
}