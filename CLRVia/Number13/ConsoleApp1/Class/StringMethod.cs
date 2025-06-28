using System.Collections;

namespace ConsoleApp1.Class
{
    internal class StringMethod
    {
        public void InvokeStringMethod()
        {
            string s = "随便一串字符串";

            //cloneable变量可以调用ICloneable接口中和Object类型中定义的所有方法
            ICloneable cloneable = s;
            cloneable.Clone();

            //comparable变量可以调用IComparable接口中和Object类型中定义的所有方法
            IComparable comparable = s;
            comparable.CompareTo(s);

            //enumable变量可以调用IEnumerable接口中和Object类型中定义的所有方法
            //并且在运行中可以将一个变量从一种接口类型转为另一接口类型，只要该对象实现了这两种接口即可
            IEnumerable enumable = (IEnumerable)comparable;
            enumable.GetEnumerator();
        }
    }
}
