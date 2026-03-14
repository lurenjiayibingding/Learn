using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncAndAsync.CustomDefined
{
    /// <summary>
    /// TAP模式
    /// </summary>
    internal class TAPPattern
    {
        public async Task ReadFile(string path)
        {
            //using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            //{
            //}


            //var stringCollection = new List<string>();
            //Parallel.ForEach(stringCollection, new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount * 2 }, item =>
            //{
            //    //写入到磁盘
            //});

            //foreach (var item in stringCollection)
            //{
            //    //写入到磁盘
            //}

            //Parallel.ForEachAsync(stringCollection, new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount * 2 }, async item =>
            //{
            //    //写入到磁盘
            //});
        }
    }
}
