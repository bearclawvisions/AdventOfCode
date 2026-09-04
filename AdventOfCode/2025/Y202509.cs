using System.Numerics;

namespace AdventOfCode._2025;

public class Y202509 : AoCBase
{
    public override string PartOne(string input)
    {
        var lines = input.ToArrayInput();
        var points = new List<Vector2>();

        foreach (var line in lines)
        {
            var split = line.Split(',');
            var point = new Vector2(float.Parse(split[0]), float.Parse(split[1]));
            points.Add(point);
        }
        
        var grids = CalculatePossibleGrids(points);
        
        return grids.Max().ToString();
    }

    private List<long> CalculatePossibleGrids(List<Vector2> points)
    {
        var gridSizes = new List<long>();

        for (int current = 0; current < points.Count; current++)
        {
            for(int other = current + 1; other < points.Count; other++)
            {
                // plus 1 because we want to include the point itself in the rectangle, otherwise it is the distance
                var startPoint = points[current] + Vector2.One;
                
                var width = (long)Math.Abs(startPoint.X - points[other].X);
                var height = (long)Math.Abs(startPoint.Y - points[other].Y);
                gridSizes.Add(width * height);
            }
        }

        return gridSizes;
    }
}