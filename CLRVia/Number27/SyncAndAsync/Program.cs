using System.IO.Pipes;

namespace SyncAndAsync
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var input = Console.ReadLine();
            //if (input == "1")
            //{
            //    for (int i = 0; i < Environment.ProcessorCount; i++)
            //    {
            //        new PipeServer();
            //    }
            //    Console.WriteLine("服务端命名管道已经启动");
            //    Console.ReadLine();
            //}
            //else
            //{
            //    for (int i = 0; i < 100; i++)
            //    {
            //        new PipClient("localhost", i.ToString());
            //    }
            //}

            APMExceptionHandling apmException = new APMExceptionHandling();
            apmException.CallWebRequest();

            Console.WriteLine("Hello, World!");
            Console.ReadKey();
        }
    }
}
