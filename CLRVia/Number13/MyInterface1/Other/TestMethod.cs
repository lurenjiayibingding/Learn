using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInterface1
{
    public class TestMethod
    {
        public void Method1()
        {
            MyBase1 b = new MyBase1();
            b.Dispose();
            ((IDisposable)b).Dispose();
            //上面两行均输出：Base Dispose

            MyDerived1 d = new MyDerived1();
            d.Dispose();
            ((IDisposable)d).Dispose();
            //上面两行均输出：Derived Dispose

            b = new MyDerived1();
            b.Dispose();
            ((IDisposable)b).Dispose();
            //上面两行分别输出：Base Dispose和Derived Dispose
        }
    }
}
