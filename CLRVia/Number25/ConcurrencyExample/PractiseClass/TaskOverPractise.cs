using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrencyExample.PractiseClass
{
    public class TaskOverPractise
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        private static async Task<int> DelayAndReturnAsync(int val)
        {
            await Task.Delay(TimeSpan.FromSeconds(val));
            return val;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static async Task ProcressTaskAsync()
        {
            var task1 = DelayAndReturnAsync(2);
            var task2 = DelayAndReturnAsync(3);
            var task3 = DelayAndReturnAsync(1);

            var tasks = new Task<int>[] { task1, task2, task3 };
            foreach (var item in tasks)
            {
                var result = await item;
                Console.WriteLine(result);
            }
        }

        public static async Task AwaitAndProcressAsync(Task<int> task)
        {
            var result = await task;
            Console.WriteLine(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static async Task ProcressTaskAsync2()
        {
            var task1 = DelayAndReturnAsync(2);
            var task2 = DelayAndReturnAsync(3);
            var task3 = DelayAndReturnAsync(1);

            var tasks = new Task<int>[] { task1, task2, task3 };
            var procressingTask = (from t in tasks
                                   select AwaitAndProcressAsync(t)).ToArray();
            await Task.WhenAll(procressingTask);
        }
    }
}