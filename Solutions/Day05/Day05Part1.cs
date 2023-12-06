using Microsoft.Extensions.Logging;

namespace AdventOfCode.Solutions.Day05;

[Solution("Day05", "Part1")]
public class Day05Part1 : Day05
{
    private readonly ILogger _logger;
    public Day05Part1(ILogger<Day05Part1> logger) => _logger = logger;
    
     
    protected override void RunPart(Almanac almanac)
    {
        var closestLocation = almanac.Seeds
            .Select(seed => almanac.Translate("seed", "location", seed))
            .Min();
        
        _logger.LogInformation("The lowest location that needs a seed is [{closestLocation}].", closestLocation);
    }
}