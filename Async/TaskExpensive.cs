using System.Diagnostics;

namespace Async;

public static class TaskExpensive
{

    public static async Task<int> With2S(Stopwatch sw)
    {
        Console.WriteLine($"2 seconds started at {sw.Elapsed}");
        await Task.Delay(2 * 1000);
        Console.WriteLine($"2 seconds ended at {sw.Elapsed}");
        return 2;
    }
    
    public static async Task<int> With5S(Stopwatch sw)
    {
        Console.WriteLine($"5 seconds started at {sw.Elapsed}");
        await Task.Delay(5 * 1000);
        Console.WriteLine($"5 seconds ended at {sw.Elapsed}");
        return 5;
    }
    
    public static async Task<int> With10S(Stopwatch sw)
    {
        Console.WriteLine($"10 seconds started at {sw.Elapsed}");
        await Task.Delay(10 * 1000);
        Console.WriteLine($"10 seconds ended at {sw.Elapsed}");
        return 10;
    }
}