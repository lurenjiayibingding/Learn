using CoreConsoleThread.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreConsoleThread.Types
{
    public class TaskContinue
    {
        public void CreateContinue()
        {
            Task.Run<int>(() =>
            {
                Console.WriteLine($"ThreadID1={Thread.CurrentThread.ManagedThreadId}");
                return CommonMethod.Sum(100);
            }).ContinueWith(t =>
            {
                Console.WriteLine($"ThreadID2={Thread.CurrentThread.ManagedThreadId},Prev Result={t.Result}");
                return t.Result * 2;
            }).ContinueWith(t =>
            {
                Console.WriteLine($"ThreadID3={Thread.CurrentThread.ManagedThreadId},Prev Result={t.Result}");
            });
        }
    }
}