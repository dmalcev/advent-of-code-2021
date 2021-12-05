namespace AdventOfCode.Puzzles;

public class Day4
{
    public int Puzzle1()
    {
        var lines = Routines.ReadInputLines(nameof(Day4)).ToArray();
        var numbers = ReadNumbers(lines[0]).ToArray();
        var boards = ReadBoards(lines).ToArray();

        var pos = 0;

        foreach (var number in numbers)
        {
            foreach (var board in boards)
            {
                var index = Array.IndexOf(board, number);
                if (index == -1) continue;

                board[index] = -1;

                if (pos < 5) continue;

                if (IsFullColumn(board, index) || IsFullRow(board, index))
                    return GetScore(board, number);
            }

            pos++;
        }

        return 0;
    }

    public int Puzzle2()
    {
        var lines = Routines.ReadInputLines(nameof(Day4)).ToArray();
        var numbers = ReadNumbers(lines[0]).ToArray();
        var boards = ReadBoards(lines).ToArray();

        var lastScore = 0;

        var pos = 0;

        foreach (var number in numbers)
        {
            foreach (var board in boards)
            {
                if (board[0] == -100) continue;

                var index = Array.IndexOf(board, number);
                if (index == -1) continue;

                board[index] = -1;

                if (pos < 5) continue;

                if (!IsFullColumn(board, index) && !IsFullRow(board, index)) continue;

                lastScore = GetScore(board, number);
                board[0] = -100; // mark as deleted
            }

            pos++;
        }

        return lastScore;
    }

    int GetScore(int[] board, int number)
    {
        var sum = board.Where(x => x != -1).Sum();
        return sum * number;
    }

    bool IsFullColumn(int[] board, int index)
    {
        for (var i = 0; i < 5; i++)
        {
            if (board[index] != -1)
                return false;

            index += 5;
            if (index >= board.Length)
            {
                index %= board.Length;
            }
        }

        return true;
    }

    bool IsFullRow(int[] board, int index)
    {
        for (var i = 0; i < 5; i++)
        {
            if (board[index] != -1)
                return false;

            index++;
            if (index % 5 == 0)
            {
                index = (index / 5 - 1) * 5;
            }
        }

        return true;
    }

    IEnumerable<int> ReadNumbers(string line)
    {
        return line.Split(',').Select(int.Parse);
    }

    IEnumerable<int[]> ReadBoards(string[] lines)
    {
        var chunks = lines.Skip(2).Chunk(6);

        foreach (var chunk in chunks)
        {
            var numbers = chunk
                .SelectMany(line => line.Split(' ', StringSplitOptions.RemoveEmptyEntries))
                .Select(int.Parse)
                .ToArray();

            yield return numbers;
        }
    }
}