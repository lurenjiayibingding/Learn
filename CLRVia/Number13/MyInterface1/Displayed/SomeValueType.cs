using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInterface1.Displayed
{
    /// <summary>
    /// 通过显示的实现接口方法在一定程度上解决非泛型方法在编译时的安全性问题
    /// 并且可以减少非预期的装箱
    /// </summary>
    public struct SomeValueType : IComparable
    {
        private int myValue;
        public SomeValueType(int input)
        {
            myValue = input;
        }

        //public int CompareTo(object obj)
        //{
        //    return myValue - ((SomeValueType)obj).myValue;
        //}

        public int CompareTo(SomeValueType obj)
        {
            return myValue - obj.myValue;
        }

        int IComparable.CompareTo(object obj)
        {
            return CompareTo((SomeValueType)obj);
        }
    }
}
