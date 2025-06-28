using FMConsoleThread.Definition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Remoting;

namespace FMConsoleThread
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //CallContext.LogicalSetData("Name", "彦祖");
            //ComputeLimitedAsyn computeLimitedAsyn = new ComputeLimitedAsyn();

            ////未阻止执行上下文
            //computeLimitedAsyn.ComputeLimitedAsynMethod();

            ////阻止上下文流动
            //ExecutionContext.SuppressFlow();
            //computeLimitedAsyn.ComputeLimitedAsynMethod();
            //Console.WriteLine(ExecutionContext.IsFlowSuppressed());

            ////恢复上下文流动
            //ExecutionContext.RestoreFlow();
            //computeLimitedAsyn.ComputeLimitedAsynMethod();
            //Console.WriteLine(ExecutionContext.IsFlowSuppressed());

            try
            {
                Cancel.CancelMethod2();
            }
            catch (AggregateException aex)
            {
                Console.WriteLine(aex.InnerExceptions[0].Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}
