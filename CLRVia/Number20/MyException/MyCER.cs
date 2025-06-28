using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace MyException
{
    /// <summary>
    /// 约束执行区域
    /// </summary>
    public class MyCER
    {
        public void Demo1()
        {
            try
            {
                Console.WriteLine("In Try");
            }
            finally
            {
                Type.M1();
            }
        }

        public void Demo2()
        {
            RuntimeHelpers.PrepareConstrainedRegions();
            try
            {
                Console.WriteLine("In Try");
            }
            finally
            {
                Type.M1();
                //Type t = new Type();
                //t.M2();
            }
        }
    }


    sealed class Type
    {
        static Type()
        {
            //throw new Exception("抛出了一个异常");
            Console.WriteLine("Type抛出了一个异常");
        }

        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        public Type()
        {

        }

        [ReliabilityContract(Consistency.MayCorruptProcess, Cer.Success)]
        public static void M1()
        {
            Type2.M1();
            Console.WriteLine("Type static m1");
        }

        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        public void M2()
        {
            Console.WriteLine("Type m2");
        }
    }

    sealed class Type2
    {
        static Type2()
        {
            Console.WriteLine("Type2抛出了一个异常");
        }

        public static void M1()
        {
            Console.WriteLine("Type2 static m1");
        }
    }
}
