using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    class Program
    {
        static void Main(string[] args)
        {
            var t1 = Type.GetType("MyDLL1.MyClass1,MyDLL1");
            var t2 = Type.GetType("MyClass1,MyDLL1");
            Console.ReadKey();
        }
    }
}
