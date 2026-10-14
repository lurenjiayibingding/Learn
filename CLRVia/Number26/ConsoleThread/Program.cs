// See https://aka.ms/new-console-template for more information

//int[] someArray = new int[5] { 1, 2, 3, 4, 5 };
//var lastElement = someArray[0..^1];
//foreach (var item in lastElement)
//{
//    Console.WriteLine(item);
//}

using CoreConsoleThread.Definition;
using CoreConsoleThread.Types;


//ThreadPoolPractice tp1 = new ThreadPoolPractice();
//tp1.PushQueUserWorkItem();

//StartModel s = new StartModel();
//s.StartWithCancellationToken();

//CreateOptions cp = new CreateOptions();
//cp.CreateHierarchyTask();

//TaskContinue tc = new TaskContinue();
//tc.CreateContinue();

//TaskCancel.CancelTask();

//var te = new TaskException();
////await te.Start();
//te.TaskCancelState();

var output = new OutputContent();
await output.OutPut(@"C:\Users\liujiguang\Desktop\面试.txt");


Console.WriteLine("Hello, World!");
Console.ReadKey();