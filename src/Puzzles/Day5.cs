namespace AdventOfCode.Puzzles;

public class Day5
{
    public int Puzzle1()
    {
        return GetPoints(GetRanges(ReadLines()), skipDiagonal: true)
            .GroupBy(p => p)
            .Count(g => g.Count() >= 2);
    }

    public int Puzzle2()
    {
        return GetPoints(GetRanges(ReadLines()), skipDiagonal: false)
            .GroupBy(p => p)
            .Count(g => g.Count() >= 2);
    }

    IEnumerable<Point> GetPoints(IEnumerable<Range> ranges, bool skipDiagonal)
    {
        foreach (var ((x1, y1), (x2, y2)) in ranges)
        {
            if (skipDiagonal && x1 != x2 && y1 != y2) continue;

            var xDir = Math.Sign(x2 - x1);
            var yDir = Math.Sign(y2 - y1);

            for (int x = x1, y = y1; x != x2 + xDir || y != y2 + yDir; x += xDir, y += yDir)
            {
                yield return new Point(x, y);
            }
        }
    }

    IEnumerable<Range> GetRanges(IEnumerable<string> lines)
    {
        return
            from line in lines
            let parts = line.Split(" -> ")
            let startPart = parts[0].Split(',').Select(int.Parse)
            let startPoint = new Point(startPart.First(), startPart.Last())
            let endPart = parts[1].Split(',').Select(int.Parse)
            let endPoint = new Point(endPart.First(), endPart.Last())
            select new Range(startPoint, endPoint);
    }

    IEnumerable<string> ReadLines()
    {
        return Routines.ReadInputLines(nameof(Day5));
    }
}

record Point(int X, int Y);

record Range(Point Start, Point End);