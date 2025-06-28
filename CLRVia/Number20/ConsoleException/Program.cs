using MyException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleException
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowExceptionProperty();
            //ThrowDiskFullException();

            //MyCER myCER = new MyCER();
            //myCER.Demo2();

            Console.ReadKey();
        }

        static void ShowExceptionProperty()
        {
            try
            {
                var exception = new Exception("AAAAA");
                Console.WriteLine("Source1:" + exception.Source);
                Console.WriteLine("StackTrace1:" + exception.StackTrace);
                Console.WriteLine("Message1:" + exception.Message);
                throw exception;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Source2:" + ex.Source);
                Console.WriteLine("StackTrace1:" + ex.StackTrace);
                Console.WriteLine("Message2:" + ex.Message);
            }
        }

        static void ThrowDiskFullException()
        {
            try
            {
                Exception<DiskFullExceptionArgs> exception = new Exception<DiskFullExceptionArgs>(new DiskFullExceptionArgs("D"), "磁盘不存在");

                Exception<DiskFullExceptionArgs> exception2 = new Exception<DiskFullExceptionArgs>(new DiskFullExceptionArgs("C"), "磁盘已满", exception);

                throw exception2;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
