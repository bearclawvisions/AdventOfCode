namespace AdventOfCode._2023;

public class Y202305(IHelper helper)
{
    public void Run()
    {
        // Part One
        Console.WriteLine("Part One: " + PartOne());

        // Part Two
        Console.WriteLine("Part Two: " );
    }
    
    private int PartOne()
    {
        var inputPath = helper.GetInputFilePath(2023, 5);
        var seedsAndMaps = File.ReadAllText(inputPath).Split(Environment.NewLine + Environment.NewLine);
        var seedList = seedsAndMaps[0].Split(":")[1].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

        return 0;
    }
}