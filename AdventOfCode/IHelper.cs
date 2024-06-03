namespace AdventOfCode;

public interface IHelper
{
    IEnumerable<string> GetInputLines(int year, int day);
    string GetInputText(int year, int day);
}