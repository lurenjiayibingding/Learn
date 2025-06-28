using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Timer t = new Timer(Callback, null, 0, 1000);
            Console.ReadKey();
            //t = null;
            //t.Dispose();

            // TimerCallback timerCallback;
            // if ((timerCallback = Program.TimerCallbackClass.__Callback) == null)
            // {
            //     timerCallback = (Program.TimerCallbackClass.__Callback = new TimerCallback(Program.Callback));
            // }
            // Timer t = new Timer(timerCallback, null, 0, 1000);
            // Console.ReadKey();
        }

        static void Callback(object obj)
        {
            Console.WriteLine("In TimerCallback" + DateTime.Now.ToString());
            GC.Collect();
        }

        // [CompilerGenerated]
        // private static class TimerCallbackClass
        // {
        //     public static TimerCallback __Callback;
        // }
    }
}
