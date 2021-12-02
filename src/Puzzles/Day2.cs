namespace AdventOfCode.Puzzles;

public class Day2
{
    public int Puzzle1()
    {
        var lines = Routines.ReadInputLines(nameof(Day2));

        var depth = 0;
        var position = 0;
        
        foreach (var line in lines)
        {
            var (move, step) = ParseInstruction(line);
            
            switch (move)
            {
                case "forward":
                    position += step;
                    break;
                case "down":
                    depth += step;
                    break;
                case "up":
                    depth -= step;
                    break;
            }
        }
        
        return depth * position;
    }

    public int Puzzle2()
    {
        var lines = Routines.ReadInputLines(nameof(Day2));

        var aim = 0;
        var depth = 0;
        var position = 0;
        
        foreach (var line in lines)
        {
            var (move, step) = ParseInstruction(line);
            
            switch (move)
            {
                case "forward":
                    position += step;
                    depth += aim * step;
                    break;
                case "down":
                    aim += step;
                    break;
                case "up":
                    aim -= step;
                    break;
            }
        }
        
        return depth * position;
    }

    (string move, int step) ParseInstruction(string line)
    {
        var parts = line.Split(' ');
        return (move: parts[0], step: int.Parse(parts[1]));
    }
}