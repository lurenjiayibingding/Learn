using ConsoleApp1.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Class
{
    internal class Class1 : Interface1
    {
        public virtual string Console()
        {
            //if (string.IsNullOrEmpty(Interface1.Field1))
            //{
            //    return "Field1为空";
            //}
            //else
            //{
            //    return Interface1.Field1;
            //}
            return "class1";
        }
    }
}
