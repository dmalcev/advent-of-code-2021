namespace AdventOfCode.Puzzles;

public class Day3
{
    public int Puzzle1()
    {
        var matrix = GetMatrix();
        
        var width = matrix[0].Length;
        var half = matrix.Length / 2;
        
        var gammaBin = new char[width];
        var epsilonBin = new char[width];

        var count = 0;
        
        for (var col = 0; col < width; col++)
        {
            foreach (var row in matrix)
            {
                if (row[col] == '1')
                    count++;
                
                if (count > half)
                    break;
            }

            gammaBin[col] = count > half ? '1' : '0';
            epsilonBin[col] = count > half ? '0' : '1';
            count = 0;
        }

        var gammaInt = ToInt(new string(gammaBin));
        var epsilonInt = ToInt(new string(epsilonBin));

        return gammaInt * epsilonInt;
    }

    public int Puzzle1Lines()
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
        var gamma = ToInt(new string(gammaBit));
        
        var epsilonBit = result.Select(x => x > half ? '0' : '1').ToArray();
        var epsilon = ToInt(new string(epsilonBit));

        return gamma * epsilon;
    }

    char[][] GetMatrix()
    {
        return Routines.ReadInputLines(nameof(Day3)).Select(x => x.ToCharArray()).ToArray();
    }

    static int ToInt(string binary)
    {
        return Convert.ToInt32(binary, 2);
    }
}