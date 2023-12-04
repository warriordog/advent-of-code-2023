using Microsoft.Extensions.Logging;

namespace AdventOfCode.Solutions.Day03;

[Solution("Day03", "Part1")]
public class Day03Part1 : Day03
{
    private readonly ILogger<Day03Part1> _logger;
    public Day03Part1(ILogger<Day03Part1> logger) => _logger = logger;
    
    protected override void RunPart(Schematic schematic)
    {
        var partNumberSum = schematic.Parts.Keys
            .Select(pn => pn.Number)
            .Sum();
        
        _logger.LogInformation("The sum of all the part numbers is [{partNumberSum}].", partNumberSum);
    }
}