using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInterface1
{
    internal class MyDerived1 : MyBase1, IDisposable
    {
        new public void Dispose()
        {
            Console.WriteLine("Derived Dispose");
        }

        void IDisposable.Dispose()
        {
            Console.WriteLine("IDisposable Dispose");
        }
    }
}
