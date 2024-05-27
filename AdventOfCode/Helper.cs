namespace AdventOfCode;

public class Helper : IHelper
{
    public IEnumerable<string> GetInput(int year, int day)
    {
        var filePath = GetInputFilePath(year, day);
        return File.ReadAllLines(filePath);
    }
    
    private string GetInputFilePath(int year, int day)
    {
        var solutionRoot = GetSolutionRootDirectory();
        var relativePath = Path.Combine("AdventOfCode", year.ToString(), string.Concat(year, day.ToString("00")) + "input.txt");
        
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