namespace AdventOfCode.Puzzles;

public class Day6
{
    public long Puzzle1()
    {
        var inputs = Routines.ReadInput(nameof(Day6)).Split(',').Select(int.Parse).ToList();
        var groups = inputs.GroupBy(x => x).Select(g => new Group(g.Key, g.Count())).ToList();
        var newGroups = new List<Group>();

        for (var i = 0; i < 256; i++)
        {
            foreach (var g in groups)
            {
                g.Key--;
                
                if (g.Key == -1)
                {
                    g.Key = 6;
                    
                    newGroups.Add(new Group(8, g.Count));                    
                }
            }
            
            groups.AddRange(newGroups);
            groups = groups.GroupBy(x => x.Key).Select(g => new Group(g.Key, g.Sum(x => x.Count))).ToList();
            newGroups.Clear();
        }

        return groups.Sum(x => x.Count);
    }

    class Group
    {
        public Group(int key, long count)
        {
            Key = key;
            Count = count;
        }

        public int Key { get; set; }
        public long Count { get; set; }
    }
}