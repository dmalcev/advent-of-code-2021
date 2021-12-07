namespace AdventOfCode.Puzzles;

public class Day7
{
    public long Puzzle1()
    {
        var inputs = Routines.ReadInput(nameof(Day7)).Split(",").Select(int.Parse).ToList();
        return FindMinFuel(inputs, false);
    }

    public long Puzzle2()
    {
        var inputs = Routines.ReadInput(nameof(Day7)).Split(",").Select(int.Parse).ToList();
        return FindMinFuel(inputs, true);
    }

    int FindMinFuel(List<int> positions, bool stepsGrow)
    {
        var fuels =
            from target in Enumerable.Range(1, positions.Max() - positions.Min() + 1)
            let posFuel =
                from pos in positions
                let distance = Math.Abs(pos - target)
                let fuel = stepsGrow ? distance * (distance + 1) / 2 : distance
                select fuel
            select posFuel.Sum();

        return fuels.Min();
    }
}