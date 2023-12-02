using Microsoft.Extensions.Logging;

namespace AdventOfCode.Solutions.Day02;

[Solution("Day02", "Part2")]
public class Day02Part2 : Day02
{
    private readonly ILogger<Day02Part2> _logger;
    public Day02Part2(ILogger<Day02Part2> logger) => _logger = logger;
    
    protected override void RunPart(List<CubeGame> games)
    {
        var gamePower = games
            .Select(game => game[Red] * game[Green] * game[Blue])
            .Sum();
        
        _logger.LogInformation("The sum of the powers of matching games is [{gamePower}].", gamePower);
    }
}