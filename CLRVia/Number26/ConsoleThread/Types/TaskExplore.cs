using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CoreConsoleThread.Definition
{
    /// <summary>
    /// Task学习探索
    /// </summary>
    public class TaskExplore
    {
        CancellationTokenSource ccts = new CancellationTokenSource();
        public async Task<int> SimepleTask(int count)
        {
            TaskScheduler.FromCurrentSynchronizationContext();

            var task = new Task<int>((obj) =>
            {

                if (!(obj is int))
                {
                    return 0;
                }

                var count = (int)obj;
                var result = 0;
                for (int i = 0; i < count; i++)
                {
                    result += i;
                    Thread.Sleep(100);
                }
                return result;
            }, count);
            task.Start();
            var result = await task;
            return result;
        }

        public async Task<int> SimepleTask2(int count)
        {
            return await Task.Run(() =>
            {
                var result = 0;
                for (int i = 0; i < count; i++)
                {
                    result += i;
                    Thread.Sleep(100);
                }
                return result;
            });
        }

        public void OnlyInitTask()
        {
            Task t1 = new Task(() =>
            {
                Console.WriteLine("Init Task");
            });
            t1.Start();
        }

        /// <summary>
        /// 创建Task实例
        /// </summary>
        public void CreateTask()
        {
            var t1 = new Task(() =>
            {
                int sum = 0;
                for (int i = 0; i < 1000; i++)
                {
                    sum += i;
                    Thread.Sleep(100);
                }
            });

            var t2 = new Task((obj) =>
            {
                if (!(obj is int))
                {
                    return;
                }
                int count = (int)obj;
                int sum = 0;
                for (int i = 0; i < count; i++)
                {
                    sum += i;
                    Thread.Sleep(100);
                }
            }, 1000);

            var t3 = new Task<int>(() =>
            {
                int sum = 0;
                for (int i = 0; i < 1000; i++)
                {
                    sum += i;
                    Thread.Sleep(100);
                }
                return sum;
            });

            var t4 = new Task<int>(obj =>
            {
                if (!(obj is int))
                {
                    return 0;
                }
                int count = (int)obj;
                int sum = 0;
                for (int i = 0; i < count; i++)
                {
                    sum += i;
                    Thread.Sleep(100);
                }
                return sum;
            }, 1000);

            var t5 = new Task<int>(new Func<object, int>(Sum), 1000);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private int Sum(object obj)
        {
            if (!(obj is int))
            {
                return 0;
            }
            int count = (int)obj;
            int sum = 0;
            for (int i = 0; i < count; i++)
            {
                sum += i;
                Thread.Sleep(100);
            }
            return sum;
        }

        /// <summary>
        /// 
        /// </summary>
        public void CancelTask()
        {
            try
            {
                var cts = new CancellationTokenSource();
                var t1 = new Task<int>(() => Sum(ccts.Token, 100), cts.Token);

                //ccts.Cancel();
                //t1.Start();

                t1.Start();
                Thread.Sleep(200);
                cts.Cancel();

                //t1.Wait();
                //await t1;

                Task.WaitAll(new Task[] { t1 });
                //Task.WaitAny(new Task[] { t1 });
            }
            catch (AggregateException ex)
            {
                ex.Handle(e =>
                {
                    if (e is OperationCanceledException)
                    {
                        Console.WriteLine("Task被取消");
                        return true;
                    }
                    return false;
                });
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine(ex.GetType().FullName + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().FullName + ex.Message);
            }
        }

        private int Sum(CancellationToken token, int count)
        {
            int sum = 0;
            for (int i = 0; i < count; i++)
            {
                if (token.IsCancellationRequested)
                {
                    token.ThrowIfCancellationRequested();
                    Console.WriteLine("任务被取消");
                }

                Console.WriteLine(sum.ToString());
                sum += i;
                Thread.Sleep(100);
            }
            return sum;
        }


        private event Action<string> DownLoadEvent;
        public async Task TCS()
        {
            var tls = new TaskCompletionSource<string>();
            DownLoadEvent += input =>
            {
                _ = Task.Run(() =>
                 {
                     Console.WriteLine($"开始执行Task完成之后出发的事件，线程Id:{Thread.CurrentThread.ManagedThreadId}");
                     Task.Delay(5000).Wait();
                     Console.WriteLine($"Task完成之后出发的事件执行完成，线程Id:{Thread.CurrentThread.ManagedThreadId}");
                     //tls.SetResult("Task完成之后出发的事件执行完成");
                 });
            };

            try
            {
                await Task.Run(() =>
                {
                    Console.WriteLine($"开始执行Task，线程Id:{Thread.CurrentThread.ManagedThreadId}");
                    Task.Delay(1000).Wait();
                    Console.WriteLine($"Task完成，线程Id:{Thread.CurrentThread.ManagedThreadId}");
                    DownLoadEvent?.Invoke("");
                    throw new Exception("");
                });
            }
            catch (Exception ex)
            {

            }

            tls.Task.Wait();
        }

        public void CancelTaskBeforeStart()
        {
            try
            {
                var source = new CancellationTokenSource();
                source.Token.Register(() =>
                {
                    Console.WriteLine("CancellationToKenSource 取消");
                });
                var task = new Task(() =>
                {
                    for (int i = 0; i < 10; i++)
                    {
                        Console.WriteLine(i.ToString());
                        Thread.Sleep(100);
                    }
                }, source.Token, TaskCreationOptions.None);

                source.Cancel();
                task.Start();

                //task.Start();
                //Thread.Sleep(400);
                //source.Cancel();
            }
            catch (Exception ex)
            {

            }
        }

        public void TaskException()
        {
            TaskScheduler.UnobservedTaskException += (sender, e) =>
            {
                Console.WriteLine("Task发生异常" + e.Exception.GetType().FullName + "Message" + e.Exception.Message);
                e.SetObserved();
            };

            try
            {
                var task = new Task(() =>
                {

                    for (int i = 0; i < 10; i++)
                    {
                        Console.WriteLine(i.ToString());
                        Task.Delay(100).Wait();
                    }
                    throw new Exception("Task异常");
                });
                task.Start();
                task.Wait();
                //await task;

                Thread.Sleep(5000);
                //var exception = task.Exception;
                //if (exception != null)
                //{
                //    Console.WriteLine(exception.GetType().FullName);
                //}
            }
            catch (AggregateException ex)
            {
                ex.Handle(e =>
                {
                    Console.WriteLine("catch:" + e.GetType().FullName);
                    return false;
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine("catch:" + ex.GetType().FullName);
            }
        }

        public void TaskException2()
        {
            try
            {
                TaskScheduler.UnobservedTaskException += (sender, e) =>
                {
                    Console.WriteLine("xxx");
                    e.SetObserved();
                };

                var t1 = Task.Run(() =>
                {
                    for (int i = 0; i < 10; i++)
                    {
                        Console.WriteLine(i.ToString());
                        Task.Delay(100).Wait();
                    }
                    throw new Exception("Task异常");
                });

                Thread.Sleep(5000);
                t1 = null;
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().FullName);
            }
        }

        public void WaitAny()
        {
            try
            {
                var cts = new CancellationTokenSource();

                var t1 = Task.Run(() =>
                {
                    for (int i = 0; i < 10000; i++)
                    {
                        Console.WriteLine(i.ToString());
                        Thread.Sleep(100);
                    }
                });
                var t2 = Task.Run(() =>
                {
                    Sum(cts.Token, 100);
                });

                Thread.Sleep(500);
                cts.Cancel();
                //var result = Task.WaitAny(new Task[] { t1, t2 });
                var result = Task.WaitAny(new Task[] { t2 }, cts.Token);
            }
            catch (AggregateException ex)
            {

            }
            catch (OperationCanceledException ex)
            {

            }
            catch (Exception ex)
            {
            }
        }

        public void WaitAll()
        {
            try
            {
                var cts = new CancellationTokenSource();
                var t1 = Task.Run(() =>
                {
                    for (int i = 0; i < 200; i++)
                    {
                        if (cts.Token.IsCancellationRequested)
                        {
                            cts.Token.ThrowIfCancellationRequested();
                        }
                        Console.WriteLine(i.ToString());
                        Thread.Sleep(100);
                    }
                }, cts.Token);
                var t2 = Task.Run(() =>
                {
                    Sum(cts.Token, 100);
                }, cts.Token);

                //var t3 = new Task(() =>
                //{
                //    for (int i = 0; i < 200; i++)
                //    {
                //        Console.WriteLine(i.ToString());
                //        Thread.Sleep(100);
                //    }
                //}, cts.Token);
                //t3.Start();

                Thread.Sleep(500);
                cts.Cancel();
                //ccts.Cancel();
                Task.WaitAll(new Task[] { t1, t2 });
            }
            catch (AggregateException ex)
            {
            }
            catch (OperationCanceledException ex)
            {

            }
            catch (Exception ex)
            {
            }
        }

        public void TaskContinueWith()
        {
            var t1 = new Task<int>(() =>
            {
                var sum = 0;
                for (int i = 0; i < 10; i++)
                {
                    sum += i;
                    Task.Delay(100).Wait();
                }
                Console.WriteLine("t1 线程:" + Thread.CurrentThread.ManagedThreadId.ToString());
                return sum;
            });
            var t2 = t1.ContinueWith(t =>
            {
                Console.WriteLine("t2 线程:" + Thread.CurrentThread.ManagedThreadId.ToString());
                Console.WriteLine("上一个Task的返回值为:" + t.Result);
            });
            t1.Start();
            t1.Wait();
        }

        public void CancelRun()
        {
            try
            {
                ccts.Cancel();
                var t1 = Task.Run(() =>
                 {
                     for (int i = 0; i < 100; i++)
                     {
                         if (ccts.Token.IsCancellationRequested)
                         {
                             ccts.Token.ThrowIfCancellationRequested();
                         }
                         Console.WriteLine(i.ToString());
                         Thread.Sleep(100);
                     }
                 }, ccts.Token);

                Console.WriteLine(t1.Status.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().FullName);
            }
        }


        public void Exception1()
        {
            try
            {
                Task.Run(() =>
                {
                    throw new Exception("手动抛出的异常");
                });
            }
            catch (Exception ex)
            {

            }
        }
    }
}
