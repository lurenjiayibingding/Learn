using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Class
{
    internal class SimpleType : IDisposable
    {
        public void Dispose()
        {
            Console.WriteLine("SimpleType Dispose");
        }

        void IDisposable.Dispose()
        {
            Console.WriteLine("IDisposable Dispose");
        }
    }
}
