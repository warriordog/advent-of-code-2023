using AdventOfCode.Util;

namespace AdventOfCode.Solutions.Day03;

public class Schematic
{
    public IReadOnlyDictionary<PartNumber, PartSymbol> Parts => _parts;
    private readonly Dictionary<PartNumber, PartSymbol> _parts = new();

    public IReadOnlyDictionary<PartSymbol, int> Gears => _gears;
    private readonly Dictionary<PartSymbol, int> _gears = new();

    // We can probably do better with a custom datatype, but I don't have time for that
    private readonly Dictionary<Point<int>, PartNumber> _partNumbers = new();
    private readonly Dictionary<Point<int>, PartSymbol> _partSymbols = new();
    
    public void AddPartSymbol(PartSymbol partSymbol)
    {
        _partSymbols[partSymbol.Position] = partSymbol;
        
        // Attempt to match up parts
        foreach (var neighbor in partSymbol.Position.Neighbors)
        {
            if (_partNumbers.TryGetValue(neighbor, out var partNumber))
            {
                _parts[partNumber] = partSymbol;
            }
        }
        
        // Attempt to match up gears
        CheckGear(partSymbol);
    }

    public void AddPartNumber(PartNumber partNumber)
    {
        // Numbers have to be added at all points
        for (var i = 0; i < partNumber.Length; i++)
        {
            var position = partNumber.Position.MoveBy(0, i);
            _partNumbers[position] = partNumber;
            
            // Attempt to match up parts
            foreach (var neighbor in position.Neighbors)
            {
                if (_partSymbols.TryGetValue(neighbor, out var partSymbol))
                {
                    _parts[partNumber] = partSymbol;
                    CheckGear(partSymbol);
                }
            }
        }
    }

    private void CheckGear(PartSymbol symbol)
    {
        var numbers = new HashSet<PartNumber>();
        foreach (var neighbor in symbol.Position.Neighbors)
        {
            if (_partNumbers.TryGetValue(neighbor, out var number))
            {
                numbers.Add(number);
            }
        }

        // It only counts if there's EXACTLY two
        if (numbers.Count == 2)
            _gears[symbol] = numbers.Aggregate(1, (prod, num) => prod * num.Number);
        
        // We might have previously added this when there were only two numbers.
        else
            _gears.Remove(symbol);
    }
}