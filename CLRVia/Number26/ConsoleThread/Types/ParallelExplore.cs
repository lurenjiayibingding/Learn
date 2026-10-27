using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CoreConsoleThread.Types
{
    public class ParallelExplore
    {
        public long DirectoryBytes(string path, string searchPattern, SearchOption searchOption)
        {
            var files = Directory.EnumerateFiles(path, searchPattern, searchOption);
            Int64 masterTotl = 0;
            var result = Parallel.ForEach<string, Int64>(files, () =>
            {
                return 0;
            },
            (file, loopState, index, taskLocalTotal) =>
            {
                Int64 fileLength = 0;
                FileStream fs = null;
                try
                {
                    fs = File.OpenRead(file);
                    fileLength = fs.Length;
                }
                catch (Exception ex)
                {
                }
                finally
                {
                    if (fs != null)
                    {
                        fs.Dispose();
                    }
                }
                return taskLocalTotal += fileLength;
            },
            taskLocalTotal =>
            {
                Interlocked.Add(ref masterTotl, taskLocalTotal);
            });

            return masterTotl;
        }
    }
}
