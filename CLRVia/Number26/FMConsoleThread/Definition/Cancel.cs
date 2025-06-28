using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FMConsoleThread.Definition
{
    /// <summary>
    /// 协作式取消
    /// </summary>
    public class Cancel
    {
        public static void CancelMethod()
        {
            CancellationTokenSource source = new CancellationTokenSource();

            ThreadPool.QueueUserWorkItem(obj =>
            {
                //SomeLongTimeMethod(source.Token, 1000);
                SomeLongTimeMethod(CancellationToken.None, 1000);
            });

            Thread.Sleep(1000);
            source.Cancel();
            Console.WriteLine(source.Token.GetHashCode());
        }

        public static void CancelMethod2()
        {
            CancellationTokenSource source = new CancellationTokenSource();
            var token = source.Token;

            ThreadPool.QueueUserWorkItem(obj =>
            {
                SomeLongTimeMethod(token, 50);
            });
            Thread.Sleep(1000);

            var token2 = source.Token;
            token.Register(new Action(AfterCancelMethod));
            token2.Register(new Action(AfterCancelMethod2));
            token.Register(new Action(AfterCancelMethod3));
            token2.Register(new Action(AfterCancelMethod4));

            source.Cancel(true);
        }

        public static void SomeLongTimeMethod(CancellationToken token, int n)
        {
            for (int i = 0; i < n; i++)
            {
                if (token.IsCancellationRequested)
                {
                    return;
                }
                Console.WriteLine("线程Id：" + Thread.CurrentThread.ManagedThreadId);
                Console.WriteLine(" 时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                Console.WriteLine(" CancellationToken：" + token.GetHashCode());
                Console.WriteLine(" CancellationTokenSource：" + token.CanBeCanceled);
                Thread.Sleep(100);
            }
        }


        public static void AfterCancelMethod()
        {
            Console.WriteLine($"异步任务被取消之后的第一个方法，当前线程:{Thread.CurrentThread.ManagedThreadId}，当前时间:{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffffff")}");
        }

        public static void AfterCancelMethod2()
        {
            Console.WriteLine($"异步任务被取消之后的第二个方法，当前线程:{Thread.CurrentThread.ManagedThreadId}，当前时间:{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffffff")}");
        }

        public static void AfterCancelMethod3()
        {
            //throw new Exception("异步任务被取消之后的第三个方法抛出异常");
            Console.WriteLine($"异步任务被取消之后的第三个方法，当前线程:{Thread.CurrentThread.ManagedThreadId}，当前时间:{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffffff")}");
        }

        public static void AfterCancelMethod4()
        {
            Console.WriteLine($"异步任务被取消之后的第四个方法，当前线程:{Thread.CurrentThread.ManagedThreadId}，当前时间:{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffffff")}");
        }
    }
}