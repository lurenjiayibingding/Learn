using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAsync1
{
    public class MyFileReader
    {
        private static FileStream fs;

        public static void SyncReadMethod()
        {
            using (fs = new FileStream(@"C:\Users\刘继光\Desktop\静夜思.txt", FileMode.Open, FileAccess.Read))
            {
                int readLength = 0;
                int totalLength = 0;
                List<byte> readResult = new List<byte>();
                do
                {
                    byte[] readArray = new byte[100];
                    readLength = fs.Read(readArray, 0, readArray.Length);
                    readResult.AddRange(readArray);
                    totalLength += readLength;
                }
                while (readLength > 0);
                Console.WriteLine(totalLength);
                Console.WriteLine(Encoding.UTF8.GetString(readResult.ToArray()));
            }
        }

        public static void SyncReadMethod2()
        {
            using (fs = new FileStream(@"C:\Users\刘继光\Desktop\静夜思.txt", FileMode.Open, FileAccess.Read))
            {
                byte[] readArray = new byte[fs.Length];
                var readLength = fs.Read(readArray, 0, (int)fs.Length);
                Console.WriteLine(readLength.ToString());
                Console.WriteLine(Encoding.UTF8.GetString(readArray));
            }
        }

        public static void ASyncReadMethod()
        {
            fs = new FileStream(@"C:\Users\刘继光\Desktop\静夜思.txt", FileMode.Open, FileAccess.Read);
            byte[] array = new byte[fs.Length];
            fs.BeginRead(array, 0, (int)fs.Length, ReadCallback, array);
        }

        private static void ReadCallback(IAsyncResult ar)
        {
            //等待挂起的异步读操作完成。
            int length = fs.EndRead(ar);
            byte[] array = (byte[])ar.AsyncState;
            Console.WriteLine(length.ToString());
            Console.WriteLine(Encoding.UTF8.GetString(array));
        }
    }
}
