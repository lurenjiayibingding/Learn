using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInterface1
{
    internal class MyBase1 : IDisposable
    {
        //这个方法在编译后是密封的虚方法
        public void Dispose()
        {
            Console.WriteLine("Base Dispose");
        }
    }
}
