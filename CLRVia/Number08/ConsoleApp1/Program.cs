// See https://aka.ms/new-console-template for more information
using ConsoleApp1.CLass;
using System.Runtime.CompilerServices;

//MyStruct myStruct = new MyStruct();

internal class Program
{
    private static void Main(string[] args)
    {
        Int32 a = 0;
        a.ToString();

        Console.WriteLine(typeof(Int32).Assembly.FullName);

        MyBaseClass myBaseClass = new MyBaseClass(100, 100);

        //var base2 = Object.MemberwiseClone(myBaseClass);

        Console.WriteLine("Hello, World!");
    }
}