using Microsoft.Extensions.Logging;

namespace AdventOfCode.Solutions.Day03;

[Solution("Day03", "Part2")]
public class Day03Part2 : Day03
{
    private readonly ILogger<Day03Part2> _logger;
    public Day03Part2(ILogger<Day03Part2> logger) => _logger = logger;
    
    protected override void RunPart(Schematic schematic)
    {
        var gearRatioSum = schematic.Gears.Values.Sum();
        _logger.LogInformation("The sum of all the gear ratios is [{gearRatioSum}].", gearRatioSum);
    }
}