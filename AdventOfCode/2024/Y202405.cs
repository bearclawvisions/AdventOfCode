namespace AdventOfCode._2024;

public class Y202405 : AoCBase
{
    public override int PartOne(string input)
    {
        var lines = input.ToEnumerableString().ToArray();
        var rules = lines.Where(x => x.Contains('|')).ToArray();
        var pages = lines.Where(x => !x.Contains('|')).ToArray();

        var sum = 0;
        
        foreach (var page in pages)
        {
            var ruleList = new List<bool>();
            var splitPages = page.Split(',');
            for (int i = 0; i < splitPages.Length; i++)
            {
                var currentPage = splitPages[i];
                ruleList.AddRange(CheckRule(splitPages, currentPage, i, rules));
            }

            if (ruleList.Contains(false)) continue;
            
            // find the middle number and add to sum
            var middle = Convert.ToInt32(Math.Round((double)splitPages.Length / 2 - 1, MidpointRounding.AwayFromZero));
            sum += Convert.ToInt32(splitPages[middle]);
        }
        
        return sum;
    }

    private List<bool> CheckRule(string[] splitPages, string current, int number, string[] rules)
    {
        var ruleList = new List<bool>();
        foreach (var rule in rules)
        {
            var firstPage = rule.Split('|')[0];
            var secondPage = rule.Split('|')[1];
            
            // no matching rule
            var ruleMatch = firstPage.Contains(current);
            if (!ruleMatch) continue;

            // rule doesn't apply
            var secondPageMatch = splitPages.Contains(secondPage);
            if (!secondPageMatch) continue;
            
            // number exists before the current page
            if (splitPages[..number].Contains(secondPage))
            {
                ruleList.Add(false);
                continue;
            }
            
            // var test = splitPages[..number].Contains(secondPage);
            if (splitPages[number..].Contains(secondPage))
            {
                ruleList.Add(true);
            }
        }

        return ruleList;
    }

    public override int PartTwo(string input)
    {
        var lines = input.ToEnumerableString().ToArray();

        
        return 0;
    }
}