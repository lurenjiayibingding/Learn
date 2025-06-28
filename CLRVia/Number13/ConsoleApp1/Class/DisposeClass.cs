using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Class
{
    internal class DisposeBase : IDisposable
    {
        public void Dispose()
        {
            Console.WriteLine("Base Dispose");
        }
    }

    internal class DisposeDeriver : DisposeBase, IDisposable
    {
        public new void Dispose()
        {
            Console.WriteLine("Deriver Dispose");
        }
    }
}
