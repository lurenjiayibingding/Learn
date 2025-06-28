using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                FrameworkLib.FrameworkPrint frameworkPrint = new FrameworkLib.FrameworkPrint();
                frameworkPrint.Print();

                Console.WriteLine("Read Key");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
        }
    }
}
