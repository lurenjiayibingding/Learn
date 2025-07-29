using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SyncAndAsync.CustomDefined
{
    /// <summary>
    /// 命名管道
    /// </summary>
    public class NamedPipe
    {
        /// <summary>
        /// 命名管道服务端开始异步的监听并处理命名管道客户端发送的数据
        /// </summary>
        /// <param name="pipeName"></param>
        /// <param name="direction"></param>
        /// <param name="maxNumberOfServerInstances"></param>
        /// <param name="transmissionMode"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public async Task ServiceListerAsync(string pipeName, PipeDirection direction, int maxNumberOfServerInstances, PipeTransmissionMode transmissionMode, PipeOptions options)
        {
            while (true)
            {
                var pipeServer = new NamedPipeServerStream(pipeName, direction, maxNumberOfServerInstances, transmissionMode, options);
                await pipeServer.WaitForConnectionAsync();

                _ = Task.Run(async () =>
                {
                    await DefaultServiceHandle(pipeServer);
                });
            }
        }

        public async Task DefaultServiceHandle(NamedPipeServerStream pipeServer)
        {
            using (pipeServer)
            {
                var clientRequest = await ReadPipeStream(pipeServer);
                Console.WriteLine($"命名管道客户端请求数据:{clientRequest}");
                var serviceResponse = clientRequest.ToUpper();
                Console.WriteLine($"命名管道服务端详情数据:{serviceResponse}");
                await WritePipeStreamAsync(pipeServer, clientRequest);
            }
        }

        /// <summary>
        /// 命名管道客户端向服务端发送数据并且获取响应
        /// </summary>
        /// <param name="serverName"></param>
        /// <param name="pipeName"></param>
        /// <param name="direction"></param>
        /// <param name="options"></param>
        /// <param name="transmissionMode"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task<string> ClientSendAndReceive(string serverName, string pipeName, PipeDirection direction, PipeOptions options, PipeTransmissionMode transmissionMode, string message)
        {
            using var pipeClient = new NamedPipeClientStream(serverName, pipeName, direction, options);
            await pipeClient.ConnectAsync();
            pipeClient.ReadMode = transmissionMode;

            await WritePipeStreamAsync(pipeClient, message);

            var response = await ReadPipeStream(pipeClient);
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pipe"></param>
        /// <returns></returns>
        private async Task<string> ReadPipeStream(PipeStream pipe)
        {
            var prefixBytes = await ReadPipeStreamByLen(pipe, 4);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(prefixBytes);
            }
            var bodyLen = BitConverter.ToInt32(prefixBytes);

            var bodyBytes = await ReadPipeStreamByLen(pipe, bodyLen);
            return Encoding.UTF8.GetString(bodyBytes);
        }

        /// <summary>
        /// 从命名管道流中读取指定的字节数
        /// </summary>
        /// <param name="pipe"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        private async Task<byte[]> ReadPipeStreamByLen(PipeStream pipe, int len)
        {
            var byteLen = System.Math.Min(1024, len);
            var memory = new MemoryStream();
            var bytes = new byte[byteLen];
            var totalReadCount = 0;
            while (totalReadCount < len)
            {
                var cuttentReadCount = await pipe.ReadAsync(bytes, 0, bytes.Length);
                await memory.WriteAsync(bytes, 0, cuttentReadCount);
                totalReadCount += cuttentReadCount;
            }

            return memory.ToArray();
        }

        /// <summary>
        /// 异步的向命名管道中写入内容，并且在写入的内容前有内容字节长度前缀
        /// </summary>
        /// <param name="service"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        private async Task WritePipeStreamAsync(PipeStream service, string message)
        {
            var messsageBytes = Encoding.UTF8.GetBytes(message);
            var messageByteCount = messsageBytes.Length;
            var countBytes = BitConverter.GetBytes(messageByteCount);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(countBytes);
            }

            var writeBytes = countBytes.Concat(messsageBytes).ToArray();
            await service.WriteAsync(writeBytes);
        }
    }
}
