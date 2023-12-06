using AdventOfCode.Inputs;
using AdventOfCode.Util;

namespace AdventOfCode.Solutions.Day05;

[InputFile(NamedInputs.Day05)]
[InputFile(NamedInputs.Day05Test1, InputFileType.Test)]
public abstract class Day05 : ISolution
{
    public void Run(string inputFile)
    {
        var almanac = ParseAlmanac(inputFile);
        RunPart(almanac);
    }
    
    private static Almanac ParseAlmanac(string inputFile)
    {
        var fileParts = inputFile.SplitByTwoEOL();
        return new Almanac
        {
            Seeds = Expressions.Numbers()
                .Matches(fileParts[0])
                .Select(match => long.Parse(match.Value))
                .ToList(),
            
            Maps = fileParts
                .Skip(1)
                .Select(ParseMap)
                .ToDictionary(map => map.Source)
        };
    }
    
    private static Map ParseMap(string mapPart)
    {
        var keyMatch = Expressions.MapKeys().Match(mapPart);
        return new Map
        {
            Source = keyMatch.Groups[1].Value,
            Destination = keyMatch.Groups[2].Value,
            
            Ranges = Expressions.Numbers()
                .Matches(mapPart)
                .Chunk(3)
                .Select(matches =>
                {
                    var destination = long.Parse(matches[0].Value);
                    var source = long.Parse(matches[1].Value);
                    var length = long.Parse(matches[2].Value);
                    return new MapRange(source, destination, length);
                })
                .ToList()
        };
    }

    protected abstract void RunPart(Almanac almanac);
}