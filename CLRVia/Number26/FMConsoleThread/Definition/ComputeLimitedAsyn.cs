using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Remoting.Messaging;

namespace FMConsoleThread.Definition
{
    /// <summary>
    /// 计算限制的异步操作
    /// </summary>
    public class ComputeLimitedAsyn
    {
        public void ComputeLimitedAsynMethod()
        {
            //向线程池中添加请求
            ThreadPool.QueueUserWorkItem(obj =>
            {
                Console.WriteLine("时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "，线程Id：" + Thread.CurrentThread.ManagedThreadId);
                //若在初始线程中通过ExecutionContext.SuppressFlow阻止了执行上下文的流动
                //或者在初始线程中为配置名为Name的逻辑调用上下文数据
                //则CallContext.LogicalGetData("Name")为null
                Console.WriteLine("主线程信息：" + CallContext.LogicalGetData("Name")?.ToString());

                //初始线程阻止执行上下文流动，辅助线程未作限制，辅助线程的辅助线程可以获取到辅助线程设置的执行上下文
                CallContext.LogicalSetData("Name", "德华");

                //ExecutionContext.SuppressFlow();

                //通过Task实现异步任务
                Task.Run(() =>
                {
                    Console.WriteLine("Task 线程Id：" + Thread.CurrentThread.ManagedThreadId);
                    Console.WriteLine("Task 的主线程信息：" + System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("Name")?.ToString());
                });
            });
        }
    }
}