// See https://aka.ms/new-console-template for more information

//int[] someArray = new int[5] { 1, 2, 3, 4, 5 };
//var lastElement = someArray[0..^1];
//foreach (var item in lastElement)
//{
//    Console.WriteLine(item);
//}

using CoreConsoleThread.Types;


ThreadPoolPractice tp1 = new ThreadPoolPractice();
tp1.PushQueUserWorkItem();

//StartModel s = new StartModel();
//s.Start();


Console.WriteLine("Hello, World!");
Console.ReadKey();