using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadOnlyAndConstant
{
    class Program
    {
        static void Main(string[] args)
        {
            //Circular c = new Circular();
            //Console.WriteLine(c.GetName());
            //Console.WriteLine(c.Π);

            var list = new List<Delegate>(5);
            for (int i = 0; i < 5; i++)
            {
                list.Add(new Action(() =>
                {
                    Console.WriteLine(i.ToString());
                }));
            }

            list.ForEach(item => item.DynamicInvoke());


            //var list = new List<Delegate>(5);
            //for (int i = 0; i < 5; i++)
            //{
            //    list.Add(new Action<int>(t =>
            //    {
            //        Console.WriteLine(t.ToString());
            //    }));
            //}

            //list.ForEach(item => item.DynamicInvoke());

            Console.ReadLine();
        }
    }
}
