using Microsoft.Extensions.Logging;

namespace AdventOfCode.Solutions.Day05;

[Solution("Day05", "Part2")]
public class Day05Part2 : Day05
{
    private readonly ILogger _logger;
    public Day05Part2(ILogger<Day05Part2> logger) => _logger = logger;

    protected override void RunPart(Almanac almanac)
    {
        // Group seeds into ranges
        var seedRanges = almanac.Seeds
            .Chunk(2)
            .Select(points => new MapRange(points[0], points[0], points[1]))
            .ToList();
        
        // Produce a fake "map" of input seed to mapping seed.
        // This simplifies the code by letting us reuse the same function.
        var seedMap = new Map
        {
            Source = "seed",
            Destination = "seed",
            Ranges = seedRanges.ToList() // make a copy - it's mutable
        };
        
        // Slice apart the map ranges until each seed range maps to exactly one location.
        // Then, we only need to test one value from the whole range.
        SliceRanges(almanac, seedMap, almanac["seed"]); 
        
        // The slicing process can actually add new ranges that weren't in the input.
        // We need to check them against the original list to make sure that we don't run out of bounds.
        var closestLocation = seedMap.Ranges
            .Where(mr => seedRanges.Any(or => mr.Source >= or.Source && mr.SourceEnd <= or.SourceEnd))
            .Select(seed => almanac.Translate("seed", "location", seed.Source))
            .Min();
        
        _logger.LogInformation("The lowest location that needs a seed is [{closestLocation}].", closestLocation);
    }

    private static void SliceRanges(Almanac almanac, Map sourceMap, Map targetMap)
    {
        // Slice target at start / end of each source range
        var targetPointsInSource = sourceMap.Ranges.SelectMany(r => r.DestinationPoints);
        foreach (var point in targetPointsInSource)
        {
            targetMap.SliceSource(point);
        }
        
        // Recurse in the middle.
        // We want to make sure that all changes are propagated.
        if (almanac.Maps.TryGetValue(targetMap.Destination, out var nextTarget))
            SliceRanges(almanac, targetMap, nextTarget);
        
        // Slice source at start / end of each target range
        var sourcePointsInTarget = targetMap.Ranges.SelectMany(r => r.SourcePoints);
        foreach (var point in sourcePointsInTarget)
        {
            sourceMap.SliceDestination(point);
        }
    }
}