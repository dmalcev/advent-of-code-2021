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

            var x = x1;
            var y = y1;

            while (x1 == x2 && y != y2 || y1 == y2 && x != x2 || x != x2 && y != y2)
            {
                yield return new Point(x, y);

                if (x != x2)
                {
                    x += x < x2 ? 1 : -1;
                }

                if (y != y2)
                {
                    y += y < y2 ? 1 : -1;
                }
            }

            yield return new Point(x, y);
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
            select new Range(startPoint, endPoint);
    }

    IEnumerable<string> ReadLines()
    {
        return Routines.ReadInputLines(nameof(Day5));
    }
}

record Point(int X, int Y);

record Range(Point Start, Point End);