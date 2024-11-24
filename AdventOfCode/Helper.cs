namespace AdventOfCode;

public class Helper : IHelper
{
    public object GetInput(InputType inputType)
    {
        switch (inputType)
        {
            case InputType.Lines: return GetInputLines();
            case InputType.FullText: return GetInputText();
        }
        return "Could not get input";
    }
    
    private IEnumerable<string> GetInputLines()
    {
        var filePath = GetInputFilePath();
        return File.ReadAllLines(filePath);
    }
    
    private string GetInputText()
    {
        var filePath = GetInputFilePath();
        return File.ReadAllText(filePath);
    }
    
    private string GetInputFilePath()
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

public enum InputType
{
    Lines,
    FullText,
}