namespace AdventOfCode.Puzzles;

public class Day1
{
    public int Puzzle1()
    {
        return Solution(GetInputs(), range: 1);
    }

    public int Puzzle2()
    {
        return Solution(GetInputs(), range: 3);
    }
    
    int Solution(int[] inputs, int range)
    {
        return inputs
            .Zip(inputs[range..])
            .Count(x => x.Second > x.First);
    }

    int[] GetInputs()
    {
        return Routines.ReadInputLines(nameof(Day1)).Select(int.Parse).ToArray();
    }
}