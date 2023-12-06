using Microsoft.Extensions.Logging;

namespace AdventOfCode.Solutions.Day04;

[Solution("Day04", "Part1")]
public class Day04Part1 : Day04
{
    private readonly ILogger _logger;
    public Day04Part1(ILogger<Day04Part1> logger) => _logger = logger;
    
    protected override void RunPart(List<ScratchCard> scratchCards)
    {
        var totalValue = scratchCards
            .Select(ComputeScore)
            .Sum();
        _logger.LogInformation("The total value of the cards is [{totalValue}] points.", totalValue); 
    }

    private static int ComputeScore(ScratchCard card)
    {
        var numMatching = card.CountMatchingNumbers();
        return (int)Math.Pow(2, numMatching - 1);
    }
}