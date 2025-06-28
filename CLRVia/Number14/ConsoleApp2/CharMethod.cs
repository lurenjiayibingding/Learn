using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class CharMethod
    {
        public static void UseCharMethod()
        {
            char c = 'A';
            var aaa = c.ToString();

            //c.CompareTo

            var number = char.GetNumericValue(c);
            Console.WriteLine($"字符1的UTF-16码值为:{number.ToString()}");

            var parse = char.Parse("A");
            Console.WriteLine($"Parse转换ABC的结果为:{parse.ToString()}");
        }
    }
}
