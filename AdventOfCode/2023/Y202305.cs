namespace AdventOfCode._2023;

public class Y202305(IHelper _helper) : AoCBase
{
    protected override object GetInputFromFile() { return _helper.GetInputText(2023, 5); }

    public override int PartOne(object input)
    {
        var seedsAndMaps = ((string)input).Split(Environment.NewLine + Environment.NewLine);
        var seedList = seedsAndMaps[0].Split(":")[1].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();
        var result =  FindSeedLocation(seedList, MapProcessing(seedsAndMaps));

        return (int)result;
    }

    public override int PartTwo(object input)
    {
        var seedsAndMaps = ((string)input).Split(Environment.NewLine + Environment.NewLine);
        var seedList = seedsAndMaps[0].Split(":")[1].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();
        
        long result = 0;
        // iterate over the list in steps of 2
        for (var item = 0; item < seedList.Count; item += 2)
        {
            var seed = seedList[item];
            var range = seedList[item + 1];

            for (long number = 0; number < range; number++)
            {
                var subResult = FindSeedLocation([seed + number], MapProcessing(seedsAndMaps));
                if (subResult < result || result == 0)
                    result = subResult;
            }
        }
        
        return (int)result;
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