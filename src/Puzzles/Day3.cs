namespace AdventOfCode.Puzzles;

public class Day3
{
    public int Puzzle1()
    {
        var lines = Routines.ReadInputLines(nameof(Day3));

        var count = 0;
        var result = Array.Empty<int>();
            
        foreach (var line in lines)
        {
            if (result.Length == 0)
                result = new int[line.Length];
            
            for (var i = 0; i < line.Length; i++)
            {
                if (line[i] == '1') result[i]++;
            }

            count++;
        }

        var half = count / 2;
        
        var gammaBit = result.Select(x => x > half ? '1' : '0').ToArray();
        var epsilonBit = result.Select(x => x > half ? '0' : '1').ToArray();
        
        var gamma = ToInt(new string(gammaBit));
        var epsilon = ToInt(new string(epsilonBit));

        return gamma * epsilon;
    }

    public int Puzzle2()
    {
        var lines = Routines.ReadInputLines(nameof(Day3)).ToList();

        
    }

    int ToInt(string binary)
    {
        return Convert.ToInt32(binary, 2);
    }

    bool IsMostCommon(string line, char bit)
    {
        var half = line.Length / 2;
        var count = line.Count(c => c == bit);
        return count > half;
    }
}