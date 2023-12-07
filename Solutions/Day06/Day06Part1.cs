using AdventOfCode.Util;
using Microsoft.Extensions.Logging;

namespace AdventOfCode.Solutions.Day06;

[Solution("Day06", "Part1")]
public class Day06Part1 : Day06
{
    private readonly ILogger _logger;
    public Day06Part1(ILogger<Day06Part1> logger) => _logger = logger;
    
    
    public override void Run(string inputFile)
    {
        var result = ParseRaces(inputFile)
            .Select(r => r.CountWaysToWin())
            .Product();
        
        _logger.LogInformation("The product of the number of ways to win in all races is [{result}].", result);
    }
    
    private static List<BoatRace<int>> ParseRaces(string inputFile)
    {
        var lines = inputFile.SplitByEOL();
        
        var times = Expressions.Numbers()
            .Matches(lines[0])
            .Select(m => int.Parse(m.Value));
        var distances = Expressions.Numbers()
            .Matches(lines[1])
            .Select(m => int.Parse(m.Value));
        
        return times.Zip(distances)
            .Select(column => new BoatRace<int>(column.First, column.Second))
            .ToList();
    }
}