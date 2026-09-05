namespace AdventOfCode._2025;

public class Y202510 : AoCBase
{
    private record Machine(string LightGoal, List<int[]> Buttons, int[] Joltage);
    
    private const char LightOn = '#';
    private const char LightOff = '.';
    
    public override string PartOne(string input)
    {
        var lines = input.ToArrayInput();
        var machines = ProcessMachineInfo(lines);
        
        // 1 [] lights; 1-* () buttons; 1 {} joltage
        
        return base.PartOne(input);
    }

    private List<Machine> ProcessMachineInfo(string[] lines)
    {
        var machines = new List<Machine>();
        foreach (var line in lines)
        {
            // [.##.] (3) (1,3) (2) (2,3) (0,2) (0,1) {3,5,4,7}
            // first is [], all in (), then {} as last index, ^1 is index from end
            var split = line.Split(" ");
            var lightGoal = Sanitize(split[0]);
            var rawButtonArray = split[1..^1].Split(" ").Source;
            var buttons = new List<int[]>();
            foreach (var button in rawButtonArray)
            {
                var sanitizedButton = Sanitize(button).Split(",").Select(int.Parse).ToArray();
                buttons.Add(sanitizedButton);
            }
            var joltage = Sanitize(split[^1]).Split(",").Select(int.Parse).ToArray();
            machines.Add(new Machine(lightGoal, buttons, joltage));
        }
        
        return machines;
    }
    
    public static string Sanitize(string input)
    {
        var charsToRemove = new HashSet<char> { '[', ']', '{', '}', '(', ')' };
        return string.Concat(input.Where(c => !charsToRemove.Contains(c)));
        
        // for best performance use the below
        /*Span<char> buffer = stackalloc char[input.Length];
        var index = 0;
        foreach (char c in input)
        {
            if (c != '[' && c != ']' && c != '{' && c != '}' && c != '(' && c != ')')
            {
                buffer[index++] = c;
            }
        }
    
        return new string(buffer[..index]);*/
    }
}