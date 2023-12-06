namespace AdventOfCode.Solutions.Day05;

public class Almanac
{
    public required List<long> Seeds { get; init; }
    
    public required Dictionary<string, Map> Maps { get; init; }
    public Map this[string from] => Maps[from];

    public long Translate(string from, string to, long value)
    {
        for (var map = Maps[from] ;; map = Maps[map.Destination])
        {
            value = map.Translate(value);

            if (map.Destination == to)
                break;
        }

        return value;
    }
}

public class Map
{
    public required string Source { get; init; }
    public required string Destination { get; init; }
    public required List<MapRange> Ranges { get; init; }

    public long SourceMin => Ranges.Select(r => r.Source).Min();
    public long SourceMax => Ranges.Select(r => r.SourceEnd).Max() - 1;

    public long DestinationMin => Ranges.Select(r => r.Destination).Min();
    public long DestinationMax => Ranges.Select(r => r.DestinationEnd).Max() - 1;

    public long Translate(long source)
    {
        var range = Ranges.Find(r => r.Source <= source && r.SourceEnd >= source);
        if (range == null)
            return source;

        return source + range.Delta;
    }

    public void SliceDestination(long at)
    {
        // If at an endpoint, then do nothing
        if (Ranges.Any(r => r.Destination == at || r.DestinationEnd - 1 == at))
            return;
        
        // If out of bounds, then just create a new range to reach it.
        if (at < DestinationMin)
        {
            var length = DestinationMin - at;
            Ranges.Add(new MapRange(at, at, length));
            return;
        }
        if (at > DestinationMax)
        {
            var length = at - DestinationMax;
            Ranges.Add(new MapRange(at, at, length));
            return;
        }

        // If in a gap, then we need to fill it
        var matchingRange = Ranges.Find(r => r.Destination <= at && r.DestinationEnd > at);
        if (matchingRange == null)
        {
            var previous = Ranges
                .Where(r => r.DestinationEnd <= at)
                .MaxBy(r => r.DestinationEnd)
                ?? throw new ApplicationException($"Bug detected: can't find the lower half of a gap at {at}");
            var next = Ranges
                .Where(r => r.Destination > at)
                .MinBy(r => r.Destination)
                ?? throw new AggregateException($"Bug detected: can't find the upper half of a gap at {at}");

            var position = previous.DestinationEnd;
            var length = next.Destination - position;
            
            matchingRange = new MapRange(position, position, length);
            Ranges.Add(matchingRange);
            return;
        }

        // Otherwise, we need to slice
        Ranges.Remove(matchingRange);
        
        var lowerLength = at - matchingRange.Destination;
        Ranges.Add(new MapRange(matchingRange.Source, matchingRange.Destination, lowerLength));
        
        var upperLength = matchingRange.Length - lowerLength;
        Ranges.Add(new MapRange(matchingRange.Source + lowerLength, at, upperLength));
    }

    public void SliceSource(long at)
    {
        // If at an endpoint, then do nothing
        if (Ranges.Any(r => r.Source == at || r.SourceEnd - 1 == at))
            return;
        
        // If out of bounds, then create a new range to reach it.
        if (at < SourceMin)
        {
            var length = SourceMin - at;
            Ranges.Add(new MapRange(at, at, length));
            return;
        }
        if (at > SourceMax)
        {
            var length = at - SourceMax;
            Ranges.Add(new MapRange(at, at, length));
            return;
        }

        // If in a gap, then we need to fill it
        var matchingRange = Ranges.Find(r => r.Source <= at && r.SourceEnd > at);
        if (matchingRange == null)
        {
            var previous = Ranges
               .Where(r => r.SourceEnd <= at)
               .MaxBy(r => r.SourceEnd)
                ?? throw new ApplicationException($"Bug detected: can't find the lower half of a gap at {at}");
            var next = Ranges
                .Where(r => r.Source > at)
                .MinBy(r => r.Source)
                ?? throw new AggregateException($"Bug detected: can't find the upper half of a gap at {at}");

            var position = previous.SourceEnd;
            var length = next.Source - position;
            
            matchingRange = new MapRange(position, position, length);
            Ranges.Add(matchingRange);
            return;
        }

        // Otherwise, we need to slice
        Ranges.Remove(matchingRange);
        
        var lowerLength = at - matchingRange.Source;
        Ranges.Add(new MapRange(matchingRange.Source, matchingRange.Destination, lowerLength));
        
        var upperLength = matchingRange.Length - lowerLength;
        Ranges.Add(new MapRange(at, matchingRange.Destination + lowerLength, upperLength));
    }
}

public sealed record MapRange(long Source, long Destination, long Length)
{
    public long SourceEnd => Source + Length;
    public long DestinationEnd => Destination + Length;
    public long Delta => Destination - Source;

    public long[] SourcePoints { get; } = new[] { Source, Source + Length };
    public long[] DestinationPoints { get; } = new[] { Destination, Destination + Length };

    public override string ToString()
    {
        var delta = Delta < 0
            ? Delta.ToString()
            : $"+{Delta}";
        return $"{Source}-{SourceEnd} {delta}";
    }

    public bool Equals(MapRange? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Source == other.Source && Destination == other.Destination && Length == other.Length;
    }
    public override int GetHashCode() => HashCode.Combine(Source, Destination, Length);
}