using PollyPractice.DefinitionClass;
using System;

namespace PollyPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PollyTest1 test1 = new PollyTest1();
            Console.WriteLine(test1.UsingPolly(-1f).ToString());
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
