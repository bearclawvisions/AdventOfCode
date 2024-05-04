using System.Text.RegularExpressions;

namespace AdventOfCode._2023;

public class Y202303(IHelper helper)
{
    public void Run()
    {
        // Part One
        Console.WriteLine("Part One: " + EngineSchematic());

        // Part Two
        Console.WriteLine("Part Two: " + BetterSchematic());
    }
    
    private int EngineSchematic()
    {
        var inputPath = helper.GetInputFilePath(2023, 3);
        using var reader = new StreamReader(inputPath);
        var line = reader.ReadLine();

        var symbolLocations = new HashSet<(int, int)>();
        var allNumberLocations = new List<List<(int, int, int, int)>>();
        var row = 1;
        while (!string.IsNullOrWhiteSpace(line))
        {
            var result1 = GetSymbolLocations(row, line, @"[^.\d]");
            symbolLocations.UnionWith(result1);
            var result2 = GetNumberLocations(row, line, @"\d+");
            allNumberLocations.Add(result2);
            line = reader.ReadLine();
            row++;
        }
        reader.Close();

        var result = CheckSymbolNextToNumber(symbolLocations, allNumberLocations);
        return result;
    }

    private int BetterSchematic()
    {
        var inputPath = helper.GetInputFilePath(2023, 3);
        using var reader = new StreamReader(inputPath);
        var line = reader.ReadLine();

        var starLocations = new HashSet<(int, int)>();
        var allNumberLocations = new List<List<(int, int, int, int)>>();
        var row = 1;
        while (!string.IsNullOrWhiteSpace(line))
        {
            var result1 = GetSymbolLocations(row, line, @"\*");
            starLocations.UnionWith(result1);
            var result2 = GetNumberLocations(row, line, @"\d+");
            allNumberLocations.Add(result2);
            line = reader.ReadLine();
            row++;
        }
        reader.Close();

        var result = CalculateGearRatio(starLocations, allNumberLocations);
        return result;
    }

    private static int CalculateGearRatio(HashSet<(int, int)> stars, List<List<(int, int, int, int)>> numbers)
    {
        return 0;
    }

    private static HashSet<(int,int)> GetSymbolLocations(int row, string line, string pattern)
    {
        var symbolLocations = new HashSet<(int, int)>();
        var symbolRegex = new Regex(pattern);
        
        foreach (Match match in symbolRegex.Matches(line))
        {
            symbolLocations.Add((row, match.Index));
        }

        return symbolLocations;
    }
    
    private static List<(int, int, int, int)> GetNumberLocations(int row, string line, string pattern)
    {
        var numberLocations = new List<(int, int, int, int)>();
        var symbolRegex = new Regex(pattern);
        
        foreach (Match match in symbolRegex.Matches(line))
        {
            var start = match.Index;
            var end = match.Index + match.Length;
            var number = int.Parse(match.Value);
            
            numberLocations.Add((row, start, end, number));
        }

        return numberLocations;
    }

    private static int CheckSymbolNextToNumber(HashSet<(int, int)> symbols, List<List<(int, int, int, int)>> numbers)
    {
        var sumList = new List<int>();
        foreach (var numberTuple in numbers.Where(number => number.Count != 0))
        {
            foreach (var (row, start, end, number) in numberTuple)
            {
                var numberAdded = false;
                    
                // Check all eight directions around the number's position
                for (var dirRow = -1; dirRow <= 1; dirRow++)
                {
                    for (var dirCol = -1; dirCol <= 1; dirCol++)
                    {
                        // Skip the number's position itself
                        if (dirRow == 0 && dirCol == 0)
                            continue;

                        var newRow = row + dirRow;
                        var newColStart = start + dirCol;
                        var newColEnd = end + dirCol;

                        // Check if there's a symbol adjacent to the number in this direction
                        // -1 on end because of how indexes work with symbol locations
                        if (!symbols.Contains((newRow, newColStart)) && !symbols.Contains((newRow, newColEnd - 1)))
                            continue;

                        sumList.Add(number);
                        numberAdded = true;
                        break;
                    }
                    if (numberAdded) break;
                }
            }
        }

        return sumList.Sum();
    }
}