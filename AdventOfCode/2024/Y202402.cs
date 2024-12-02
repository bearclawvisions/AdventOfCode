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

        
        return 0;
    }
}