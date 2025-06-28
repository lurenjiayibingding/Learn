using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreConsoleThread.Definition
{
    /// <summary>
    /// 协作式取消
    /// </summary>
    public class Cancel
    {
        /// <summary>
        /// 取消方法时的回调
        /// </summary>
        public static void CancelMethod()
        {
            CancellationTokenSource source = new CancellationTokenSource();
            ThreadPool.QueueUserWorkItem(obj =>
            {
                SomeLongTimeMethod(CancellationToken.None, 50);
            });
            System.Threading.Thread.Sleep(1000);

            source.Token.Register(new Action(AfterCancelMethod), true);
            source.Token.Register(new Action(AfterCancelMethod2), true);
            source.Token.Register(new Action(AfterCancelMethod3), false);
            source.Token.Register(new Action(AfterCancelMethod4), false);

            source.Cancel();
        }

        /// <summary>
        /// 需要在其他线程中执行的可取消的方法
        /// </summary>
        /// <param name="token"></param>
        /// <param name="n"></param>
        public static void SomeLongTimeMethod(CancellationToken token, int n)
        {
            token.Register(() =>
            {
                Console.WriteLine("SomeLongTimeMethod中注册的取消回调");
            });

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

        /// <summary>
        /// 将多个Token合并为一个TokenSource并且取消其中一个
        /// </summary>
        public static void MonitorCancelTokenSource()
        {
            var source1 = new CancellationTokenSource();
            var source2 = new CancellationTokenSource();

            source1.Token.Register(() =>
            {
                Console.WriteLine("source1 取消");
            });
            source2.Token.Register(() =>
            {
                Console.WriteLine("source2 取消");
            });
            source2.Token.Register(() =>
            {
                Console.WriteLine("source2 取消2");
            });

            var source3 = CancellationTokenSource.CreateLinkedTokenSource(source1.Token, source2.Token);
            source3.Token.Register(() =>
            {
                Console.WriteLine($"有任务被取消取消，source1.IsCancellationRequested={source1.IsCancellationRequested}," +
                    $"source2.IsCancellationRequested={source2.IsCancellationRequested}," +
                    $"source3.IsCancellationRequested={source3.IsCancellationRequested}");
            });
            source2.Cancel();
        }

        /// <summary>
        /// 注销取消时注册的回调方法
        /// </summary>
        public static void DisposeRegister()
        {
            var source = new CancellationTokenSource();

            var registration1 = source.Token.Register(() =>
            {
                Console.WriteLine("source 取消");
            });
            var registration2 = source.Token.Register(() =>
            {
                Console.WriteLine("source 取消2");
            });
            var registration3 = source.Token.Register(() =>
            {
                Console.WriteLine("source 取消3");
            });

            registration2.Dispose();

            source.Cancel();
        }

        /// <summary>
        /// 通过构造函数自动取消
        /// </summary>
        public static void AutomaticCancelByConstruction()
        {
            var source = new CancellationTokenSource(600);
            source.Token.Register(() =>
            {
                Console.WriteLine("source 取消");
            });
            ThreadPool.QueueUserWorkItem(ojb =>
            {
                SomeLongTimeMethod(source.Token, 10);
            });
        }

        /// <summary>
        /// 通过CancelAfter方法自动取消
        /// </summary>
        public static void AutomaticCancelByCancelMethod()
        {
            var source = new CancellationTokenSource(600);
            source.Token.Register(() =>
            {
                Console.WriteLine("source 取消");
            });
            //source.CancelAfter(600);
            ThreadPool.QueueUserWorkItem(ojb =>
            {
                SomeLongTimeMethod(source.Token, 10);
            });
            //source.CancelAfter(600);
            source.CancelAfter(new TimeSpan(0, 0, 0, 0, 600));
        }

        /// <summary>
        /// 取消时的回调方法
        /// </summary>
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

        /// <summary>
        /// 取消时的回调抛出异常
        /// </summary>
        public static void CancelRegisterThrowException()
        {
            var source = new CancellationTokenSource();
            source.Token.Register(() =>
            {
                Console.WriteLine($"取消时的回调1，线程Id{Thread.CurrentThread.ManagedThreadId}");
            });
            source.Token.Register(() =>
            {
                Console.WriteLine($"取消时的回调2，线程Id{Thread.CurrentThread.ManagedThreadId}");
                //throw new Exception("取消时的回调2抛出异常");
            });
            source.Token.Register(() =>
            {
                Console.WriteLine($"取消时的回调3，线程Id{Thread.CurrentThread.ManagedThreadId}");
            });

            ThreadPool.QueueUserWorkItem(obj =>
            {
                SomeLongTimeMethod(source.Token, 50);
            }, null);

            try
            {
                source.Cancel();
                source.Token.Register(() =>
                {
                    Console.WriteLine($"取消之后注册的的回调1，线程Id{Thread.CurrentThread.ManagedThreadId}");
                });
                source.Token.Register(() =>
                {
                    Console.WriteLine($"取消之后注册的的回调2，线程Id{Thread.CurrentThread.ManagedThreadId}");
                });
                source.Token.Register(() =>
                {
                    Console.WriteLine($"取消之后注册的的回调3，线程Id{Thread.CurrentThread.ManagedThreadId}");
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().FullName);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static void LinkedTokenSourceCancel()
        {
            var source1 = new CancellationTokenSource();
            source1.Token.Register(() =>
            {
                Console.WriteLine($"source1取消之后注册的的回调，线程Id{Thread.CurrentThread.ManagedThreadId}");
            });
            var source2 = new CancellationTokenSource();
            source2.Token.Register(() =>
            {
                Console.WriteLine($"source2取消之后注册的的回调，线程Id{Thread.CurrentThread.ManagedThreadId}");
            });
            var source3 = new CancellationTokenSource();
            source3.Token.Register(() =>
            {
                Console.WriteLine($"source3取消之后注册的的回调，线程Id{Thread.CurrentThread.ManagedThreadId}");
            });
            var source4 = new CancellationTokenSource();
            source4.Token.Register(() =>
            {
                Console.WriteLine($"source4取消之后注册的的回调，线程Id{Thread.CurrentThread.ManagedThreadId}");
            });

            var linkedSource = CancellationTokenSource.CreateLinkedTokenSource(new CancellationToken[] {
                source1.Token,
                source2.Token,
                source3.Token,
                source4.Token
            });
            linkedSource.Token.Register(() =>
            {
                Console.WriteLine($"Linked取消之后注册的的回调，线程Id{Thread.CurrentThread.ManagedThreadId}。" +
                    $"source1={source1.IsCancellationRequested}，{source1.Token.IsCancellationRequested}" +
                    $"source2={source2.IsCancellationRequested}，{source2.Token.IsCancellationRequested}" +
                    $"source3={source3.IsCancellationRequested}，{source3.Token.IsCancellationRequested}" +
                    $"source4={source4.IsCancellationRequested}， {source4.Token.IsCancellationRequested}");
            });
            linkedSource.Token.Register(() =>
            {
                Console.WriteLine($"Linked取消之后注册的的回调2，线程Id{Thread.CurrentThread.ManagedThreadId}");
            });

            //source4.Cancel();
            //source2.Cancel();

            linkedSource.Cancel();

        }
    }
}