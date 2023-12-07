using System.Numerics;

namespace AdventOfCode.Solutions.Day06;

public record BoatRace<T>(T TimeLimit, T DistanceRecord)
    where T : INumber<T>
{
    
    public T CountWaysToWin()
    {
        // d = h * (L - h)
        // d = hL - h^2
        // Nevermind, I don't know calculus. We'll just brute force it.
        
        var numWaysToWin = T.Zero;
        for (var holdTime = T.One; holdTime < TimeLimit - T.One; holdTime++)
        {
            var distance = GetDistanceForHoldTime(holdTime);
            
            if (distance <= T.Zero)
                break;
            
            if (distance > DistanceRecord)
                numWaysToWin++;
        }

        return numWaysToWin;
    }
    
    private T GetDistanceForHoldTime(T holdTime)
        => holdTime * (TimeLimit - holdTime);
}