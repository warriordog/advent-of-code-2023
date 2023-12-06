using AdventOfCode.Inputs;
using AdventOfCode.Util;

namespace AdventOfCode.Solutions.Day04;

[InputFile(NamedInputs.Day04)]
[InputFile(NamedInputs.Day04Test1, InputFileType.Test)]
public abstract class Day04 : ISolution
{
    public void Run(string inputFile)
    {
        var scratchCards = ParseScratchCards(inputFile);
        RunPart(scratchCards);
    }

    protected abstract void RunPart(List<ScratchCard> card);

    private static List<ScratchCard> ParseScratchCards(string inputFile)
        => Expressions.ScratchCardNumbers()
            .Matches(inputFile)
            .Select(m => new ScratchCard
                {
                    CardNumber = int.Parse(m.Groups[1].ValueSpan),
                    WinningNumbers = Expressions.Numbers()
                        .Matches(m.Groups[2].Value)
                        .Select(wn => int.Parse(wn.ValueSpan))
                        .ToArray(),
                    YourNumbers = Expressions.Numbers()
                        .Matches(m.Groups[3].Value)
                        .Select(wn => int.Parse(wn.ValueSpan))
                        .ToArray()
                }
            )
            .ToList();
}