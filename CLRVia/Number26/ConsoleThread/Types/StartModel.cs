using CoreConsoleThread.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreConsoleThread.Types
{
    /// <summary>
    /// Task的启动方式
    /// </summary>
    public class StartModel
    {
        public async Task NormalStart()
        {
            var task = new Task<int>(new Func<object?, int>(CommonMethod.Sum), 100);
            task.Start(TaskScheduler.FromCurrentSynchronizationContext());
            //var result = task.Result;
            var result = await task;
        }

        public void StartWithCancellationToken()
        {
            var cts = new CancellationTokenSource();
            var token = cts.Token;
            ////cts.CancelAfter(1000);
            //cts.Cancel();
            //var task = new Task<int>(new Func<object?, int>(CommonMethod.Sum), 10000, token);
            //try
            //{
            //    Console.WriteLine(task.Status.ToString());
            //    task.Start(TaskScheduler.Default);
            //    task.Wait();
            //    Console.WriteLine(task.Status.ToString());
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.GetType().Name);
            //}


            //cts.CancelAfter(1000);
            cts.Cancel();
            try
            {
                var task = Task.Run(() =>
                {
                    CommonMethod.SumWithoutResult(100);
                }, cts.Token);

                Console.WriteLine(task.Status.ToString());
                task.Start(TaskScheduler.Default);
                task.Wait();
                Console.WriteLine(task.Status.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().Name);
            }
        }


        public async Task RunStart()
        {
            await Task.Run(() =>
            {
                CommonMethod.Sum(100);
            });
        }
    }
}
