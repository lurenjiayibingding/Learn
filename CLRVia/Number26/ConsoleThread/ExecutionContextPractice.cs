using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreConsoleThread
{
    public class ExecutionContextPractice
    {
        private static AsyncLocal<int> age = new();
        private static AsyncLocal<string> name = new();

        public static async Task ContextFlow()
        {
            age.Value = 37;
            name.Value = "liujiguang";

            await Task.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($"age: {age.Value}, name: {name.Value}，Time: {DateTime.Now.Ticks}，ThreadId: {Thread.CurrentThread.ManagedThreadId}");
                    Task.Delay(1000);
                }
            });

            ExecutionContext.SuppressFlow();

            await Task.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($"age: {age.Value}, name: {name.Value}，Time: {DateTime.Now.Ticks}，ThreadId: {Thread.CurrentThread.ManagedThreadId}");
                }
            });
        }

        public static async Task ContextFlow2()
        {
            age.Value = 32;
            name.Value = "mengbuyun";

            await Task.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($"age: {age.Value}, name: {name.Value}，Time: {DateTime.Now.Ticks}，ThreadId: {Thread.CurrentThread.ManagedThreadId}");
                    Task.Delay(1000);
                }
            });

            ExecutionContext.SuppressFlow();

            await Task.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($"age: {age.Value}, name: {name.Value}，Time: {DateTime.Now.Ticks}，ThreadId: {Thread.CurrentThread.ManagedThreadId}");
                }
            });
        }
    }
}
