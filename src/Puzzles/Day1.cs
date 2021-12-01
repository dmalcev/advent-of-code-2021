namespace AdventOfCode.Puzzles;

public class Day1
{
    public int Puzzle1()
    {
        var inputs = Routines.ReadInputLines(nameof(Day1)).Skip(1).Select(int.Parse);

        var increments = 0;
        var prev = 0;
        
        foreach (var curr in inputs)
        {
            if (curr > prev)
                increments++;
            
            prev = curr;
        }

        return increments;
    }

    public int Puzzle2()
    {
        var inputs = Routines.ReadInputLines(nameof(Day1)).Select(int.Parse).ToArray();

        var increments = 0;
        var currWindow = 0;
        
        for (var i = 0; i < inputs.Length; i++)
        {
            if (i < 3)
            {
                currWindow += inputs[i];
                continue;
            }

            var nextWindow = currWindow - inputs[i - 3] + inputs[i];
            if (nextWindow > currWindow)
                increments++;

            currWindow = nextWindow;
        }
        
        return increments;
    }
    
    public int Puzzle2Linq()
    {
        var inputs = Routines.ReadInputLines(nameof(Day1)).Select(int.Parse);

        var increments = 0;
        var currWindow = 0;
        var index = 0;
        var starts = new Queue<int>(3);
        
        foreach (var input in inputs)
        {
            if (index < 3)
            {
                starts.Enqueue(input);
                currWindow += input;
            }
            else
            {
                var nextWindow = currWindow - starts.Dequeue() + input;
                if (nextWindow > currWindow)
                    increments++;

                currWindow = nextWindow;
                starts.Enqueue(input);
            }

            index++;
        }
        
        return increments;
    }
}