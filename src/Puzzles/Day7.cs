namespace AdventOfCode.Puzzles;

public class Day7
{
    public long Puzzle1()
    {
        var inputs = Routines.ReadInput(nameof(Day7)).Split(",").Select(int.Parse);
        return FindMinFuel(inputs, false);
    }

    public long Puzzle2()
    {
        var inputs = Routines.ReadInput(nameof(Day7)).Split(",").Select(int.Parse);
        return FindMinFuel(inputs, true);
    }

    int FindMinFuel(IEnumerable<int> inputs, bool stepsGrow)
    {
        var groups = inputs
            .GroupBy(x => x)
            .Select(g => new Group(g.Key, g.Count()))
            .ToList();

        var start = groups.Min(x => x.Key);
        var end = groups.Max(x => x.Key);

        var minFuel = -1;
        
        for (var i = start; i <= end; i++)
        {
            var fuel = 0;
            
            foreach (var (source, count) in groups)
            {
                var distance = Math.Abs(source - i);
                var increment = stepsGrow
                    ? distance * (distance + 1) / 2
                    : distance;
                
                fuel += increment * count;
                
                if (minFuel != -1 && fuel > minFuel) break;
            }

            if (minFuel == -1 || fuel < minFuel) minFuel = fuel;
        }

        return minFuel;
    }

    record Group(int Key, int Count);
}