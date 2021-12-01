namespace AdventOfCode;

internal static class Routines
{
    public static IEnumerable<string> ReadInputLines(string inputFileName)
    {
        var filePath = GetFilePath(inputFileName);
        using var reader = new StreamReader(filePath);

        string? line;
        while ((line = reader.ReadLine()) != null)
        {
            yield return line;
        }
    }

    public static string ReadInput(string inputFileName)
    {
        var filePath = GetFilePath(inputFileName);
        return File.ReadAllText(filePath);
    }

    private static string GetFilePath(string inputFileName)
    {
        const string inputsDir = "Inputs";
        return Path.Combine(inputsDir, $"{inputFileName}.txt");
    }
}
