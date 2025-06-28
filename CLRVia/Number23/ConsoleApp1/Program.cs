using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = Assembly.Load("MyStabdardAssembly.dll");
            if (assembly != null)
            {
                foreach (var item in assembly.GetExportedTypes())
                {
                    Console.WriteLine(item.FullName);
                }
            }


            Console.ReadKey();
        }
    }
}
