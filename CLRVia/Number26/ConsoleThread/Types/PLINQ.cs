using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreConsoleThread.Types
{
    public class PLINQ
    {
        public static void QueryParallel()
        {
            var numbers = Enumerable.Range(1, 10000000).Select(_ => Random.Shared.Next(0, 10000000)).ToList();

            var quearyArray = new List<List<int>>();
            for (int i = 0; i < 100; i++)
            {
                quearyArray.Add(numbers.AsParallel().Where(n => n % 9 == 0).ToList());
            }

            for (int i = 0; i < quearyArray.Count() - 1; i++)
            {
                for (int j = i + 1; j < quearyArray.Count(); j++)
                {
                    if (!quearyArray[i].SequenceEqual(quearyArray[j]))
                    {
                        Console.WriteLine("顺序不同");
                        return;
                    }
                }
            }
        }
    }
}
