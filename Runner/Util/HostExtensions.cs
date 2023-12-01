using Microsoft.Extensions.Hosting;

namespace AdventOfCode.Runner.Util;

public static class HostExtensions
{
    public static IAsyncDisposable AsAsyncDisposable(this IHost host) => (IAsyncDisposable)host;
}