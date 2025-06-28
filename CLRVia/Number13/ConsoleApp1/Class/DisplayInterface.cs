using System.Collections;

namespace ConsoleApp1.Class
{
    /// <summary>
    /// 通过显示接口实现来减少装箱增强编译时类型安全
    /// </summary>
    internal struct SomeValueType : IComparable
    {
        private Int32 m_x;
        public SomeValueType(Int32 x)
        {
            m_x = x;
        }

        public Int32 CompareTo(SomeValueType other)
        {
            return (m_x - ((SomeValueType)other).m_x);
        }

        Int32 IComparable.CompareTo(object? other)
        {
            if (other == null)
                return m_x;
            return CompareTo((SomeValueType)other);
        }
    }

    /// <summary>
    /// 显示接口类型实现的方法无法被派生类继承
    /// </summary>
    internal class Base : IComparable
    {
        //基类中实现一个相同签名相同返回值的虚方法
        public virtual Int32 CompareTo(object? obj)
        {
            Console.WriteLine("Base CompareTo");
            return 0;
        }

        Int32 IComparable.CompareTo(object? obj)
        {
            Console.WriteLine("IComparable CompareTo");
            return 0;
        }
    }

    internal class Derived : Base, IComparable
    {
        public Int32 CompareTo(object? obj)
        {
            Console.WriteLine("Derived CompareTo");

            //如果基类中没有定义一个相同签名相同返回值的虚方法
            //编译报错，因为Base类没有提供一个可供调用的CompareTo方法
            //如果基类中实现了一个相同签名相同返回值的虚方法
            //编译通过，正常运行，派生类可以调用基类中的方法
            //base.CompareTo(obj);

            //会陷入无穷递归，因为Derived中定义的CompareTo方法充当了IComparable接口方法的实现
            //解决方案是注释掉Derived中对IComparable的继承？但是测试后还是会陷入无穷递归
            //IComparable c = this;
            //this.CompareTo(0);

            return 0;
        }
    }
}