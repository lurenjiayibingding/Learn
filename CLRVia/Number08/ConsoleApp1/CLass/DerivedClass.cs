using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.CLass
{
    public class DerivedClass : BaseClass
    {
        public override void Method()
        {
            Console.WriteLine("DerivedClass");
        }
    }
}
