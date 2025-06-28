using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrencyExample.PractiseClass
{
    internal class ProgressPractise
    {
        public static async Task MyMethodAsync(IProgress<double> progress = null)
        {
            double precentComplete = 0;
            while (precentComplete <= 100)
            {
                Console.WriteLine(DateTime.Now.Ticks.ToString());
                await Task.Delay(1000);
                //异步方法中需要重复执行的逻辑
                if (progress != null)
                {
                    progress.Report(precentComplete);
                    precentComplete += 10;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static async Task CallMyMethod()
        {
            var progeress = new Progress<double>();
            progeress.ProgressChanged += (sender, args) =>
            {
                //实时报告进度
                Console.WriteLine($"当前进度{args.ToString()}%");
            };

            await MyMethodAsync(progeress);
        }
    }
}
