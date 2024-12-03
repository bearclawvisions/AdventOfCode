namespace AdventOfCode._2024;

public class Y202402 : AoCBase
{
    public override int PartOne(string input)
    {
        var lines = input.ToEnumerableString().ToArray();
        var correctReports = 0;

        foreach (var line in lines)
        {
            var numbers = line.Split(' ').Select(int.Parse).ToArray();
            bool isAscending = numbers.Zip(numbers.Skip(1), (a, b) => a <= b).All(x => x);
            bool isDescending = numbers.Zip(numbers.Skip(1), (a, b) => a >= b).All(x => x);

            // report isn't valid. so skip
            if (!isAscending && !isDescending) continue;
            
            // bool allDifferencesAreThreeOrLess = numbers.Zip(numbers.Skip(1), (a, b) => Math.Abs(a - b) <= 3).All(x => x);

            bool allDifferencesAreThreeOrLess = true;
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (Math.Abs(numbers[i] - numbers[i + 1]) > 3 || Math.Abs(numbers[i] - numbers[i + 1]) == 0)
                {
                    allDifferencesAreThreeOrLess = false;
                    break; // Exit early if condition fails
                }
            }
            
            if (allDifferencesAreThreeOrLess) correctReports++;

        }
        
        return correctReports;
    }

    public override int PartTwo(string input)
    {
        var lines = input.ToEnumerableString().ToArray();

        var correctReports = lines.Count(line => IsSafe(line));
        
        return correctReports;
    }
    
    private static bool IsSafe(string line)
    {
        var levels = line.Split(' ').Select(int.Parse).ToList();

        // Helper function to check if levels are safe
        bool IsSafeList(List<int> levels)
        {
            bool isIncreasing = true, isDecreasing = true;

            for (int i = 1; i < levels.Count; i++)
            {
                int diff = levels[i] - levels[i - 1];

                // Adjacent levels must differ by at least 1 and at most 3
                if (Math.Abs(diff) < 1 || Math.Abs(diff) > 3)
                    return false;

                if (diff > 0) isDecreasing = false; // Not strictly decreasing
                if (diff < 0) isIncreasing = false; // Not strictly increasing
            }

            return isIncreasing || isDecreasing;
        }

        // Check if the list is safe without removing any levels
        if (IsSafeList(levels)) return true;

        // Check if removing one level makes it safe
        for (int i = 0; i < levels.Count; i++)
        {
            var modifiedLevels = new List<int>(levels);
            modifiedLevels.RemoveAt(i);

            if (IsSafeList(modifiedLevels)) return true;
        }

        return false; // Not safe even with dampener
    }
}