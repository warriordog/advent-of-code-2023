namespace AdventOfCode.Solutions.Day04;

public class ScratchCard
{
    public required int CardNumber { get; init; }
    public required int[] WinningNumbers { get; init; }
    public required int[] YourNumbers { get; init; }
    
    public int CountMatchingNumbers() => YourNumbers.Intersect(WinningNumbers).Count();
}