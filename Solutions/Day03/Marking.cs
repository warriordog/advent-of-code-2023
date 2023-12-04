using AdventOfCode.Util;

namespace AdventOfCode.Solutions.Day03;

public abstract record Marking(Point<int> Position);
public record PartNumber(Point<int> Position, int Number, int Length) : Marking(Position);
public record PartSymbol(Point<int> Position, string Symbol) : Marking(Position);