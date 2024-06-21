using System.Diagnostics;

namespace Async;

public class Workbench
{

    public async Task Serial()
    {
        var sw = new Stopwatch();
        sw.Start();

        Console.WriteLine(await TaskExpensive.With2S(sw));
        Console.WriteLine(await TaskExpensive.With5S(sw));
        Console.WriteLine(await TaskExpensive.With10S(sw));
        
        sw.Stop();

        Console.WriteLine($"Serial: {sw.Elapsed}");
    }

    // Wait all tasks is completed
    public async Task ParallelWithWhenAll()
    {
        var sw = new Stopwatch();
        sw.Start();

        var tasks = new[]
        {
            TaskExpensive.With2S(sw), TaskExpensive.With5S(sw), TaskExpensive.With10S(sw)
        };

        await Task.WhenAll(tasks);
        
        foreach (var completedTask in tasks)
        {
            Console.WriteLine($"Task completed in {completedTask.IsCompleted} at {sw.Elapsed} returning {completedTask.Result}");
        }
        
        sw.Stop();

        Console.WriteLine($"ParallelWithWhenAll: {sw.Elapsed}");
    }
    
    // Like ParallelWithWhenAll
    public Task ParallelWithWaitAll()
    {
        var sw = new Stopwatch();
        sw.Start();

        Task<int>[] tasks = {
            TaskExpensive.With2S(sw), TaskExpensive.With5S(sw), TaskExpensive.With10S(sw)
        };

        Task.WaitAll(tasks);
        
        foreach (var completedTask in tasks)
        {
            Console.WriteLine($"Task completed in {completedTask.IsCompleted} at {sw.Elapsed} returning {completedTask.Result}");
        }
        
        sw.Stop();

        Console.WriteLine($"ParallelWithWaitAll: {sw.Elapsed}");
        
        return Task.CompletedTask;
    }
    
    public async Task ParallelWithWhenAny()
    {
        var sw = new Stopwatch();
        sw.Start();

        var tasks = new List<Task<int>>
        {
            TaskExpensive.With2S(sw), TaskExpensive.With5S(sw), TaskExpensive.With10S(sw)
        };

        while (tasks.Count > 0)
        {
            var completedTask = await Task.WhenAny(tasks);
            tasks.Remove(completedTask);
            
            Console.WriteLine($"Task completed in {completedTask.IsCompleted} at {sw.Elapsed} returning {completedTask.Result}");
        }

        sw.Stop();
        Console.WriteLine($"ParallelWithWhenAny: {sw.Elapsed}");
    }

}