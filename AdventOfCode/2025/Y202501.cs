namespace AdventOfCode._2025;

public class Y202501 : AoCBase
{
    private const string Left = "L";
    private const int DialMin = 0;
    private const int DialMax = 99;
    private const int DialTicks = 100;
    
    public override int PartOne(string input)
    {
        var lines = input.ToEnumerableString().ToArray();
        
        var dialPosition = 50;
        var zeroCount = 0;

        foreach (var line in lines)
        {
            var rotation = ParseRotation(line);
            dialPosition = CalculateNewPosition(dialPosition, rotation);
            
            if (dialPosition == DialMin)
                zeroCount++;
        }

        return zeroCount;
    }

    public override int PartTwo(string input)
    {
        var lines = input.ToEnumerableString().ToArray();
        
        var dialPosition = 50;
        var zeroCount = 0;

        foreach (var line in lines)
        {
            var rotation = ParseRotation(line);
            dialPosition += rotation;
            zeroCount += CalculateZerosPassed(dialPosition, rotation);
            dialPosition = ((dialPosition % DialTicks) + DialTicks) % DialTicks;
        }
        
        return zeroCount;
    }

    private static int CalculateZerosPassed(int dialPosition, int rotation)
    {
        if (rotation > 0)
            return dialPosition / DialTicks;

        var zerosPassed = (DialTicks - dialPosition) / DialTicks;
        var startedAtZero = dialPosition - rotation == 0;

        if (startedAtZero)
            zerosPassed--;
        
        return zerosPassed;
    }

    private static int CalculateNewPosition(int dialPosition, int rotation)
    {
        var newPosition = dialPosition + rotation;

        if (newPosition > DialMax)
        {
            var diff = newPosition - DialTicks;
            return DialMin + diff;
        }
        else if (newPosition < DialMin)
        {
            newPosition *= -1;
            return DialTicks - newPosition;
        }

        return newPosition;
    }

    private static int ParseRotation(string line)
    {
        var direction = line[..1];
        var distance = int.Parse(line[1..]);

        if (direction == Left)
            distance *= -1; // turn counter-clockwise

        return distance;
    }
}