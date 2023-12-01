using System.Text.RegularExpressions;
using AdventOfCode.Util;
using Microsoft.Extensions.Logging;

namespace AdventOfCode.Solutions.Day01;

[Solution("Day01", "Part2")]
public class Day01Part2 : Day01
{

    public Day01Part2(ILogger<Day01Part2> logger) : base(logger) {}
    
    protected override int GetLineValue(string line)
    {
        // Digits are processed separately to handle overlapping matches
        
        var firstDigit = MapDigit
        (
            Expressions
                .Digits(includingWords: true)
                .Match(line)
                .Value
        );
        var lastDigit = MapDigit
        (
            Expressions
                    // RTL ensures that we get the last match, even if it overlaps.
                    // .NET specific - the RightToLeft feature is not universal among regex engines.
                .Digits(includingWords: true, rightToLeft: true)
                .Match(line)
                .Value
        );
        
        // Concat *then* parse
        return int.Parse(firstDigit + lastDigit);
    }

    // Nothing fancy - let the compiler deal with this.
    private static string MapDigit(string value)
        => value switch
        {
            "one" => "1",
            "two" => "2",
            "three" => "3",
            "four" => "4",
            "five" => "5",
            "six" => "6",
            "seven" => "7",
            "eight" => "8",
            "nine" => "9",
            _ => value
        };
}