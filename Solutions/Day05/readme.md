# Day 5: If You Give A Seed A Fertilizer

This was so difficult!
Normally, AoC problems require complex parsing *or* involve complex logic, but this one had both.

My solution uses RegEx and LINQ for parsing, with a handful of custom classes to model the data.
I was able to refine the map traversal down to this one method, which I'm a bit proud of:
```csharp
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
```
It ended up being overkill for this problem, but it can navigate from any map to any other (only in one direction though).

Part 1 was simple, just loop and call that one method.
Part 2, however, required a huge overhaul.
My solution is efficient, but weird and hard to explain.
At a high level, it works by finding the breakpoints between each range of each map and then "extending" them through each of the other maps.
When that process is finished, each distinct range of seed IDs will map to exactly one range of location IDs.
The final answer is easily available by testing only one value from each range, which completes in about 25ms.