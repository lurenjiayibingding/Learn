using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreConsoleThread.Types
{
    public class TimerExplore
    {
        //private static System.Threading.Timer _timer;

        public static async Task Repect()
        {
            var _timer = new System.Threading.Timer((state) =>
             {
                 Console.WriteLine($"Timer is running at {DateTime.Now}");
             }, null, 0, -1);

            Thread.Sleep(2000);

            _timer.Change(1000, Timeout.Infinite); // Start the timer after 1 second and repeat every 1 second
        }


        public static void WaitComplete()
        {
            var _timer = new System.Threading.Timer((state) =>
            {
                Console.WriteLine($"Timer is running at {DateTime.Now}");
            }, null, 0, 1000);

            Thread.Sleep(5000); // Let the timer run for 5 seconds

            var waitHandle = new System.Threading.ManualResetEvent(false);
            _timer.Dispose(waitHandle); // Dispose the timer and wait for any pending callbacks to complete
            waitHandle.WaitOne(); // Wait for the timer to complete

            Console.WriteLine("timer回调全部执行完成");
        }


        public static async Task RepectWithNotTimer()
        {
            while (true)
            {
                Console.WriteLine($"Timer is running at {DateTime.Now},Thread ID {Thread.CurrentThread.ManagedThreadId}");
                await Task.Delay(2000); // Wait for 2 second
            }
        }
    }
}
