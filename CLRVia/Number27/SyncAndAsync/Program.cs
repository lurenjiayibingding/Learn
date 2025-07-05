using System.IO.Pipes;

namespace SyncAndAsync
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            if (input == "1")
            {
                for (int i = 0; i < Environment.ProcessorCount; i++)
                {
                    new PipeServer();
                }
                Console.WriteLine("服务端命名管道已经启动");
                Console.ReadLine();
            }
            else
            {
                while (true)
                {
                    var input2 = Console.ReadLine();
                    new PipClient("localhost", input2);
                }
            }

            Console.WriteLine("Hello, World!");
        }
    }
}
