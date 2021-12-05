namespace AdventOfCode.Puzzles;

public class Day5
{
    public int Puzzle1()
    {
        return GetPoints(GetRanges(ReadLines()))
            .GroupBy(p => p)
            .Count(g => g.Count() >= 2);
    }

    IEnumerable<Point> GetPoints(IEnumerable<Range> ranges)
    {
        foreach (var ((x1, y1), (x2, y2)) in ranges)
        {
            if (y1 == y2)
            {
                for (var x = Math.Min(x1, x2); x <= Math.Max(x1, x2); x++)
                {
                    yield return new Point(x, y1);
                }
            }

            if (x1 == x2)
            {
                for (var y = Math.Min(y1, y2); y <= Math.Max(y1, y2); y++)
                {
                    yield return new Point(x1, y);
                }
            }
        }
    }

    IEnumerable<Range> GetRanges(IEnumerable<string> lines)
    {
        return
            from line in lines
            let startPart = line[..line.IndexOf(" ")].Split(',').Select(int.Parse)
            let startPoint = new Point(startPart.First(), startPart.Last())
            let endPart = line[(line.LastIndexOf(" ") + 1)..].Split(',').Select(int.Parse)
            let endPoint = new Point(endPart.First(), endPart.Last())
            let range = new Range(startPoint, endPoint)
            where range.Start.X == range.End.X || range.Start.Y == range.End.Y
            select range;
    }

    IEnumerable<string> ReadLines()
    {
        return Routines.ReadInputLines(nameof(Day5));
    }
}

record Point(int X, int Y);

record Range(Point Start, Point End);