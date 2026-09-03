using System.Numerics;

namespace AdventOfCode._2025;

public class Y202506 : AoCBase
{
    public override string PartOne(string input)
    {
        var lines = input.ToArrayInput();
        var columns = new List<DataStructure>();

        var lineCount = 0;
        foreach (var line in lines)
        {
            var split = line.Split(" ").Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
            var columnCount = 0;
            
            if (lineCount == 0) // populate initial list
            {
                foreach (var number in split)
                {
                    var value = int.Parse(number);
                    columns.Add(new DataStructure { Values = new[] { value }, Operation = '.' });
                    columnCount++;
                }
            }
            else if (lineCount == lines.Length - 1) // populate calculation '*' or '+'
            {
                foreach (var calculation in split)
                {
                    columns[columnCount].Operation = char.Parse(calculation);
                    columnCount++;
                }
            }
            else
            {
                foreach (var number in split)
                {
                    var value = int.Parse(number);
                    columns[columnCount].Values = columns[columnCount].Values.Append(value).ToArray();
                    columnCount++;
                }
            }

            lineCount++;
        }
        
        long sum = 0L;
        
        foreach (var column in columns)
        {
            var result = column.Operation == '*' 
                ? column.Values.Aggregate(1L, (a, b) => a * b) // 1L as seed type, so multiplication starts with 1 as a long
                : column.Values.Aggregate((a, b) => a + b);
            sum += result;
        }
        
        return sum.ToString();
    }
}

public class DataStructure
{
    public required int[] Values;
    public char Operation;
}