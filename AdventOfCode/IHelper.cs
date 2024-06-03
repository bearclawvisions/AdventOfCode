namespace AdventOfCode;

public interface IHelper
{
    /// <summary>
    /// Get the AoC from a text file as IEnumerable
    /// </summary>
    /// <param name="year">int</param>
    /// <param name="day">int</param>
    IEnumerable<string> GetInputLines(int year, int day);
    
    /// <summary>
    /// Get the AoC from a text file as full text
    /// </summary>
    /// <param name="year">int</param>
    /// <param name="day">int</param>
    string GetInputText(int year, int day);
}