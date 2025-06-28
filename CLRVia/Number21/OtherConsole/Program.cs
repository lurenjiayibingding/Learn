using OtherConsole.MyClass;
using System;

namespace OtherConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            MyCompare.ComperBySpan(new int[] { 1, 2, 3, 4 }, new int[] { 2, 3, 4, 5 });

            Console.WriteLine("Hello World!");
        }
    }
}