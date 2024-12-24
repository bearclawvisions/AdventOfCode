namespace AdventOfCode._2024;

public class Y202406 : AoCBase
{
    private const char Rubble = '#';
    private bool _hasLeftTheBuilding = false;
    private Direction _move = Direction.Up;
    private string[] _partOneLines = [];
    private (int, int) _guardPos = (0, 0);
    
    public override int PartOne(string input)
    {
        _partOneLines = input.ToEnumerableString().ToArray();
        var sum = 0;
        
        // Find the Guards starting position
        GuardStartingPosition();

        // continue to walk the guard until it has left the building
        while (!_hasLeftTheBuilding) RunSimulation();

        foreach (var line in _partOneLines)
        {
            sum += line.ToCharArray().Count(c => c == 'X');
        }
        
        return sum;
    }

    private void GuardStartingPosition()
    {
        var guardLine = string.Empty;
        var lineCount = 0;
        foreach (var line in _partOneLines)
        {
            if (line.Contains('^'))
            {
                guardLine = line;
                break;
            }
            lineCount++;
        }
        var guardIndex = guardLine.IndexOf('^');
        _guardPos = (lineCount, guardIndex);
    }

    private void RunSimulation()
    {
        switch (_move)
        {
            case Direction.Up: MarkPosition(); _guardPos.Item1--; CheckForRubble(); break;
            case Direction.Down: MarkPosition(); _guardPos.Item1++; CheckForRubble(); break;
            case Direction.Left: MarkPosition(); _guardPos.Item2--; CheckForRubble(); break;
            case Direction.Right: MarkPosition(); _guardPos.Item2++; CheckForRubble(); break;
        }
    }

    private void MarkPosition()
    {
        // Mark position where the guard walked
        var markPosition = _partOneLines[_guardPos.Item1].ToCharArray();
        markPosition[_guardPos.Item2] = 'X';
        _partOneLines[_guardPos.Item1] = new string(markPosition);
    }

    private void CheckForRubble()
    {
        if (_guardPos.Item1 != 0)
        {
            var lineUp = _partOneLines[_guardPos.Item1-1];
            if (_move == Direction.Up && lineUp[_guardPos.Item2] == Rubble && _guardPos.Item1-1 >= 0)
                ChangeDirection();
        }

        if (_guardPos.Item1 != _partOneLines.Length - 1)
        {
            var lineDown = _partOneLines[_guardPos.Item1+1];
            if (_move == Direction.Down && lineDown[_guardPos.Item2] == Rubble && _guardPos.Item1+1 <= _partOneLines.Length-1)
                ChangeDirection();
        }

        if (_guardPos.Item2 != 0)
        {
            var currentLine = _partOneLines[_guardPos.Item1];
            if (_move == Direction.Left && currentLine[_guardPos.Item2-1] == Rubble && _guardPos.Item2-1 >= 0)
                ChangeDirection();
        }

        if (_guardPos.Item2 != _partOneLines[_guardPos.Item1].Length - 1)
        {
            var currentLine = _partOneLines[_guardPos.Item1];
            if (_move == Direction.Right && currentLine[_guardPos.Item2+1] == Rubble && _guardPos.Item2+1 <= currentLine.Length-1)
                ChangeDirection();
        }

        // check if guard goes off the grid
        if (_guardPos.Item2-1 < 0 || _guardPos.Item2+1 > _partOneLines[_guardPos.Item1].Length-1 || _guardPos.Item1-1 < 0 || _guardPos.Item1+1 > _partOneLines.Length-1)
        {
            MarkPosition();
            _hasLeftTheBuilding = true;
        }
    }

    private void ChangeDirection()
    {
        switch (_move)
        {
            case Direction.Up: _move = Direction.Right; break;
            case Direction.Down: _move = Direction.Left; break;
            case Direction.Left: _move = Direction.Up; break;
            case Direction.Right: _move = Direction.Down; break;
        }
    }

    public override int PartTwo(string input)
    {
        var lines = input.ToEnumerableString();
        var sum = 0;

        return sum;
    }
}

public enum Direction
{
    Up, Down, Left, Right
}