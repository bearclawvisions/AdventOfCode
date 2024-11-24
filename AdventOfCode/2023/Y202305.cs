namespace AdventOfCode._2023;

public class Y202305(IHelper _helper) : AoCBase
{
    protected override object GetInputFromFile() { return _helper.GetInput(InputType.FullText); }

    public override int PartOne(object input)
    {
        var seedsAndMaps = ((string)input).Split(Environment.NewLine + Environment.NewLine);
        var seedList = seedsAndMaps[0].Split(":")[1].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();
        var result =  FindSeedLocation(seedList, MapProcessing(seedsAndMaps));

        return (int)result;
    }

    public override int PartTwo(object input)
    {
        List<string> puzzleInput = input.ToString().Split(Environment.NewLine + Environment.NewLine).Select(x => x[(x.IndexOf(':') + 1)..]).ToList();

        List<long> values = puzzleInput[0].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();

        List<List<(long start, long range, long offset)>> maps =
            puzzleInput.Skip(1)
                .Select(x => x.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Split(' ').Select(long.Parse).ToList()
                    ).ToList()
                    .Select(x => (x[1], x[2], x[0] - x[1])).ToList()
                ).ToList();

        long part2Answer = long.MaxValue;

        long CalcVal(long value)
        {
            for (int i = 0; i < maps.Count; i++)
            {
                foreach ((long start, long range, long offset) in maps[i])
                {
                    if (start <= value && value <= start + range)
                    {
                        value += offset;
                        break;
                    }
                }
            }

            return value;
        }

        static IEnumerable<long> LongRange(long start, long count)
        {
            for (long i = 0; i < count; i++) yield return start + i;
        }

        for (int i = 0; i < values.Count - 1; i += 2)
        {
            long minOfRange = LongRange(values[i], values[i + 1])
                .AsParallel()
                .Select(CalcVal).Min();

            if (minOfRange < part2Answer) part2Answer = minOfRange;
        }

        return (int)part2Answer;
    }
    
    private static Dictionary<string, List<Dictionary<string, long>>> MapProcessing(string[] seedsAndMaps)
    {
        return new Dictionary<string, List<Dictionary<string, long>>>
        {
            { "soilMap", ProcessMap(seedsAndMaps[1]) },
            { "fertMap", ProcessMap(seedsAndMaps[2]) },
            { "waterMap", ProcessMap(seedsAndMaps[3]) },
            { "lightMap", ProcessMap(seedsAndMaps[4]) },
            { "tempMap", ProcessMap(seedsAndMaps[5]) },
            { "humidMap", ProcessMap(seedsAndMaps[6]) },
            { "locMap", ProcessMap(seedsAndMaps[7]) }
        };
    }

    private static List<Dictionary<string, long>> ProcessMap(string map)
    {
        var list = map.Split(":")[1].Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

        return list.Select(entry => entry.Split(" ", StringSplitOptions.RemoveEmptyEntries))
            .Select(splitEntry => new Dictionary<string, long>
            {
                { "destinationRangeStart", long.Parse(splitEntry[0]) }, 
                { "sourceRangeStart", long.Parse(splitEntry[1]) }, 
                { "rangeLength", long.Parse(splitEntry[2]) },
            }).ToList();
    }
    
    private static long FindSeedLocation(List<long> seedList, Dictionary<string, List<Dictionary<string, long>>> maps)
    {
        var seedLocations = new List<long>();
        foreach (var seed in seedList)
        {
            var seedPlantingLoc = seed;
            foreach (var map in maps)
            {
                seedPlantingLoc = FindSeedInMap(seedPlantingLoc, map.Value);
            }
            seedLocations.Add(seedPlantingLoc);
        }

        return seedLocations.Min();
    }

    private static long FindSeedInMap(long seed, List<Dictionary<string, long>> map)
    {
        foreach (var entry in map)
        {
            var dest = entry["destinationRangeStart"];
            var source = entry["sourceRangeStart"];
            var range = entry["rangeLength"];

            if (seed >= entry["sourceRangeStart"] 
                && seed <= entry["sourceRangeStart"] + entry["rangeLength"] - 1)
            {
                var diff = seed - entry["sourceRangeStart"];
                return diff + entry["destinationRangeStart"];
            }
        }
        return seed;
    }
}