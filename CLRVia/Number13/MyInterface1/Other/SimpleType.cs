using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInterface1
{
    internal class SimpleType : IDisposable
    {
        public void Dispose()
        {
            Console.WriteLine("Dispose");
        }

        void IDisposable.Dispose()
        {
            Console.WriteLine("IDisposable.Dispose");
        }
    }
}
