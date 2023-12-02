namespace AdventOfCode.Solutions.Day02;

public class CubeGame
{
    public required int GameID { get; init; }
    
    
    public int this[string color] => _minCounts[color];
    private readonly Dictionary<string, int> _minCounts = new();
    
    
    public void AddSample(string color, int count)
    {
        if (!_minCounts.TryGetValue(color, out var min))
            _minCounts[color] = min = 0;

        _minCounts[color] = Math.Max(min, count);
    } 
}