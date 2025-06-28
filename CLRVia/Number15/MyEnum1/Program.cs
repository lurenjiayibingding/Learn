using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEnum1
{
    class Program
    {
        static void Main(string[] args)
        {
            //StructPerson p = new StructPerson();
            //ClassPerson p2 = new ClassPerson();

            //Type t1 = Enum.GetUnderlyingType(typeof(Color));
            //Console.WriteLine(t1.FullName);
            //t1 = typeof(Color2).GetEnumUnderlyingType();
            //Console.WriteLine(t1.FullName);

            //Console.WriteLine(Color.Blue);//"Blue"(常规格式)
            //Console.WriteLine(Color.Blue.ToString());//"Blue"(常规格式)
            //Console.WriteLine(Color.Blue.ToString("G"));//"Blue"(常规格式)
            //Console.WriteLine(Color.Blue.ToString("D"));//"3"(十进制格式)
            //Console.WriteLine(Color.Blue.ToString("X"));//"00000003"(十六进制格式)
            //Console.WriteLine(((Color)6).ToString("F"));//Green,Orange

            //Color c1 = (Color)Enum.Parse(typeof(Color), "Orange");
            //Console.WriteLine(c1.ToString("D"));//4

            //Color c1 = (Color)Enum.Parse(typeof(Color), "oRange");//抛出异常，异常信息：未找到请求的值“oRange”

            //Color c1;
            //if (Enum.TryParse<Color>("Orange", out c1))
            //{
            //    Console.WriteLine(c1.ToString("D"));//4
            //}

            //Color c1;
            //if (Enum.TryParse<Color>("oRange", out c1))
            //{
            //    Console.WriteLine(c1.ToString("D"));//4
            //}
            //Console.WriteLine(c1.ToString("D"));//0

            //var array = Enum.GetValues(typeof(Color));
            //Console.WriteLine(array.GetType().FullName);//Color[]

            byte b = 4;
            Color c1 = (Color)Enum.ToObject(typeof(Color), b);
            Console.WriteLine(c1.ToString("G"));//Orange


            //Console.WriteLine(Enum.Format(typeof(Color), 3, "G"));

            //Console.WriteLine(Action.All.ToString("D"));
            //Console.WriteLine(Action.All.ToString("X"));

            //Action a = new Action();
            //a.HasFlag()

            Console.ReadKey();
        }
    }
}
