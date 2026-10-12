using CoreConsoleThread.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreConsoleThread.Types
{
    /// <summary>
    /// 关于异常
    /// </summary>
    public class TaskException
    {
        public async Task Start()
        {
            string str = null;
            var task = Task.Run(() =>
            {
                if (string.IsNullOrEmpty(str))
                {
                    throw new ArgumentNullException(nameof(str), "字符串不能为空");
                }

                CommonMethod.SumWithoutResult(100);
            });

            try
            {
                await task;
                Console.WriteLine(task.Status);
                Thread.Sleep(1000);
                Console.WriteLine(task.Status);
            }
            catch (ArgumentException ex)
            {

            }
        }

        /// <summary>
        /// 任务取消状态
        /// </summary>
        /// <exception cref="OperationCanceledException"></exception>
        public async Task TaskCancelState()
        {
            var task = Task.Run(() =>
            {
                throw new OperationCanceledException("任务被取消");
            });

            //Thread.Sleep(1000);
            //Console.WriteLine(task.Status);
            try
            {
                //await task;
                task.Wait();
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine("任务被取消: {0}", ex.Message);
            }
            catch (AggregateException ex)
            {
                Console.WriteLine("任务被取消: {0}", ex.Message);
            }
            finally
            {
                Console.WriteLine(task.Status);
            }
        }
    }
}