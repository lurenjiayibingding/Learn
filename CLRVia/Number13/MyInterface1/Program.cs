using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using MyInterface1.SameMethod;
using MyInterface1.Displayed;

namespace MyInterface1
{
    class Program
    {
        static void Main(string[] args)
        {
            //SimpleType simple = new SimpleType();
            //simple.Dispose();
            ////输出：Dispose

            //IDisposable dispose = (IDisposable)simple;
            //dispose.Dispose();
            ////输出：IDisposable.Dispose

            //string s = "刘彦祖";

            //ICloneable cloneable = s;
            ////使用cloneable变量只能调用由ICloneable接口定义的方法和由Object定义的方法

            //IComparable comparable = s;
            ////使用comparable变量只能调用由IComparable接口定义的方法和由Object定义的方法

            //IEnumerable enumerable = (IEnumerable)comparable;
            ////使用enumerable变量只能调用由IEnumerable接口定义的方法和由Object定义的方法

            //TestMethod m1 = new TestMethod();
            //m1.Method1();

            //MyCompare myCompare = new MyCompare(100, "100");
            //Console.WriteLine(myCompare.CompareTo(200).ToString());
            //Console.WriteLine(myCompare.CompareTo("200").ToString());

            MyClass1 c1 = new MyClass1();

            IWindow w1 = c1;
            w1.GetMeun();
            //输出：I'm IWindow Meun

            IRestaurant r1 = (IRestaurant)c1;
            r1.GetMeun();
            //输出：I'm IRestaurant Meun

            //SomeValueType valueType = new SomeValueType(100);
            //Object o = new object();
            //int r1 = valueType.CompareTo(valueType);
            ////编译时错误
            //int r2 = valueType.CompareTo(o);

            Console.ReadKey();
        }
    }
}
