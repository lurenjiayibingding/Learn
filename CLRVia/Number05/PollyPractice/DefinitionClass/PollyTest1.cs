using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Polly;
//using pl = Polly;

namespace PollyPractice.DefinitionClass
{
    internal class PollyTest1
    {
        public int UsingPolly(float input)
        {
            //var policy = Policy.Handle<System.OverflowException>()
            //    .Or<System.OutOfMemoryException>()
            //    .OrResult<sbyte>(result => result < 0)
            //    .Retry(3, (exception, retryCount) =>
            //    {
            //        Console.WriteLine($"第{retryCount}次执行失败，响应结果{JsonConvert.SerializeObject(exception)}");
            //    });


            var policy = Policy.Handle<System.OverflowException>()
                .Or<System.OutOfMemoryException>()
                .OrResult<sbyte>(result => result < 0)
                .WaitAndRetry(
                new TimeSpan[3]
                {
                    TimeSpan.FromMilliseconds(500),
                    TimeSpan.FromMilliseconds(1000),
                    TimeSpan.FromMilliseconds(1500),
                },
                (exception, timespan, retryCount, context) =>
                {
                    Console.WriteLine($"{DateTime.Now.Ticks.ToString()}第{retryCount}次执行失败");
                    Console.WriteLine($"exception:{JsonConvert.SerializeObject(exception)}");
                    Console.WriteLine($"timespan:{JsonConvert.SerializeObject(timespan)}");
                    Console.WriteLine($"retryCount:{JsonConvert.SerializeObject(retryCount)}");
                    Console.WriteLine($"context:{JsonConvert.SerializeObject(context)}");
                }
                );



            return policy.Execute(() => ReturnInt(input));
        }

        public sbyte ReturnInt(float inoput)
        {
            return checked((sbyte)inoput);
        }
    }
}