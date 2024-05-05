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
        using var reader = new StreamReader(inputPath);
        var line = reader.ReadLine();

        while (!string.IsNullOrWhiteSpace(line))
        {
            
            line = reader.ReadLine();
        }
        reader.Close();

        return 0;
    }
}