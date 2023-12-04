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


    /// <summary>
    ///     Matches engine part numbers OR symbols.
    ///     Use <see cref="Match.Index"/> to get the byte offset.
    ///     If group 1 is set, then this is a number.
    ///     If group 2 is set, then this is a part.
    /// </summary>
    /// <remarks>
    ///     Make sure to examine the first line separately - it's important to collect two pieces of information:
    ///     * The length of the line
    ///     * The length of the break between lines (usually 1 or 2 characters)
    /// </remarks>
    [GeneratedRegex(@"(\d+)|([^\d\s\.])")]
    public static partial Regex SchematicMarkings();
}