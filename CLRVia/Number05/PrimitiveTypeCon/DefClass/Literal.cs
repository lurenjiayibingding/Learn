using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimitiveTypeCon.DefClass
{
    internal class Literal
    {
        /// <summary>
        /// int类型的文本常量
        /// </summary>
        public static void IntLiteral()
        {
            bool found=false;//编译之后found为0
            int x = 100 + 200 + 300;//编译之后x为600
            string s = "a" + "b";//编译之后s为"ab"
            string s2=123.ToString() + 456.ToString();//编译之后s2为"123456"
        }
    }
}