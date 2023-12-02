using Microsoft.Extensions.Logging;

namespace AdventOfCode.Solutions.Day02;

[Solution("Day02", "Part1")]
public class Day02Part1 : Day02
{
    private readonly ILogger<Day02Part1> _logger;
    public Day02Part1(ILogger<Day02Part1> logger) => _logger = logger;

    protected override void RunPart(List<CubeGame> games)
    {
        var matchingGames = games
            .Where(game =>
                game[Red] <= 12 &&
                game[Green] <= 13 &&
                game[Blue] <= 14
            )
            .Select(g => g.GameID)
            .Sum(); // TIL! How long has this existed?? :shocked_pika:
        
        _logger.LogInformation("The sum of the IDs of matching games is [{matchingGames}].", matchingGames);
    }
}