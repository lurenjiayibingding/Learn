// See https://aka.ms/new-console-template for more information

//int[] someArray = new int[5] { 1, 2, 3, 4, 5 };
//var lastElement = someArray[0..^1];
//foreach (var item in lastElement)
//{
//    Console.WriteLine(item);
//}

using CoreConsoleThread;
using CoreConsoleThread.Definition;
using CoreConsoleThread.Types;

try
{
    var task = TeskException.ComputeLengthAsync2(null);
    Console.WriteLine("Task 开始执行");

    var result = await task;
}
catch (ArgumentNullException ex)
{
    Console.WriteLine($"捕获到异常: {ex.Message}");
}

Console.WriteLine("Hello, World!");
Console.ReadKey();