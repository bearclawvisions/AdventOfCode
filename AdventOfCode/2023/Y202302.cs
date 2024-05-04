namespace AdventOfCode._2023;

public class Y202302(IHelper helper)
{
    private int redMax = 12;
    private int greenMax = 13;
    private int blueMax = 14;

    public void Run()
    {
        // Part One
        Console.WriteLine("Part One: " + GameOfCubes());

        // Part Two
        Console.WriteLine("Part Two: " + PowerOfTheCubes());
    }

    private int GameOfCubes()
    {
        var inputPath = helper.GetInputFilePath(2023, 2);
        using var reader = new StreamReader(inputPath);
        var line = reader.ReadLine();
        var possibleGames = new List<int>();
        
        while (!string.IsNullOrWhiteSpace(line))
        {
            var splitGame = line.Split(":");
            var gameNumber = int.Parse(splitGame[0].Split(" ")[1]);
            var splitSubGames = splitGame[1].Split(";");
            var possibleSubgame = CheckSubGame(splitSubGames);
            
            if (possibleSubgame)
                possibleGames.Add(gameNumber);

            line = reader.ReadLine();
        }
        reader.Close();
        
        return possibleGames.Sum();
    }
    
    private int PowerOfTheCubes()
    {
        var inputPath = helper.GetInputFilePath(2023, 2);
        using var reader = new StreamReader(inputPath);
        var line = reader.ReadLine();
        var cubePower = new List<int>();
        
        while (!string.IsNullOrWhiteSpace(line))
        {
            var splitGame = line.Split(":");
            var splitSubGames = splitGame[1].Split(";");
            var subgamePower = SubgamePower(splitSubGames);
            cubePower.Add(subgamePower);

            line = reader.ReadLine();
        }
        reader.Close();
        
        return cubePower.Sum();
    }

    private bool CheckSubGame(IEnumerable<string> subgames)
    {
        var possibleSubgame = true;
        foreach (var subGame in subgames)
        {
            var splitCubes = subGame.Split(",");
            // Whitespace is in the split too as first [0], hence [2] and [1]
            var cubeDict = splitCubes.Select(cube => cube.Split(" "))
                .ToDictionary(cube => cube[2], amount => int.Parse(amount[1]));
            
            foreach (var cube in cubeDict)
            {
                switch (cube.Key)
                {
                    case "red" when cube.Value > redMax:
                    case "green" when cube.Value > greenMax:
                    case "blue" when cube.Value > blueMax:
                        possibleSubgame = false;
                        break;
                }
            }
        }

        return possibleSubgame;
    }
    
    private int SubgamePower(string[] subgames)
    {
        var minRedCubes = 0;
        var minGreenCubes = 0;
        var minBlueCubes = 0;
        
        foreach (var subGame in subgames)
        {
            var splitCubes = subGame.Split(",");
            var cubeDict = splitCubes.Select(cube => cube.Split(" "))
                .ToDictionary(cube => cube[2], amount => int.Parse(amount[1]));
            
            foreach (var cube in cubeDict)
            {
                switch (cube.Key)
                {
                    case "red" when cube.Value > minRedCubes:
                        minRedCubes = cube.Value;
                        break;
                    case "green" when cube.Value > minGreenCubes:
                        minGreenCubes = cube.Value;
                        break;
                    case "blue" when cube.Value > minBlueCubes:
                        minBlueCubes = cube.Value;
                        break;
                }
            }
        }

        return minRedCubes * minGreenCubes * minBlueCubes;
    }
}