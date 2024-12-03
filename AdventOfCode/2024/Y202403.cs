using System.Text.RegularExpressions;

namespace AdventOfCode._2024;

public class Y202403 : AoCBase
{
    public override int PartOne(string input)
    {
        var lines = input.ToEnumerableString();
        var sum = 0;

        foreach (var line in lines)
        {
            var matches = Regex.Matches(line, @"mul\(\d+,\d+\)");

            foreach (Match match in matches)
            {
                var numbers = match.Value.Replace("mul(", string.Empty).Replace(")", string.Empty);
                var numbersCount = numbers.Split(',').Select(int.Parse).ToArray();
                sum += numbersCount[0] * numbersCount[1];
            }
        }

        return sum;
    }

    public override int PartTwo(string input)
    {
        var lines = input.ToEnumerableString();
        var sum = 0;
        bool doMath = true;
    
        var mulPattern = @"mul\((\d+),(\d+)\)";
        var doPattern = @"do\(\)";
        var dontPattern = @"don't\(\)";

        foreach (var line in lines)
        {
            var allMatches = new List<Match>();
            allMatches.AddRange(Regex.Matches(line, mulPattern));
            allMatches.AddRange(Regex.Matches(line, doPattern));
            allMatches.AddRange(Regex.Matches(line, dontPattern));

            // Sort the matches by their position in the input (Index property).
            allMatches.Sort((a, b) => a.Index.CompareTo(b.Index));
            
            // Process each match in order.
            foreach (var match in allMatches)
            {
                if (Regex.IsMatch(match.Value, mulPattern))
                {
                    if (doMath)
                    {
                        var numberMatch = Regex.Match(match.Value, mulPattern);
                        var num1 = int.Parse(numberMatch.Groups[1].Value);
                        var num2 = int.Parse(numberMatch.Groups[2].Value);
                        sum += num1 * num2;
                    }
                }
                else if (Regex.IsMatch(match.Value, doPattern)) doMath = true;
                else if (Regex.IsMatch(match.Value, dontPattern)) doMath = false;
            }
        }
    
        return sum;
    }
}