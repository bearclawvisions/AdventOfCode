using System.Text.RegularExpressions;

namespace AdventOfCode._2024;

public class Y202404 : AoCBase
{
    private static List<(int, int)> _locationOfA = new();

    
    public override int PartOne(string input)
    {
        var lines = input.ToEnumerableString().ToArray();
        const string target = "XMAS";

        var sum = CountWordOccurrences(lines, target);

        return sum;
    }
    
    private static int CountWordOccurrences(string[] grid, string target)
    {
        int rows = grid.Length;
        int cols = grid[0].Length;
        int count = 0;

        int[][] directions =
        [
            [0, 1],  // Right
            [0, -1], // Left
            [1, 0],  // Down
            [-1, 0], // Up
            [1, 1],  // Diagonal Down-Right
            [1, -1], // Diagonal Down-Left
            [-1, 1], // Diagonal Up-Right
            [-1, -1] // Diagonal Up-Left
        ];

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                count += directions.Count(dir => IsWordAt(grid, target, row, col, dir[0], dir[1]));
            }
        }

        return count;
    }
    
    private static bool IsWordAt(string[] grid, string word, int startRow, int startCol, int rowDir, int colDir)
    {
        int rows = grid.Length;
        int cols = grid[0].Length;
        
        var locationOfA = (0, 0);

        for (int i = 0; i < word.Length; i++)
        {
            int newRow = startRow + i * rowDir;
            int newCol = startCol + i * colDir;

            // find the next letter in the grid and compensate for out of range of the grid
            if (newRow < 0 || newRow >= rows || newCol < 0 || newCol >= cols || grid[newRow][newCol] != word[i])
            {
                return false;
            }
            
            if (word[i] == 'A')
            {
                locationOfA = (newRow, newCol);
            }
        }
        
        _locationOfA.Add(locationOfA);
        return true;
    }

    public override int PartTwo(string input)
    {
        var lines = input.ToEnumerableString().ToArray();
        var sum = CountXMASOccurrences(lines);
        
        return sum;
    }
    
    private static int CountXMASOccurrences(string[] grid)
    {
        int rows = grid.Length;
        int cols = grid[0].Length;
        int count = 0;

        // Iterate over every possible center point of the X
        for (int row = 1; row < rows - 1; row++)
        {
            for (int col = 1; col < cols - 1; col++)
            {
                if (IsXMASAt(grid, row, col))
                {
                    count++;
                }
            }
        }

        return count;
    }

    private static bool IsXMASAt(string[] grid, int centerRow, int centerCol)
    {
        string[] possibleMAS = ["MAS", "SAM"];

        foreach (var mas1 in possibleMAS)
        {
            foreach (var mas2 in possibleMAS)
            {
                // Check diagonals forming the X
                if (MatchesPattern(grid, mas1, centerRow - 1, centerCol - 1, 1, 1) && // Top-left to bottom-right
                    MatchesPattern(grid, mas2, centerRow + 1, centerCol - 1, -1, 1))   // Bottom-left to top-right
                {
                    return true;
                }
            }
        }

        return false;
    }

    private static bool MatchesPattern(string[] grid, string pattern, int startRow, int startCol, int rowDir, int colDir)
    {
        int rows = grid.Length;
        int cols = grid[0].Length;

        for (int i = 0; i < pattern.Length; i++)
        {
            int newRow = startRow + i * rowDir;
            int newCol = startCol + i * colDir;

            if (newRow < 0 || newRow >= rows || newCol < 0 || newCol >= cols || grid[newRow][newCol] != pattern[i])
            {
                return false;
            }
        }

        return true;
    }
}
