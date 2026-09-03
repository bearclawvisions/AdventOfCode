namespace AdventOfCode._2025;

public class Y202505 : AoCBase
{
    private record Range(long Min, long Max);
    public override int PartOne(string input)
    {
        var lines = input.ToEnumerableString().ToArray();

        var rangeSplit = lines.Where(x => x.Contains('-')).ToArray();
        var ranges = rangeSplit
            .Select(x => x.Split('-').Select(long.Parse).ToArray())
            .Select(x => new Range(x[0], x[1]))
            .ToArray();
        
        // consolidate overlapping ranges, so no need to worry about duplicates
        var consolidateRanges = ConsolidateRanges(ranges);
        
        var ingredients = lines.Where(x => !x.Contains('-')).Select(long.Parse).ToList();
        
        //var availableIngredients = new HashSet<long>();
        var amountOfAvailableIngredients = 0;
        foreach (var range in consolidateRanges)
        {
            // find ingredients falling in range
            var ingredientsInRange = ingredients
                .Where(x => x >= range.Min && x <= range.Max)
                .ToArray();
            
            foreach (var ingredient in ingredientsInRange)
            {
                amountOfAvailableIngredients++;
                // ingredients.Remove(ingredient);
                // availableIngredients.Add(ingredient); // hashset prevents duplicates in the range
            }
        }
        
        // return availableIngredients.Count;
        return amountOfAvailableIngredients;
    }
    
    public override long PartTwoLong(string input)
    {
        var lines = input.ToEnumerableString().ToArray();

        var rangeSplit = lines.Where(x => x.Contains('-')).ToArray();
        var ranges = rangeSplit
            .Select(x => x.Split('-').Select(long.Parse).ToArray())
            .Select(x => new Range(x[0], x[1]))
            .ToArray();
        
        // consolidate overlapping ranges, so no need to worry about duplicates
        var consolidateRanges = ConsolidateRanges(ranges);
        
        var freshIngredientIds = 0L;
        foreach (var range in consolidateRanges)
        {
            // +1 since range is inclusive
            freshIngredientIds += range.Max - range.Min + 1;
        }
        
        return freshIngredientIds;
    }
    
    private static List<Range> ConsolidateRanges(IEnumerable<Range> ranges)
    {
        var sorted = ranges.OrderBy(r => r.Min).ToList();
        var merged = new List<Range>();

        foreach (var range in sorted)
        {
            // ^1 = last element; index from end. same as: merged[merged.Count - 1]
            if (merged.Count == 0 || range.Min > merged[^1].Max + 1)
            {
                // No overlap or adjacency — start a new range
                merged.Add(range);
            }
            else
            {
                // Overlap or adjacent — extend the current range if needed
                var last = merged[^1];
                merged[^1] = last with { Max = Math.Max(last.Max, range.Max) };
            }
        }

        return merged;
    }
}