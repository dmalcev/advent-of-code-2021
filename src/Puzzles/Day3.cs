using System.Text;

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

        var gammaBits = new StringBuilder();
        var epsilonBits = new StringBuilder();
        
        foreach (var c in result)
        {
            if (c > half)
            {
                gammaBits.Append('1');
                epsilonBits.Append('0');
            }
            else
            {
                gammaBits.Append('0');
                epsilonBits.Append('1');
            }
        }
        
        var gamma = Convert.ToInt32(gammaBits.ToString(), 2);
        var epsilon = Convert.ToInt32(epsilonBits.ToString(), 2);

        return gamma * epsilon;
    }

    public int Puzzle2()
    {
        var lines = Routines.ReadInputLines(nameof(Day3)).ToArray();
        var length = lines[0].Length;

        var oxygen = GetValue(lines, length, '1');
        var co2 = GetValue(lines, length, '0');

        return oxygen * co2;
    }

    int GetValue(string[] lines, int length, char bit)
    {
        var i = 0;
        
        while (lines.Length > 1)
        {
            var col = lines.Select(l => l[i]).ToArray();
            var half = col.Length / 2;
            var count = col.Count(x => x == '1');

            var rightBit = bit switch
            {
                '1' => count > half ? '1' : '0',
                '0' => count > half ? '0' : '1',
                _ => throw new Exception()
            };

            if (col.Length % 2 == 0 && count == half)
                rightBit = bit;

            lines = lines.Where(l => l[i] == rightBit).ToArray();

            i++;
        }

        return Convert.ToInt32(lines[0], 2);
    }
}

