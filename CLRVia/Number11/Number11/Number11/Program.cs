using Number11.Class;
using System;
using System.IO;
using System.Threading;

namespace Number11
{
    class Program
    {
        static void Main(string[] args)
        {

            //TypeWithLotsOfEvents t1 = new TypeWithLotsOfEvents();
            //t1.Foo += t1_Foo;
            //t1.Third += T1_Third;

            //TypeWithLotsOfEvents t2 = new TypeWithLotsOfEvents();
            //t2.Foo += t2_Foo;

            //t1.SimulateFoo();

            //MailManager m = new MailManager();
            //m.NewMail += M_NewMail;

            //FileStream[] f = new FileStream[10];

            

        }

        private static void M_NewMail(object sender, NewMailEventArgs e)
        {

        }

        private static void T1_Third(object sender, ThirdEventArgs e)
        {
            Console.WriteLine("444444");
        }

        static void t1_Foo(object sender, FooEventArgs e)
        {
            Console.WriteLine("111111");
        }

        static void t1_1_Foo(object sender, FooEventArgs e)
        {
            Console.WriteLine("33333");
        }

        static void t2_Foo(object sender, FooEventArgs e)
        {
            Console.WriteLine("22222");
        }
    }
}
