using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StandardLib;

namespace FrameworkLib
{
    public class FrameworkPrint
    {
        public void Print()
        {
            Console.WriteLine(typeof(string).Assembly.FullName);
            Console.WriteLine(typeof(int).Assembly.FullName);
            Console.WriteLine(typeof(bool).Assembly.FullName);
            Console.WriteLine(typeof(List<>).Assembly.FullName);

            Utils.PrintAssemblyNames();
        }
    }
}
