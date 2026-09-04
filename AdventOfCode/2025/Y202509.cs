using System.Numerics;

namespace AdventOfCode._2025;

public class Y202509 : AoCBase
{
    private record Rectangle(long Top, long Left, long Bottom, long Right);
    
    public override string PartOne(string input)
    {
        var lines = input.ToArrayInput();
        var points = GetVector2Points(lines);
        var grids = CalculatePossibleGrids(points);
        
        return grids.Max().ToString();
    }

    public override string PartTwo(string input)
    {
        var lines = input.ToArrayInput();
        var points = GetVector2Points(lines).ToArray();
        
        // create boundary segment of the polygon formed by red tiles
        var segments = Boundary(points).ToArray();
    
        // all possible rectangles, ordered by largest first. We want biggest possible rect inside segment
        var orderedRectangles = RectanglesOrderedByArea(points).ToArray();
        foreach (var rect in orderedRectangles)
        {
            var hasCollision = false;
            
            // check if the rect collides with any of the boundary segments
            foreach (var segment in segments)
            {
                if (AabbCollision(rect, segment))
                {
                    hasCollision = true;
                    break;
                }
            }
        
            // if no collision outside boundary, then it is a valid rectangle
            if (!hasCollision)
                return Area(rect).ToString();
        }
        
        return base.PartTwo(input);
    }

    private List<Vector2> GetVector2Points(string[] lines)
    {
        var points = new List<Vector2>();
        foreach (var line in lines)
        {
            var split = line.Split(',');
            var point = new Vector2(float.Parse(split[0]), float.Parse(split[1]));
            points.Add(point);
        }
        
        return points;
    }

    private List<long> CalculatePossibleGrids(List<Vector2> points)
    {
        var gridSizes = new List<long>();

        for (int current = 0; current < points.Count; current++)
        {
            for(int other = current + 1; other < points.Count; other++)
            {
                gridSizes.Add(Area(current, other, points));
            }
        }

        return gridSizes;
    }

    private List<Rectangle> Boundary(Vector2[] corners)
    {
        var result = new List<Rectangle>();
        var previousCorners = new List<Vector2> { corners.Last() }; // init with last corner to close the loop of polygon: [D, A, B, C, D]
        previousCorners.AddRange(corners);
    
        for (int i = 0; i < corners.Length; i++)
        {
            result.Add(RectangleFromPoints(previousCorners[i], corners[i]));
        }
    
        return result;
    }
    
    private List<Rectangle> RectanglesOrderedByArea(Vector2[] points)
    {
        var rectangles = new List<(Rectangle rect, long area)>();
    
        foreach (var p1 in points)
        {
            foreach (var p2 in points)
            {
                var rectangle = RectangleFromPoints(p1, p2);
                var area = Area(rectangle);
                rectangles.Add((rectangle, area));
            }
        }
    
        rectangles.Sort((a, b) => b.area.CompareTo(a.area)); // descending order
    
        return rectangles
            .Where(x => x.area > 0)
            .Select(x => x.rect)
            .ToList();
    }
        
    private Rectangle RectangleFromPoints(Vector2 p1, Vector2 p2)
    {
        var top = Math.Min(p1.Y, p2.Y);
        var bottom = Math.Max(p1.Y, p2.Y);
        var left = Math.Min(p1.X, p2.X);
        var right = Math.Max(p1.X, p2.X);
        
        return new Rectangle((long)top, (long)left, (long)bottom, (long)right);
    }
    
    private long Area(Rectangle rect) => (rect.Bottom - rect.Top + 1) * (rect.Right - rect.Left + 1);
    
    private long Area(int current, int other, List<Vector2> points)
    {
        // plus 1 because we want to include the point itself in the rectangle, otherwise it is the distance
        var startPoint = points[current] + Vector2.One;
                
        var width = (long)Math.Abs(startPoint.X - points[other].X);
        var height = (long)Math.Abs(startPoint.Y - points[other].Y);

        return width * height;
    }
    
    private bool AabbCollision(Rectangle a, Rectangle b)
    {
        // https://kishimotostudios.com/articles/aabb_collision/
        // rect a compared to b
        var aToTheRight = a.Left >= b.Right;
        var aToTheLeft = a.Right <= b.Left;
        var aAbove = a.Bottom <= b.Top;
        var aBelow = a.Top >= b.Bottom;
        
        return !(aToTheRight || aToTheLeft || aAbove || aBelow);
    }
}