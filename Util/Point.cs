using System.Numerics;

namespace AdventOfCode.Util;

/// <summary>
/// Represents a point in 2D cartesian space.
/// Origin (0,0) is the top-left corner.
/// Y axis (row) extends down, and X axis (column) extends right.
/// </summary>
/// <param name="Row">Y position, starting at zero and increasing downward from the top-left corner.</param>
/// <param name="Col">X position, starting at zero and increasing right from the top-left corner.</param>
public readonly record struct Point<TNum>(TNum Row, TNum Col)
    where TNum : IBinaryInteger<TNum>
{
    /// <summary>
    /// Returns a new point that is equal to this point moved by the specified number of positions in either axis.
    /// </summary>
    public Point<TNum> MoveBy(TNum rowOffset, TNum colOffset) => new(Row + rowOffset, Col + colOffset);
    
    public Point<TNum> GetNeighbor(Direction direction) => direction switch
    {
        Direction.Up => this with { Row = Row - TNum.One },
        Direction.Down => this with { Row = Row + TNum.One },
        Direction.Right => this with { Col = Col + TNum.One },
        Direction.Left => this with { Col = Col - TNum.One },
        Direction.None => this,
        _ => throw new ArgumentOutOfRangeException(nameof(direction), "Direction must be a valid value of Direction enum.")
    };

    public IEnumerable<Point<TNum>> Neighbors
    {
        get
        {
            yield return new Point<TNum>(Row: Row - TNum.One, Col: Col - TNum.One);
            yield return new Point<TNum>(Row: Row - TNum.One, Col: Col);
            yield return new Point<TNum>(Row: Row - TNum.One, Col: Col + TNum.One);

            yield return new Point<TNum>(Row: Row, Col: Col - TNum.One);
            yield return new Point<TNum>(Row: Row, Col: Col + TNum.One);

            yield return new Point<TNum>(Row: Row + TNum.One, Col: Col - TNum.One);
            yield return new Point<TNum>(Row: Row + TNum.One, Col: Col);
            yield return new Point<TNum>(Row: Row + TNum.One, Col: Col + TNum.One);
        }
    }

    public override string ToString() => $"({Row}, {Col})";
}

public enum Direction
{
    None,
    Up,
    Down,
    Right,
    Left
}

public static class DirectionExtensions
{
    public static long GetRowOffset(this Direction direction) => direction switch
    {
        Direction.Up => -1,
        Direction.Down => 1,
        Direction.Right => 0,
        Direction.Left => 0,
        Direction.None => 0,
        _ => throw new ArgumentOutOfRangeException(nameof(direction), "Direction must be a valid value of Direction enum.")
    };
    
    public static long GetColumnOffset(this Direction direction) => direction switch
    {
        Direction.Up => 0,
        Direction.Down => 0,
        Direction.Right => 1,
        Direction.Left => -1,
        Direction.None => 0,
        _ => throw new ArgumentOutOfRangeException(nameof(direction), "Direction must be a valid value of Direction enum.")
    };
}