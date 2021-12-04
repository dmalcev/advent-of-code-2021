namespace AdventOfCode.Puzzles;

public class Day4
{
    public int Puzzle1()
    {
        var lines = Routines.ReadInputLines(nameof(Day4)).ToArray();

        var numbers = ReadNumbers(lines);
        var boards = ReadBoards(lines);

        for (var i = 0; i < numbers.Length; i++)
        {
            var number = numbers[i];

            foreach (var board in boards)
            {
                for (var row = 0; row < 5; row++)
                {
                    for (var col = 0; col < 5; col++)
                    {
                        if (board[row, col] != number) continue;

                        board[row, col] = -1;

                        if (i >= 5 && IsWinner(board, row, col))
                            return CalculateScore(board, number);
                    }
                }
            }
        }

        return 0;
    }

    int CalculateScore(int[,] board, int number)
    {
        var sum = 0;
        for (var i = 0; i < 5; i++)
        {
            for (var j = 0; j < 5; j++)
            {
                if (board[i, j] != -1)
                    sum += board[i, j];
            }
        }

        return sum * number;
    }

    bool IsWinner(int[,] board, int row, int col)
    {
        return IsWinningRow(board, row) || IsWinningColumn(board, col);
    }

    bool IsWinningRow(int[,] board, int row)
    {
        for (var i = 0; i < 5; i++)
        {
            if (board[row, i] != -1)
                return false;
        }

        return true;
    }

    bool IsWinningColumn(int[,] board, int col)
    {
        for (var i = 0; i < 5; i++)
        {
            if (board[i, col] != -1)
                return false;
        }

        return true;
    }

    int[] ReadNumbers(string[] lines)
    {
        return lines[0].Split(',').Select(int.Parse).ToArray();
    }

    List<int[,]> ReadBoards(string[] lines)
    {
        var result = new List<int[,]>();

        var index = 2;
        while (index < lines.Length)
        {
            var board = ReadBoard(lines.Skip(index).Take(5).ToArray());
            result.Add(board);
            index += 6;
        }

        return result;
    }

    int[,] ReadBoard(string[] boardLines)
    {
        var board = new int[5, 5];

        for (var i = 0; i < 5; i++)
        {
            var numbers = boardLines[i].Split(' ').Where(x => x != "").Select(int.Parse).ToArray();
            for (var j = 0; j < 5; j++)
            {
                board[i, j] = numbers[j];
            }
        }

        return board;
    }
}