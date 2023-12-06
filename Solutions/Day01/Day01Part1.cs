using AdventOfCode.Util;
using Microsoft.Extensions.Logging;

namespace AdventOfCode.Solutions.Day01;

[Solution("Day01", "Part1")]
public class Day01Part1 : Day01
{
    public Day01Part1(ILogger<Day01Part1> logger) : base(logger) {}

    protected override int GetLineValue(string line)
    {
        var digits = Expressions
            .Numbers()
            .Matches(line);
        
        // Concat *then* parse
        var firstDigit = digits.First().Value;
        var lastDigit = digits.Last().Value;
        return int.Parse(firstDigit + lastDigit);
    }
}