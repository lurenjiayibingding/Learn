using MyTypeForward;
using System.Runtime.CompilerServices;

[assembly: TypeForwardedTo(typeof(ForwardClass))]
//namespace MyTypeForward
//{
//    public class ForwardClass
//    {
//        public static void PrintMessage()
//        {
//            Console.WriteLine(typeof(ForwardClass).Assembly.FullName);
//        }
//    }
//}