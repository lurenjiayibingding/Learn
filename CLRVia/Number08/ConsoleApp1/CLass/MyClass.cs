using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.CLass
{
    internal class MyBaseClass
    {
        private MyStruct myStruct1;

        public MyBaseClass(int x, int y)
        {
            myStruct1.X = x;
            myStruct1.Y = y;
        }
    }

    internal class MyDeriveClass : MyBaseClass
    {
        public MyDeriveClass(int x, int y) : base(x, y)
        {
        }
    }
}
