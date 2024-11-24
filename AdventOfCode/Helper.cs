namespace AdventOfCode;

public static class Helper
{
    public static string GetInput()
    {
        var filePath = GetInputFilePath();
        return File.ReadAllText(filePath);
    }

    public static IEnumerable<string> ToEnumerableString(this string input)
    {
        return input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
    }
    
    private static string GetInputFilePath()
    {
        var solutionRoot = GetSolutionRootDirectory();
        var relativePath = Path.Combine("AdventOfCode", "input.txt");
        
        return Path.Combine(solutionRoot, relativePath);
    }
    
    private static string GetSolutionRootDirectory()
    {
        // Get the directory of the currently executing assembly (usually bin\Debug or bin\Release)
        var assemblyLocation = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

        // Navigate up the directory tree until finding the solution root directory (where *.sln file is located)
        while (assemblyLocation != null && Directory.GetFiles(assemblyLocation, "*.sln").Length == 0)
        {
            assemblyLocation = Directory.GetParent(assemblyLocation)?.FullName;
        }
        
        return assemblyLocation ?? "Unable to find *.sln root...";
    }
}