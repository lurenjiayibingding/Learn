using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace FileStreamPractice.DefineClass
{
    internal class FileHelper
    {
        /// <summary>
        /// 文件分块复制
        /// </summary>
        /// <param name="sourcePath"></param>
        /// <param name="targetPath"></param>
        public static void SliverCopy(string sourcePath, string targetPath)
        {
            if (!File.Exists(sourcePath))
            {
                Console.WriteLine("源文件文件不存在");
                return;
            }
            if (File.Exists(targetPath))
            {
                Console.WriteLine("目标文件已存在");
                return;
            }

            long restFileLength;
            int readLength = 10000000;
            byte[] readBytes;
            int count = 1;

            using (var targeStream = File.Create(targetPath))
            {
                //targeStream.Position = 0;
                using (FileStream sourceStreasm = new FileStream(sourcePath, FileMode.Open))
                {
                    sourceStreasm.Position = 0;

                    restFileLength = sourceStreasm.Length;
                    if (restFileLength < readLength)
                    {
                        readLength = (int)restFileLength;
                    }
                    readBytes = new byte[readLength];
                    sourceStreasm.Read(readBytes, 0, readLength);
                    targeStream.Write(readBytes, 0, readLength);
                    restFileLength -= readLength;

                    while (restFileLength > 0)
                    {
                        if (restFileLength < readLength)
                        {
                            readLength = (int)restFileLength;
                        }
                        readBytes = new byte[readLength];
                        sourceStreasm.Read(readBytes, 0, readLength);
                        targeStream.Write(readBytes, 0, readLength);
                        restFileLength -= readLength;
                        count++;
                    }
                    //sourceStreasm.Position = 0;
                }
                //targeStream.Position = 0;
                Console.WriteLine(count);
            }
        }

        /// <summary>
        /// 文件整体复制
        /// </summary>
        /// <param name="sourcePath"></param>
        /// <param name="targetPath"></param>
        public static void WholeCopy(string sourcePath, string targetPath)
        {
            if (!File.Exists(sourcePath))
            {
                Console.WriteLine("源文件文件不存在");
                return;
            }
            if (File.Exists(targetPath))
            {
                Console.WriteLine("目标文件已存在");
                return;
            }


            using (var targeStream = File.Create(targetPath))
            {
                targeStream.Position = 0;
                using (FileStream sourceStreasm = new FileStream(sourcePath, FileMode.Open))
                {
                    byte[] fileByte = new byte[sourceStreasm.Length];
                    sourceStreasm.Read(fileByte, 0, fileByte.Length);
                    targeStream.Write(fileByte, 0, fileByte.Length);
                }
            }
        }

        public static string GetFileMD5(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] md5Value = md5.ComputeHash(fs);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < md5Value.Length; i++)
                {
                    sb.Append(md5Value[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }
    }
}