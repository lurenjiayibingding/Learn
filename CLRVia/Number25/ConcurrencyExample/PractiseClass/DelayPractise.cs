using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrencyExample.PractiseClass
{
    internal class DelayPractise
    {
        /// <summary>
        /// 异步延迟返回某个类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result"></param>
        /// <param name="delay"></param>
        /// <returns></returns>
        public static async Task<T> DelayDemo<T>(T result, TimeSpan delay)
        {
            await Task.Delay(delay);
            return result;
        }

        /// <summary>
        /// 实现一个而简单的指数退避策略来重试访问uri
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public static async Task<string> DownloadStringWithRetrie(string uri)
        {
            using (var client = new HttpClient())
            {
                var nextDelay = TimeSpan.FromSeconds(1);
                for (int i = 0; i < 3; i++)
                {
                    try
                    {
                        return await client.GetStringAsync(uri);
                    }
                    catch
                    {

                    }
                    await Task.Delay(nextDelay);
                    nextDelay += nextDelay;
                }
                return await client.GetStringAsync(uri);
            }
        }

        /// <summary>
        /// 实现一个简单的超时
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public static async Task<string> SownloadStringWithTimeout(string uri)
        {
            using (var client = new HttpClient())
            {
                var downloadTask = client.GetStringAsync(uri);
                var timeoutTask = Task.Delay(3000);
                var completedTask = await Task.WhenAny(new Task[] { downloadTask, timeoutTask });
                if (completedTask == timeoutTask)
                {
                    return "访问超时";
                }
                return await downloadTask;
            }
        }
    }
}
