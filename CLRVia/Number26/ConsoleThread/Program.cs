// See https://aka.ms/new-console-template for more information

//int[] someArray = new int[5] { 1, 2, 3, 4, 5 };
//var lastElement = someArray[0..^1];
//foreach (var item in lastElement)
//{
//    Console.WriteLine(item);
//}

using CoreConsoleThread.Definition;

//try
//{
//    Cancel.AutomaticCancelByCancelMethod();
//}
//catch (AggregateException ex)
//{
//    Console.WriteLine(ex.InnerExceptions[0].Message);
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}

try
{
    TaskExplore te = new TaskExplore();
    te.Exception1();
}
catch (AggregateException ex)
{

}
catch (OperationCanceledException ex)
{

}
catch (Exception ex)
{

}

Console.WriteLine("Hello, World!");
Console.ReadKey();
