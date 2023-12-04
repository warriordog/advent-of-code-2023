using System.Text.RegularExpressions;
using AdventOfCode.Inputs;
using AdventOfCode.Util;

namespace AdventOfCode.Solutions.Day03;

[InputFile(NamedInputs.Day03)]
[InputFile(NamedInputs.Day03Test1, InputFileType.Test)]
public abstract class Day03 : ISolution
{
    public void Run(string inputFile)
    {
        var schematic = ParseSchematic(inputFile);
        RunPart(schematic);
    }
    
    protected abstract void RunPart(Schematic schematic);

    private static Schematic ParseSchematic(string inputFile)
    {
        var schematic = new Schematic();
        
        var lineLength = inputFile.GetLineLength();
        var matches = Expressions.SchematicMarkings().Matches(inputFile);
        foreach (Match match in matches)
            ParseMarking(match, lineLength, schematic);

        return schematic;
    }
    
    private static void ParseMarking(Match match, int lineLength, Schematic schematic)
    {
        var position = GetMatchPosition(match.Index, lineLength);

        if (match.Groups[1].Success)
            ParsePartNumber(match.Groups[1].Value, position, schematic);

        else if (match.Groups[2].Success)
            ParsePartSymbol(match.Groups[2].Value, position, schematic);

        else
            throw new ArgumentException("Match cannot be parsed to a marking", nameof(match));
    }

    private static void ParsePartNumber(string value, Point<int> position, Schematic schematic)
    {
        var number = int.Parse(value);
        var length = value.Length;
        var partNumber = new PartNumber(position, number, length);
        schematic.AddPartNumber(partNumber);
    }

    private static void ParsePartSymbol(string value, Point<int> position, Schematic schematic)
    {
        var partSymbol = new PartSymbol(position, value);
        schematic.AddPartSymbol(partSymbol);
    }

    private static Point<int> GetMatchPosition(int matchIndex, int lineLength)
        => new()
        {
            Row = matchIndex / lineLength,
            Col = matchIndex % lineLength
        };
}