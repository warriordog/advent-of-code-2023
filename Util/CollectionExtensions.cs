namespace AdventOfCode.Util;

public static class CollectionExtensions
{
    public static IEnumerable<T> EnumerateRange<T>(this IList<T> list, int startIndex, int length)
    {
        if (startIndex < 0)
            throw new ArgumentOutOfRangeException(nameof(startIndex), "Start index must be at least zero");
        if (startIndex >= list.Count)
            throw new ArgumentOutOfRangeException(nameof(startIndex), "Start index must be less than the size of the list.");
        if (length < 0)
            throw new ArgumentOutOfRangeException(nameof(length), "Length must be at least zero");

        var endIndex = startIndex + length;
        if (endIndex > list.Count)
            throw new ArgumentException("The total size of startIndex + length must not exceed the bounds of the list");
        
        for (var i = startIndex; i < endIndex; i++)
        {
            yield return list[i];
        }
    }
    
    public static IEnumerable<T> EnumerateRangeLoose<T>(this IList<T> list, int start, int count)
    {
        if (count < 0)
            throw new ArgumentOutOfRangeException(nameof(count), "Count must be at least zero");

        var startAt = Math.Max(0, start);
        var endBefore = Math.Min(list.Count, startAt + count);
        
        for (var i = startAt; i < endBefore; i++)
        {
            yield return list[i];
        }
    }
}