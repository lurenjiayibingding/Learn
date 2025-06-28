using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAsync1
{
    class Program
    {
        static void Main(string[] args)
        {
            Task t = new Task(() =>
            {
                Console.WriteLine("1");
            });

            MyFileReader.SyncReadMethod();
            Console.WriteLine("--------");
            MyFileReader.ASyncReadMethod();
            Console.WriteLine("--------");

            //System.Threading.Thread.Sleep(3000);
            //MyFileReader.SyncReadMethod();
            //Console.WriteLine("--------");
            Console.ReadKey();

            var array = Enumerable.Range(1, 5);
        }
    }
}
