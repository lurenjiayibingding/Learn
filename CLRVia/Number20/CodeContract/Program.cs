using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CodeContract
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<string> aaaa = new List<string>();

            //aaaa.Any(n => n == "111");

            //ConstantExpression constantExpression = Expression.Constant("aa", typeof(string));

            ////ShoppingCart shopping = new ShoppingCart();
            ////shopping.AddItem(null);

            //System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace();

            //MethodInvoke methodInvoke = new MethodInvoke();
            //methodInvoke.A();
            //try
            //{
            //    methodInvoke.E();
            //}
            //catch (Exception ex)
            //{
            //    throw;
            //}

            //FinallyTest test = new FinallyTest();
            //Console.WriteLine("before");
            //Console.WriteLine(test.FinallyMethod2());
            //Console.WriteLine("end");


            CatchTest.CatchMethod();

            Console.WriteLine("over");
            Console.ReadKey();
        }
    }
}