namespace AdventOfCode._2025;

public class Y202502 : AoCBase
{
    public override string PartOne(string input)
    {
        var lines = input.Split(',');
        long sum = 0L;
        
        foreach (var line in lines)
        {
            var range = line.Split('-');
            var min = long.Parse(range[0]);
            var max = long.Parse(range[1]);
            
            sum += FindInvalidIds(min, max);
        }
        
        return sum.ToString();
    }

    private static long FindInvalidIds(long min, long max)
    {
        long sum = 0L;
        for (var digit = min; digit <= max; digit++)
        {
            if (IsInvalidId(digit))
                sum += digit;
        }

        return sum;
    }

    private static bool IsInvalidId(long digit)
    {
        var digitAsString = digit.ToString();
        var length = digitAsString.Length;
        var halfLength = length / 2;

        // can the digit be split into two equal halves? if no skip the digit
        if (length % 2 != 0)
            return false;

        // for each half, check if the characters are equal, 0 index
        for (var i = 0; i < halfLength; i++)
        {
            if (digitAsString[i] != digitAsString[halfLength + i])
                return false;
        }

        return true;
    }
}