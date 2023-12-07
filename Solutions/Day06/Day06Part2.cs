using AdventOfCode.Util;
using Microsoft.Extensions.Logging;

namespace AdventOfCode.Solutions.Day06;

[Solution("Day06", "Part2")]
public class Day06Part2 : Day06
{
    private readonly ILogger _logger;
    public Day06Part2(ILogger<Day06Part2> logger) => _logger = logger;

    public override void Run(string inputFile)
    {
        var race = ParseRace(inputFile);
        var result = race.CountWaysToWin();
        
        _logger.LogInformation("There are [{result}] ways to win.", result);
    }
    
    private static BoatRace<long> ParseRace(string inputFile)
    {
        var lines = inputFile.SplitByEOL();
        var time = long.Parse(
            string.Join("",
                Expressions.Numbers().Matches(lines[0])
            )
        );
        var distance = long.Parse(
            string.Join("",
                Expressions.Numbers().Matches(lines[1])
            )
        );
        return new BoatRace<long>(time, distance);
    }
}