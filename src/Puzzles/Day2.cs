namespace AdventOfCode.Puzzles;

public class Day2
{
    public int Puzzle1()
    {
        var (position, depth, _) = Solution(GetInstructions());        
        return position * depth;
    }

    public int Puzzle2()
    {
        var (position, _, aim) = Solution(GetInstructions());        
        return position * aim;
    }

    (int position, int depth, int aim) Solution(IEnumerable<(string move, int step)> instructions)
    {
        var aim = 0;
        var depth = 0;
        var position = 0;
        
        foreach (var (move, step) in instructions)
        {
            switch (move)
            {
                case "forward":
                    position += step;
                    aim += depth * step;
                    break;
                case "down":
                    depth += step;
                    break;
                case "up":
                    depth -= step;
                    break;
            }
        }

        return (position, depth, aim);
    }

    (string move, int step) ParseInstruction(string line)
    {
        var parts = line.Split(' ');
        return (move: parts[0], step: int.Parse(parts[1]));
    }

    IEnumerable<(string move, int step)> GetInstructions()
    {
        return Routines.ReadInputLines(nameof(Day2)).Select(ParseInstruction);
    }
}