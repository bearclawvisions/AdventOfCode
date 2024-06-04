using System.Collections;

namespace AdventOfCode._2023;

public class Y202304(IHelper helper) : AoCBase
{
    private static int _totalCards = 0;

    protected override object GetInputFromFile() { return helper.GetInputLines(2023, 4); }

    public override int PartOne(object input)
    {
        var totalPoints = 0;
        foreach (var line in (IEnumerable<string>)input)
        {
            var splitCardNumber = line.Split(":");
            var winningNumbers = splitCardNumber[1].Split("|")[0]
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
            
            var lotteryNumbers = splitCardNumber[1].Split("|")[1]
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();

            totalPoints += CheckWinningNumbers(winningNumbers, lotteryNumbers);
        }

        return totalPoints;
    }

    public override int PartTwo(object input)
    {
        // cardNo, winningNo[], lotteryNo[]
        var scratchCards = new List<Tuple<int, List<int>, List<int>>>();
        foreach (var line in (IEnumerable<string>)input)
        {
            var splitCardNumber = line.Split(":");
            var cardNumber = int.Parse(splitCardNumber[0].Split(" ", StringSplitOptions.RemoveEmptyEntries)[1]);
            var winningNumbers = splitCardNumber[1].Split("|")[0]
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
            
            var lotteryNumbers = splitCardNumber[1].Split("|")[1]
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
            
            scratchCards.Add(new Tuple<int, List<int>, List<int>>(cardNumber, winningNumbers, lotteryNumbers));
        }
        CheckCards(scratchCards);
        
        return _totalCards;
    }

    private static void CheckCards(List<Tuple<int, List<int>, List<int>>> scratchCards)
    {
        var cardMatches = scratchCards.Select(card => (card.Item1, card.Item3.Intersect(card.Item2).Count())).ToDictionary();
        foreach (var match in cardMatches)
        {
            AddCard(match.Key, cardMatches);
        }
    }

    private static void AddCard(int cardNo, Dictionary<int, int> cardMatches)
    {
        _totalCards++;
        if (!cardMatches.ContainsKey(cardNo) || cardMatches[cardNo] == 0) return;
        for (var i = cardNo + 1; i <= cardNo + cardMatches[cardNo]; i++)
        {
            AddCard(i, cardMatches);
        }
    }

    private static int CheckWinningNumbers(List<int> winningNumbers, List<int> lotteryNumbers)
    {
        var matchingNumbers = lotteryNumbers.Intersect(winningNumbers).Count();
        switch (matchingNumbers)
        {
            case 0:
                return 0;  // no points
            case 1:
                return 1; // 1 match, 1 point
        }

        var cardPoints = 1;
        while (matchingNumbers > 1)  // first match not doubled
        {
            cardPoints *= 2;
            matchingNumbers--;
        }

        return cardPoints;
    }
}