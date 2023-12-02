using System.Text.RegularExpressions;
using AdventOfCode.Inputs;
using AdventOfCode.Util;

namespace AdventOfCode.Solutions.Day02;

[InputFile(NamedInputs.Day02)]
[InputFile(NamedInputs.Day02Test1, InputFileType.Test)]
public abstract class Day02 : ISolution
{
    // No more fucking copy/paste errors :rage:
    protected const string Red = "red";
    protected const string Green = "green";
    protected const string Blue = "blue";

    public void Run(string inputFile)
    {
        var games = ReadGames(inputFile);
        RunPart(games);
    }

    private static List<CubeGame> ReadGames(string inputFile)
        => inputFile
            .SplitByEOL()
            .SkipEmptyStrings()
            .Select(ReadGame)
            .ToList();
    
    private static CubeGame ReadGame(string line)
    {
        var match = Expressions.CubeGameInfo().Match(line);
        var gameId = int.Parse(match.Groups[1].Value);
        var game = new CubeGame
        {
            GameID = gameId
        };

        var countString = match.Groups[2].Value;
        ReadCounts(countString, game);

        return game;
    }
    
    private static void ReadCounts(string countString, CubeGame game)
    {
        var counts = Expressions.CubeCounts().Matches(countString);
        foreach (Match match in counts)
        {
            ReadCount(game, match);
        }
    }
    
    private static void ReadCount(CubeGame game, Match countMatch)
    {
        var count = int.Parse(countMatch.Groups[1].Value);
        var color = countMatch.Groups[2].Value;
        game.AddSample(color, count);
    }

    protected abstract void RunPart(List<CubeGame> games);
}