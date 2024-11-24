using System.Reflection;
using System.Text.RegularExpressions;

namespace AdventOfCode._2023;

public class Y202301(IHelper _helper) : AoCBase
{
    protected override object GetInputFromFile() { return _helper.GetInput(InputType.Lines); }

    public override int PartOne(object input)
    {
        var calibrationList = new List<int>();

        foreach (var line in (IEnumerable<string>)input)
        {
            // Regex to match the first occurence of an int
            var match1 = Regex.Match(line, @"\d").Value;

            // Regex to match the last occurence; $ denotes the end of a string
            var match2 = Regex.Match(line, @"(\d)(?=\D*$)").Value;

            if (!match1.Equals(string.Empty) && !match2.Equals(string.Empty))
            {
                var number = string.Concat(match1, match2);
                calibrationList.Add(int.Parse(number));
            }
        }

        return calibrationList.Sum();
    }

    public override int PartTwo(object input)
    {
        var calibrationList = new List<int>();
        var words = new[] { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        const string pattern = @"\d|one|two|three|four|five|six|seven|eight|nine";

        foreach (var line in (IEnumerable<string>)input)
        {
            var number1 = Regex.Match(line, pattern).Value;
            var number2 = Regex.Match(line, pattern, RegexOptions.RightToLeft).Value;

            if (!number1.Equals(string.Empty) && !number2.Equals(string.Empty))
            {
                var num1 = ConvertToNumber(number1, words);
                var num2 = ConvertToNumber(number2, words);
                var number = string.Concat(num1, num2);
                calibrationList.Add(int.Parse(number));
            }
        }

        return calibrationList.Sum();
    }

    private static int ConvertToNumber(string word, string[] words)
    {
        if (int.TryParse(word, out int number))
            return number;

        return Array.IndexOf(words, word) + 1;
    }
}