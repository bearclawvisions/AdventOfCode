using System.Text.RegularExpressions;

namespace AdventOfCode._2024;

public class Y202404 : AoCBase
{
    public override int PartOne(string input)
    {
        var lines = input.ToEnumerableString().ToArray();
        var target = "XMAS";

        var sum = CountWordOccurrences(lines, target);

        static int CountWordOccurrences(string[] grid, string target)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;
            int count = 0;

            int[][] directions = {
                new[] { 0, 1 },  // Right
                new[] { 0, -1 }, // Left
                new[] { 1, 0 },  // Down
                new[] { -1, 0 }, // Up
                new[] { 1, 1 },  // Diagonal Down-Right
                new[] { 1, -1 }, // Diagonal Down-Left
                new[] { -1, 1 }, // Diagonal Up-Right
                new[] { -1, -1 } // Diagonal Up-Left
            };

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    foreach (var dir in directions)
                    {
                        if (IsWordAt(grid, target, row, col, dir[0], dir[1]))
                        {
                            count++;
                        }
                    }
                }
            }

            return count;
        }

        static bool IsWordAt(string[] grid, string word, int startRow, int startCol, int rowDir, int colDir)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;

            for (int i = 0; i < word.Length; i++)
            {
                int newRow = startRow + i * rowDir;
                int newCol = startCol + i * colDir;

                if (newRow < 0 || newRow >= rows || newCol < 0 || newCol >= cols || grid[newRow][newCol] != word[i])
                {
                    return false;
                }
            }

            return true;
        }


        return sum;
    }

    public override int PartTwo(string input)
    {
        var lines = input.ToEnumerableString();
        var sum = 0;

    
        return sum;
    }
}