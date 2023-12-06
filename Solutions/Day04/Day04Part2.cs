using Microsoft.Extensions.Logging;

namespace AdventOfCode.Solutions.Day04;

[Solution("Day04", "Part2")]
public class Day04Part2 : Day04
{
    private readonly ILogger _logger;
    public Day04Part2(ILogger<Day04Part2 > logger) => _logger = logger;
    
    protected override void RunPart(List<ScratchCard> scratchCards)
    {
        var numCards = CountScratchCards(scratchCards);
        _logger.LogInformation("The final number of scratchcards is [{numCards}] cards.", numCards); 
    }

    private static int CountScratchCards(List<ScratchCard> scratchCards)
    {
        var totalScratchCards = 0;
        var cardMultiplier = 1;
        var multiplierDropPoints = new Dictionary<int, int>();

        var round = 1;
        foreach (var card in scratchCards)
        {
            // Increment score by the modifier from the previous round (before we change it)
            totalScratchCards += cardMultiplier;
            
            // Increase multiplier based on winnings
            var numMatches = card.CountMatchingNumbers();
            if (numMatches > 0)
            {
                var deltaMultiplier = cardMultiplier;
                cardMultiplier += deltaMultiplier;

                var dropIndex = round + numMatches;
                multiplierDropPoints[dropIndex] = multiplierDropPoints.GetValueOrDefault(dropIndex, 0) + deltaMultiplier;
            }
            
            // Drop any expired - MUST happen last!
            if (multiplierDropPoints.TryGetValue(round, out var numToDrop))
            {
                cardMultiplier -= numToDrop;
                multiplierDropPoints.Remove(round);
            }
            
            // Increment round
            round++;
        }

        return totalScratchCards;
    }
}