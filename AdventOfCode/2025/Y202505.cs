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
        
        var ingredients = lines.Where(x => !x.Contains('-')).Select(long.Parse).ToList();
        
        var availableIngredients = new HashSet<long>();
        foreach (var range in ranges)
        {
            // find ingredients falling in range
            var ingredientsInRange = ingredients
                .Where(x => x >= range.Min && x <= range.Max)
                .ToArray();
            
            foreach (var ingredient in ingredientsInRange)
            {
                ingredients.Remove(ingredient);
                availableIngredients.Add(ingredient); // hashset prevents duplicates in the range
            }
        }
        
        return availableIngredients.Count;
    }
}