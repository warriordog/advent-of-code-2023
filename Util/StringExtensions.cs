using System.Text.RegularExpressions;

namespace AdventOfCode.Util;

public static class StringExtensions
{
    private static readonly Regex EOLRegex = new("\r?\n", RegexOptions.Compiled);
    private static readonly Regex TwoEOLRegex = new("\r?\n\r?\n", RegexOptions.Compiled);
    
    public static string[] SplitByTwoEOL(this string str) => TwoEOLRegex.Split(str);
    public static string[][] SplitByTwoThenOneEOL(this string str) => SplitByTwoEOL(str)
        .Select(chunk => EOLRegex.Split(chunk))
        .ToArray();

    public static string[] SplitByEOL(this string str) => EOLRegex.Split(str);

    public static IEnumerable<string> SkipEmptyStrings(this IEnumerable<string> strings) => strings.Where(str => str.Length > 0);
    
    
    public static IEnumerable<string> SplitLazyReverse(this string str, string token)
    {
        if (str.Length == 0)
        {
            yield return str;
        }
        else
        {
            var endIndex = str.Length - 1;
            while (true)
            {
                var nextMatch = str.LastIndexOf(token, endIndex, StringComparison.Ordinal);
                if (nextMatch <= -1)
                {
                    // Yield last section and stop
                    yield return str[..endIndex];
                    break;
                }
                
                // Yield next section and continue
                yield return str[(nextMatch + token.Length)..(endIndex + 1)];
                endIndex = nextMatch - 1;
            } 
        }
    }

    public static IEnumerable<string> SplitLazy(this string str, string token)
    {
        if (str.Length == 0)
        {
            yield return str;
        }
        else
        {
            var startIndex = 0;
            while (true)
            {
                var nextMatch = str.IndexOf(token, startIndex, StringComparison.Ordinal);
                if (nextMatch <= -1)
                {
                    // Yield last section and stop
                    yield return str[startIndex..];
                    break;
                }
                
                // Yield next section and continue
                yield return str[startIndex..nextMatch];
                startIndex = nextMatch + token.Length;
            } 
        }
    }

    /// <summary>
    /// Gets the length of the first line in a string, including line terminators.
    /// Supports any combination of /r/n.
    /// </summary>
    public static int GetLineLength(this string inputString)
    {
        var endOfLinePosition = inputString.IndexOfAny(new[] { '\r', '\n' });
        if (endOfLinePosition < 1)
            throw new ArgumentException("Input string does not have lines", nameof(inputString));

        for (var idx = endOfLinePosition; idx < inputString.Length; idx++)
        {
            var chr = inputString[idx];
            
            // The first non-EOL character is the index of the next line, and also our target length.
            if (chr != '\r' && chr != '\n')
                return idx;
        }

        return inputString.Length;
    }
}