namespace AdventOfCode.Puzzles;

public class Day6
{
    public int Puzzle1()
    {
        var states = Routines.ReadInput(nameof(Day6)).Split(',').Select(int.Parse).ToList();

        var addCount = 0;
        
        for (var i = 0; i < 80; i++)
        {
            for (var j = 0; j < states.Count; j++)
            {
                states[j]--;

                if (states[j] == -1)
                {
                    states[j] = 6;
                    addCount++;
                }
            }

            for (var k = 0; k < addCount; k++)
                states.Add(8);
            
            addCount = 0;
        }

        return states.Count;
    }
}