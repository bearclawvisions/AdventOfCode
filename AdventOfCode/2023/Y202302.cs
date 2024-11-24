namespace AdventOfCode._2023;

public class Y202302(IHelper _helper) : AoCBase
{
    private int redMax = 12;
    private int greenMax = 13;
    private int blueMax = 14;

    protected override object GetInputFromFile() { return _helper.GetInput(InputType.Lines); }

    public override int PartOne(object input)
    {
        var possibleGames = new List<int>();

        foreach (var line in (IEnumerable<string>)input)
        {
            var splitGame = line.Split(":");
            var gameNumber = int.Parse(splitGame[0].Split(" ")[1]);
            var splitSubGames = splitGame[1].Split(";");
            var possibleSubgame = CheckSubGame(splitSubGames);

            if (possibleSubgame)
                possibleGames.Add(gameNumber);
        }

        return possibleGames.Sum();
    }

    public override int PartTwo(object input)
    {
        var cubePower = new List<int>();

        foreach (var line in (IEnumerable<string>)input)
        {
            var splitGame = line.Split(":");
            var splitSubGames = splitGame[1].Split(";");
            var subgamePower = SubgamePower(splitSubGames);
            cubePower.Add(subgamePower);
        }

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