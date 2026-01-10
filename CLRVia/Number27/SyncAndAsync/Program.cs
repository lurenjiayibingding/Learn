using SyncAndAsync.CustomDefined;
using System.IO.Pipes;
using System.Net;
using System.Text.Json;

namespace SyncAndAsync
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            var pipe = new NamedPipe();
            var input = Console.ReadLine();
            if (input == "1")
            {
                //for (int i = 0; i < Environment.ProcessorCount; i++)
                //{
                //    new PipeServer();
                //}

                //var pipeServer = new PipeServer();
                //await pipeServer.ReceiveAndWriteAsync("Echo");

                _ = pipe.ServiceListerAsync("Echo", PipeDirection.InOut, -1, PipeTransmissionMode.Byte, PipeOptions.Asynchronous | PipeOptions.WriteThrough, pipe.DefaultServiceHandle);

                Console.WriteLine("服务端命名管道已经启动");
                Console.ReadLine();
            }
            else
            {
                //for (int i = 0; i < 100; i++)
                //{
                //    //new PipeClient("localhost", i.ToString());


                //}

                //var pipeClient = new PipeClient();
                //await pipeClient.SendMessageGetResponseAsync("localhost", "Echo", "hello,WorLD");

                Random rand = new Random(DateTime.Now.GetHashCode());
                var chars = new char[52] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
                                  'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't',
                                  'u', 'v', 'w', 'x', 'y', 'z','A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J',
                                  'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T',
                                  'U', 'V', 'W', 'X', 'Y', 'Z' };
                //for (int i = 0; i < 1000; i++)
                //{
                //    var curentChar = new char[10];
                //    for (int j = 0; j < 10; j++)
                //    {
                //        curentChar[j] = chars[rand.Next(chars.Length)];
                //    }
                //    var currentMessage = new string(curentChar);
                //    Console.WriteLine($"{DateTime.Now.ToString("HH-mm-ss.ffffff")}-{i.ToString()}-发送:" + currentMessage);
                //    var result = await pipe.ClientSendAndReceive(".", "Echo", PipeDirection.InOut, PipeOptions.Asynchronous | PipeOptions.WriteThrough, PipeTransmissionMode.Byte, currentMessage);
                //    Console.WriteLine($"{DateTime.Now.ToString("HH-mm-ss.ffffff")}-{i.ToString()}-响应:" + result);
                //}


                //Parallel.For(0, 1000, async (i) =>
                //{
                //    var curentChar = new char[10];
                //    for (int j = 0; j < 10; j++)
                //    {
                //        curentChar[j] = chars[rand.Next(chars.Length)];
                //    }
                //    var currentMessage = new string(curentChar);
                //    Console.WriteLine($"{DateTime.Now.ToString("HH-mm-ss.ffffff")}-{i.ToString()}-发送:" + currentMessage);
                //    var result = await pipe.ClientSendAndReceive(".", "Echo", PipeDirection.InOut, PipeOptions.Asynchronous | PipeOptions.WriteThrough, PipeTransmissionMode.Byte, currentMessage);
                //    Console.WriteLine($"{DateTime.Now.ToString("HH-mm-ss.ffffff")}-{i.ToString()}-响应:" + result);
                //});


                var curentChar = new char[5000];
                for (int j = 0; j < 5000; j++)
                {
                    curentChar[j] = chars[rand.Next(chars.Length)];
                }
                var currentMessage = new string(curentChar);
                Console.WriteLine($"{DateTime.Now.ToString("HH-mm-ss.ffffff")}-发送:" + currentMessage);
                var result = await pipe.ClientSendAndReceive(".", "Echo", PipeDirection.InOut, PipeOptions.Asynchronous | PipeOptions.WriteThrough, PipeTransmissionMode.Byte, currentMessage);
                Console.WriteLine($"{DateTime.Now.ToString("HH-mm-ss.ffffff")}-响应:" + result);

            }

            //APMExceptionHandling apmException = new APMExceptionHandling();
            //apmException.CallWebRequest();

            Console.WriteLine("Hello, World!");
            Console.ReadKey();
        }
    }
}
