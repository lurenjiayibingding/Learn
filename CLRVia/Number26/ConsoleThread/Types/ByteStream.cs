using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreConsoleThread.Types
{
    /// <summary>
    /// 自定义类型
    /// </summary>
    public class ByteStream : IDisposable
    {
        private readonly Stream _stream;
        private readonly byte[] _buffer;
        private int position;
        private int bufferedBytes;

        public ByteStream(Stream stream)
        {
            _stream = stream ?? throw new ArgumentNullException(nameof(stream));
            _buffer = new byte[1024 * 8];
        }


        public async ValueTask<byte?> ReadByteAsync()
        {
            if (position == bufferedBytes)
            {
                position = 0;
                bufferedBytes = await _stream.ReadAsync(_buffer, 0, _buffer.Length).ConfigureAwait(false);
                if (bufferedBytes == 0)
                {
                    return null;
                }
            }

            return _buffer[position++];
        }

        public async ValueTask aaa()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            _stream.Dispose();
        }
    }

    public class OutputContent
    {
        public async Task OutPut(string path)
        {
            using var byteStream = new ByteStream(File.OpenRead(path));
            {
                byte? nextByte;
                while ((nextByte = await byteStream.ReadByteAsync()).HasValue)
                {
                    Console.WriteLine(nextByte);
                }
            }
        }
    }
}
