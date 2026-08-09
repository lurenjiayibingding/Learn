using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.CLass
{
    public class BaseClass
    {
        private int _a;
        private int _b = 10;
        private string _c;
        private string _d = "Default Value";


        public BaseClass(int a, int b, string c, string d)
        {
            _a = a;
            _b = b;
            _c = c;
            _d = d;
        }


        public virtual void Method()
        {
            Console.WriteLine("BaseClass");
        }
    }
}
