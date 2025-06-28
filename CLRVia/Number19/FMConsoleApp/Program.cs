using FMConsoleApp.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMConsoleApp
{
    class Program
    {
        static bool a;
        static void Main(string[] args)
        {
            if (a)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }

            int? b = null;
            Console.WriteLine(b.GetValueOrDefault());

            Nullable<DateTime> c = null;
            Console.WriteLine(c.GetValueOrDefault());


            Nullable<DateTime> d = new Nullable<DateTime>();
            Console.WriteLine(d.GetValueOrDefault());

            MyNullableValue<int> e = new MyNullableValue<int>();
            Console.WriteLine(e.GetValueOrDefault());

            Point? p1 = new Point(10, 10);
            Point? p2 = new Point(20, 20);
            if (p1 == p2)
            {
                Console.WriteLine("相等");
            }
            if (p1 != p2)
            {
                Console.WriteLine("不相等");
            }

            Console.ReadKey();
        }
    }
}
