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

    // is incorrect
    public override int PartTwo(string input)
    {
        var lines = input.ToEnumerableString().ToArray();
        var rules = lines.Where(x => x.Contains('|')).Select(rule => rule.Split('|')).ToArray();
        var updates = lines.Where(x => !x.Contains('|')).Select(update => update.Split(',').ToList()).ToList();

        // Parse the rules into a graph representation
        var graph = new Dictionary<string, List<string>>();
        var inDegree = new Dictionary<string, int>();

        foreach (var rule in rules)
        {
            var firstPage = rule[0];
            var secondPage = rule[1];

            if (!graph.ContainsKey(firstPage)) graph[firstPage] = new List<string>();
            if (!inDegree.ContainsKey(firstPage)) inDegree[firstPage] = 0;
            if (!inDegree.ContainsKey(secondPage)) inDegree[secondPage] = 0;

            graph[firstPage].Add(secondPage);
            inDegree[secondPage]++;
        }

        // Function to topologically sort a subgraph
        List<string> TopologicalSort(List<string> pages)
        {
            var subGraph = new Dictionary<string, List<string>>();
            var subInDegree = new Dictionary<string, int>();

            // Build the subgraph using only the pages in the current update
            foreach (var page in pages)
            {
                if (!subGraph.ContainsKey(page)) subGraph[page] = new List<string>();
                if (!subInDegree.ContainsKey(page)) subInDegree[page] = 0;
            }

            foreach (var page in pages)
            {
                if (!graph.ContainsKey(page)) continue;

                foreach (var neighbor in graph[page])
                {
                    if (!pages.Contains(neighbor)) continue;

                    subGraph[page].Add(neighbor);
                    subInDegree[neighbor]++;
                }
            }

            // Perform topological sort using Kahn's algorithm
            var queue = new Queue<string>();
            foreach (var page in pages)
            {
                if (subInDegree[page] == 0) queue.Enqueue(page);
            }

            var sortedList = new List<string>();
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                sortedList.Add(current);

                foreach (var neighbor in subGraph[current])
                {
                    subInDegree[neighbor]--;
                    if (subInDegree[neighbor] == 0) queue.Enqueue(neighbor);
                }
            }

            return sortedList;
        }

        // Reorder incorrect updates and calculate the middle page sum
        var middleSum = 0;
        foreach (var update in updates)
        {
            var sortedUpdate = TopologicalSort(update);

            // Find the middle page and add to the sum
            if (sortedUpdate.Count > 0)
            {
                var middleIndex = (sortedUpdate.Count - 1) / 2;
                middleSum += Convert.ToInt32(sortedUpdate[middleIndex]);
            }
        }

        return middleSum;
    }
}