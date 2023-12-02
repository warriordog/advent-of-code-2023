using System.Text.RegularExpressions;

namespace AdventOfCode.Util;

/// <summary>
/// Generates high-performance Regular Expressions at compile-time
/// </summary>
public static partial class Expressions
{
    [GeneratedRegex(@"\d")]
    private static partial Regex DigitsWithoutWords();

    [GeneratedRegex(@"\d|one|two|three|four|five|six|seven|eight|nine")]
    private static partial Regex DigitsIncludingWords();

    [GeneratedRegex(@"\d|one|two|three|four|five|six|seven|eight|nine", RegexOptions.RightToLeft)]
    private static partial Regex DigitsIncludingWordsRTL();

    public static Regex Digits(bool includingWords = false, bool rightToLeft = false)
        => includingWords switch
        {
            true => rightToLeft
                ? DigitsIncludingWordsRTL()
                : DigitsIncludingWords(),
            
            // This matches individual characters, so RTL is irrelevant.
            false => DigitsWithoutWords()
        };
    
    [GeneratedRegex(@"^Game (\d+): (.*)$")]
    public static partial Regex CubeGameInfo();

    
    [GeneratedRegex(@"(\d+) (red|green|blue)+")]
    public static partial Regex CubeCounts();
}