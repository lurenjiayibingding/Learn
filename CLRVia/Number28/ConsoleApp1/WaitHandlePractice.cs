using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConsoleApp1
{
    internal class WaitHandlePractice
    {
        public static void RegisterPractice()
        {

            var autoEvent = new AutoResetEvent(true);


            ThreadPool.RegisterWaitForSingleObject(new Mutex(false), (state, timedOut) =>
            {
                Console.WriteLine("Wait handle callback executed. Timed out: " + timedOut);
            }, null, TimeSpan.FromSeconds(5), true);
        }
    }
}
