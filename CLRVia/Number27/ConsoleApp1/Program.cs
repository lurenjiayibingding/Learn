using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> aaa = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var bbb = aaa.OrderBy(n => n).Skip(1).Take(1);
            foreach (int a in bbb)
            {
                Console.WriteLine(a.ToString());
            }

            Console.ReadKey();
        }
    }
}
