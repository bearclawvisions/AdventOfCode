using System.Numerics;

namespace AdventOfCode._2025;

public class Y202504 : AoCBase
{
    private readonly record struct Coords(int X, int Y);
    
    private static readonly Coords[] Directions =
    [
        new(0, 1),  // Right
        new(0, -1), // Left
        new(1, 0),  // Down
        new(-1, 0), // Up
        new(1, 1),  // Diagonal Down-Right
        new(1, -1), // Diagonal Down-Left
        new(-1, 1), // Diagonal Up-Right
        new(-1, -1) // Diagonal Up-Left
    ];
    
    private static int _rows = 0;
    private static int _columns = 0;
    
    public override string PartOne(string input)
    {
        var lines = input.ToArrayInput();
        _rows = lines.Length;
        _columns = lines[0].Length;
        
        var accessibleRolls = AccessibleRolls(lines);
        
        return accessibleRolls.ToString();
    }

    public override string PartTwo(string input)
    {
        var lines = input.ToArrayInput();
        _rows = lines.Length;
        _columns = lines[0].Length;
        
        var totalAccessibleRolls = 0;
        int removed;

        do
        {
            removed = AccessibleRolls(lines, true);
            totalAccessibleRolls += removed;
        } while (removed != 0);
        
        return totalAccessibleRolls.ToString();
    }

    private static int AccessibleRolls(string[] grid, bool partTwo = false)
    {
        var count = 0;
        for (int row = 0; row < _rows; row++)
        {
            for (int col = 0; col < _columns; col++)
            {
                if (grid[row][col] == '.') // not a roll, no need to check
                    continue;
                
                // if it is a roll '@' see if it has less than four adjacent rolls in any direction
                if (HasLessThanFourAdjacentRolls(grid, row, col, partTwo))
                    count++;
            }
        }

        return count;
    }
    
    private static bool HasLessThanFourAdjacentRolls(string[] grid, int startRow, int startCol, bool partTwo)
    {
        var rollCount = 0;
        foreach (var direction in Directions)
        {
            var rowCursor = startRow + direction.X;
            var colCursor = startCol + direction.Y;

            // Out of bounds guarding
            if (rowCursor < 0 || rowCursor >= _rows || colCursor < 0 || colCursor >= _columns)
                continue;

            if (grid[rowCursor][colCursor] == '@')
                rollCount++;
        }

        if (partTwo && rollCount < 4)
        {
            // remove the roll from the grid
            var chars = grid[startRow].ToCharArray(); // isolate the row
            chars[startCol] = '.'; // replace the roll with a '.'
            grid[startRow] = new string(chars); // update the grid row
        }

        return rollCount < 4;
    }
}