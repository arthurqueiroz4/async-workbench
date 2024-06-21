using Async;

var wb = new Workbench();

await wb.Serial();

Console.WriteLine();

await wb.ParallelWithWhenAll();

Console.WriteLine();

await wb.ParallelWithWaitAll();

Console.WriteLine();

await wb.ParallelWithWhenAny();

Console.WriteLine();

await wb.ParallelWithForeachWait();