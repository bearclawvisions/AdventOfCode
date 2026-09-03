namespace AdventOfCode._2025;

public class Y202503 : AoCBase
{
    public override string PartOne(string input)
    {
        var lines = input.ToEnumerableString().ToArray();
        var joltage = 0;

        foreach (var line in lines)
        {
            joltage += FindHighestJoltage(line);
        }
        
        return joltage.ToString();
    }

    private static int FindHighestJoltage(string line)
    {
        var firstBatteryJoltage = 0;
        var secondBatteryStartIndex = 0;
        var batteryLength = line.Length;

        for (var i = 0; i < batteryLength; i++) // could also reduce batteryLength here to skip last digit
        {
            var isLastDigit = batteryLength == i + 1;
            // arithmic - autopromotes the char to int. the '0' is the arithmic code for 48
            // e.g. arithmic code for '7' = 55
            // so 55 - 48 = 7, this logic only works for chars that are digits 0-9
            var joltage = line[i] - '0';

            if (joltage > firstBatteryJoltage && !isLastDigit) // if last digit is highest, don't set it as first since we need 2 digits
            {
                firstBatteryJoltage = joltage;
                secondBatteryStartIndex = i + 1;
            }
        }
        
        var secondBatteryJoltage = 0;
        for (var i = secondBatteryStartIndex; i < batteryLength; i++) {
            var joltage = line[i] - '0';

            if (joltage > secondBatteryJoltage) {
                secondBatteryJoltage = joltage;
            }
        }
        return firstBatteryJoltage * 10 + secondBatteryJoltage;
    }
}