using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncAndAsync
{
    internal class PipClient
    {
        private readonly NamedPipeClientStream m_pip;
        public PipClient(string serverName, string message)
        {
            m_pip = new NamedPipeClientStream(serverName, "Echo", PipeDirection.InOut, PipeOptions.Asynchronous | PipeOptions.WriteThrough);
            m_pip.Connect();
            m_pip.ReadMode = PipeTransmissionMode.Message;

            byte[] output = Encoding.UTF8.GetBytes(message);
            m_pip.BeginWrite(output, 0, output.Length, WriteDone, null);
        }

        private void WriteDone(IAsyncResult result)
        {
            m_pip.EndWrite(result);

            Byte[] bytes = new Byte[1000];
            m_pip.BeginRead(bytes, 0, bytes.Length, GotResponse, bytes);
        }

        private void GotResponse(IAsyncResult result)
        {
            var byteReader = m_pip.EndRead(result);
            var bytes = (byte[])result.AsyncState;
            Console.WriteLine("Server response:" + Encoding.UTF8.GetString(bytes, 0, byteReader));
            m_pip.Close();
        }
    }
}
