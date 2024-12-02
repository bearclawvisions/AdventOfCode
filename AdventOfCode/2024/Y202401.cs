namespace AdventOfCode._2024;

public class Y202401 : AoCBase
{
    public override int PartOne(string input)
    {
        var lines = input.ToEnumerableString().ToArray();
        var firstList = new List<int>();
        var secondList = new List<int>();

        foreach (var line in lines)
        {
            var numbers = line.Split("   ");
            firstList.Add(int.Parse(numbers[0]));
            secondList.Add(int.Parse(numbers[1]));
        }
        
        firstList.Sort();
        secondList.Sort();

        var sumOfDifferences = 0;
        for (int i = 0; i < firstList.Count; i++)
        {
            var difference = firstList[i] - secondList[i];
            if (difference < 0)
                difference *= -1;
            
            sumOfDifferences += difference;
        }
        
        return sumOfDifferences;
    }

    public override int PartTwo(string input)
    {
        var lines = input.ToEnumerableString().ToArray();
        var firstList = new List<int>();
        var secondList = new List<int>();
        
        foreach (var line in lines)
        {
            var numbers = line.Split("   ");
            firstList.Add(int.Parse(numbers[0]));
            secondList.Add(int.Parse(numbers[1]));
        }
        
        firstList.Sort();
        secondList.Sort();

        var sumOfDifferences = 0;
        foreach (var number in firstList)
        {
            var count = secondList.FindAll(x => x.Equals(number)).Count;
            var similarityScore = number * count;
            
            sumOfDifferences += similarityScore;
        }
        
        return sumOfDifferences;
    }
}